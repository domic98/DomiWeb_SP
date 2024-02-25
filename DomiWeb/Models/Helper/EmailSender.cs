using Microsoft.AspNetCore.Identity.UI.Services;

namespace DomiWeb.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // logika za slanje emailova
            return Task.CompletedTask;
        }
    }
}
