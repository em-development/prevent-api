using System.Security.Cryptography;
using System.Text;

namespace DTO.Settings.Users
{
    public sealed class CompactUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? UId { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }

        public string IdAsSecret
        {
            get
            {
                MD5 md5 = MD5.Create();

                byte[] inputBytes = Encoding.ASCII.GetBytes(Id.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();

            }
            set
            {
                IdAsSecret = string.Empty;
            }
        }
    }
}
