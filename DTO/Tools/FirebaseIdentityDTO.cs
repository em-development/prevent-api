namespace DTO.Tools
{
    public class FirebaseIdentityDto
    {
        public string? UId { get; private set; }
        public string? Email { get; private set; }

        public FirebaseIdentityDto(string? uId, string? email)
        {
            UId = uId;
            Email = email;
        }
    }
}
