using System.IO.Compression;
using Application.Exceptions.Common;
using DTO.Files;

namespace API.Helpers
{
    public static class FileHelper 
    {
        private static readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>
        {
            {"jp2", "image/jp2"},
            {"jpe", "image/jpeg"},
            {"jpeg", "image/jpeg"},
            {"jpg", "image/jpeg"},
            {"png", "image/png"},
            {"pdf", "application/pdf"},
            {"xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"}
        };

        internal static async Task<MemoryStream> ReadStreamAsync(this IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream;
        }
  
        public static async Task<AttachmentDto> GetAttachmentAsync(this IFormFile file)
        {
            if (file == null)
            {
                throw new RequiredFileException();
            }

            var fileData = await file.ReadStreamAsync();

            var attachment = new AttachmentDto
            {
                Content = fileData.ToArray(),
                ContentType = file.ContentType,
                FileName = file.FileName
            };

            return attachment;
        }

        public static AttachmentDto GetAttachmentAsync(ZipArchiveEntry entry)
        {
            AttachmentDto attachment = new();

            using StreamReader reader = new(entry.Open());
            using (MemoryStream stream = new())
            {
                reader.BaseStream.CopyTo(stream);
                stream.ToArray();
            }

            var extension = Path.GetExtension(entry.FullName).Substring(1).ToLower();
            var contentType = MimeTypes[extension];

            if (contentType == null)
            {
                throw new UnsupportedFileFormatException(
                    "api-file",
                    ("api-file-format", extension)
                );
            }

            return attachment;
        }

        public static async Task<IEnumerable<AttachmentDto>> GetAttachmentsAsync(
            this IEnumerable<IFormFile> files)
        {
            List<AttachmentDto> items = new();

            foreach (var file in files)
            {
                string[] mimeTypeZip = {"application/x-zip-compressed", "application/zip"};

                if (mimeTypeZip.Contains(file.ContentType))
                {
                    using ZipArchive zip = new(await ReadStreamAsync(file));
                    items.AddRange(zip.Entries.Select(GetAttachmentAsync));
                }
                else
                {
                    var attachment = await GetAttachmentAsync(file);
                    items.Add(attachment);
                }
            }

            return items;
        }
    }
}