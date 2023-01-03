namespace DTO.Files
{
    public class AttachmentDto
    {
        public int Id { get; set; }
        public string Guid { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string Bucket { get; set; } = string.Empty;
        public byte[] Content { get; set; } = Array.Empty<byte>();
        public string? Url { get; set; } = string.Empty;
    }
}