using Domain.Enums.Files;
using DTO.Files;

namespace Adapters.Services.Files
{
    public interface IFileStorageService
    {
        byte[]? GetObjectDirectAsync(string bucketName, string key);
        Stream? GetStreamDirectAsync(string bucketName, string key);
        void AddFileToSchedule(AttachmentDto dto, TypeAwsScheduleActionEnum typeActionEnum);
        void AddFileToSchedule(AwsScheduleFileDto scheduleFile);
        void RunScheduled();
    }
}