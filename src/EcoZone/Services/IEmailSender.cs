using System.Threading.Tasks;

namespace EcoZone.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}