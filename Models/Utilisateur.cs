using Microsoft.AspNetCore.Identity;

namespace reservation_vols.Models
{
    public class Utilisateur:IdentityUser
    {
        
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CIN { get; set; }
    }
}
