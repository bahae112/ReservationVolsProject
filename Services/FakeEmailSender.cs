using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

public class FakeEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Simule l'envoi d'un email (ne fait rien)
        return Task.CompletedTask;
    }
}
