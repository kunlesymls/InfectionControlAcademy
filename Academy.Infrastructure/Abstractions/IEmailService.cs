using System.Threading.Tasks;

namespace Academy.Infrastructure.Abstractions
{
    public interface IEmailService
    {
        //Task SendEmailAsync(string email, string subject, string message);
        Task SendEmail(string email, string subject, string message, string fullName = "");
    }
}
