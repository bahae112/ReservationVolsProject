using Microsoft.AspNetCore.Identity;

namespace reservation_vols.Models
{
    public class Utilisateur:IdentityUser
    {
        //public int Id { get; set; }
        // tous les utilisateurs 
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
        public string Role { get; set; } // "Client" ou "Admin"


        // gestionnaire = admin
        public string? Code { get; set; }
        public DateOnly? anneeRecrutement { get; set; }

        // client 
        public string? TypeClient { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
