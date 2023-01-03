using Adapters.Services.Files;
using Amazon.S3;
using Amazon.S3.Model;
using Application.Exceptions.Common;
using AutoMapper;
using Domain.Enums.Files;
using DTO.Files;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Files
{
    public class AwsFileStorageService : IFileStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly IAmazonS3 _client;
        private static IAmazonS3 _staticClient;
        private readonly IMapper _mapper;

        private IList<AwsScheduleFileDto> awsFilesData = new List<AwsScheduleFileDto>();

        public AwsFileStorageService(
            IAmazonS3 client,
            IConfiguration configuration,
            IMapper mapper)
        {
            _client = client;
            _staticClient = _client;
            _configuration = configuration;
            _mapper = mapper;
        }

        private async Task UploadObjectAsync(string key, Stream content, string contentType)
        {
            try
            {
                var request = new PutObjectRequest()
                {
                    BucketName = _configuration.GetSection("S3:Bucket").Value,
                    Key = key,
                    InputStream = content,
                    StorageClass = "STANDARD_IA",
                    ContentType = contentType
                };

                await _client.PutObjectAsync(request);
            }
            catch (AmazonS3Exception ex)
            {
                throw new FileStorageOperationException(ex.Message);
            }
        }

        private Task RemoveObjectAsync(string bucketName, string key)
        {
            try
            {
                return _client.DeleteObjectAsync(bucketName, key);
            }
            catch (AmazonS3Exception ex)
            {
                throw new FileStorageOperationException(ex.Message);
            }
        }

        public byte[]? GetObjectDirectAsync(string bucketName, string key)
        {
            try
            {
                var memoryStream = new MemoryStream();

                var responseStream =
                    _client.GetObjectAsync(bucketName, key).Result.ResponseStream;

                responseStream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
            catch
            {
                return null;
            }
        }

        public Stream? GetStreamDirectAsync(string bucketName, string key)
        {
            try
            {
                return _client.GetObjectAsync(bucketName, key).Result.ResponseStream;
            }
            catch
            {
                return null;
            }
        }

        public static string? GetObjectDirectLinkAsync(
            string bucketName,
            string key,
            string downloadFileName,
            string contentType)
        {
            downloadFileName = downloadFileName.Replace(",", "");
            downloadFileName = downloadFileName.Replace(";", "");

            try
            {
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    Expires = DateTime.Now.AddHours(1)
                };

                if (request.ResponseHeaderOverrides == null) return _staticClient.GetPreSignedURL(request);
                request.ResponseHeaderOverrides.ContentType = contentType;
                request.ResponseHeaderOverrides.ContentDisposition = $"inline; filename={downloadFileName}";

                return _staticClient.GetPreSignedURL(request);
            }
            catch
            {
                return null;
            }
        }

        public void AddFileToSchedule(AttachmentDto dto, TypeAwsScheduleActionEnum typeActionEnum)
        {
            var scheduleFile = _mapper.Map<AwsScheduleFileDto>(dto);
            scheduleFile.TypeActionEnum = typeActionEnum;

            awsFilesData.Add(scheduleFile);
        }
        public void AddFileToSchedule(AwsScheduleFileDto scheduleFile)
        {
            awsFilesData.Add(scheduleFile);
        }

        public void RunScheduled()
        {
            List<Task> tasks = new List<Task>();

            var bucket = _configuration.GetSection("S3:Bucket").Value;

            foreach (var awsFileData in awsFilesData)
            {
                switch (awsFileData.TypeActionEnum)
                {
                    case TypeAwsScheduleActionEnum.UPLOAD:
                    {
                        tasks.Add(this.UploadObjectAsync(
                            awsFileData.Key,
                            awsFileData.Content,
                            awsFileData.ContentType)
                        );
                        break;
                    }
                    case TypeAwsScheduleActionEnum.REMOVE when bucket == awsFileData.Bucket:
                        tasks.Add(this.RemoveObjectAsync(
                            awsFileData.Bucket,
                            awsFileData.Key)
                        );
                        break;
                    case TypeAwsScheduleActionEnum.REMOVE:
                        awsFileData.TypeActionEnum = TypeAwsScheduleActionEnum.IGNORE;
                        break;
                }

                Console.WriteLine(
                    $"{awsFileData.TypeActionEnum} => {awsFileData.Bucket} | {awsFileData.Key}");
            }

            if (awsFilesData.Count == 0)
            {
                Console.WriteLine("There are no files to send to AWS");
            }

            Task.WhenAll(tasks).Wait();
        }
    }
}