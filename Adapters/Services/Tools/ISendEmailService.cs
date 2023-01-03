using DTO.Tools;

namespace Adapters.Services.Tools
{
    public interface ISendEmailService
    {
        Task Send(List<EmailContacDTO> contacts, int code);
    }
}