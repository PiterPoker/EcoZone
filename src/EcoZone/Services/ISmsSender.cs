using System.Threading.Tasks;

namespace EcoZone.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}