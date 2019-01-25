using PayloadPost.Models;
using System.Threading.Tasks;

namespace PayloadPost.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailDetail emailDetail);
    }
}
