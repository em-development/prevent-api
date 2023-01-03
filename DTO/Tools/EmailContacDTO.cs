namespace DTO.Tools
{
    public sealed class EmailContacDTO
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public EmailContacDTO(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
