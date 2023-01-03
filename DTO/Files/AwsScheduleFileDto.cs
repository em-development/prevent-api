using Domain.Enums.Files;

namespace DTO.Files
{
    public class AwsScheduleFileDto
    {
        public string Key { get; set; } = string.Empty;
        public string Bucket { get; set; } = string.Empty;
        public Stream Content { get; set; } = Stream.Null;
        public string ContentType { get; set; } = string.Empty;
        public TypeAwsScheduleActionEnum TypeActionEnum { get; set; }
    }
}