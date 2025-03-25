using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace reservation_vols.Utility
{
    public class EmailSender : IEmailSender
    {
        // Cette méthode est une simple simulation de l'envoi d'un e-mail
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Ici vous pouvez simplement enregistrer l'e-mail dans une base de données ou dans un fichier log
            // pour simulation. Par exemple, afficher dans la console :
            Console.WriteLine($"Envoi d'email à {email} avec le sujet {subject}.");
            Console.WriteLine($"Message: {htmlMessage}");

            // Vous pouvez ajouter de la logique pour enregistrer les messages dans une base de données ici.
            // Exemple de sauvegarde dans une base de données fictive :
            // _context.EmailQueue.Add(new EmailRecord { To = email, Subject = subject, Message = htmlMessage });
            // await _context.SaveChangesAsync();

            return Task.CompletedTask;  // Simule l'envoi de l'email
        }
    }
}
