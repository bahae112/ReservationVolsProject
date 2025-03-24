using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace reservation_vols.Models
{
    public class Utilisateur:IdentityUser
    {

        //[Required]
        public string? Nom { get; set; }

        //[Required]
        public string? Prenom { get; set; }

        //[Required]
        public string? CIN { get; set; }
        //client
        public List<Reservation> Reservations { get; set; }

        //gestionnaire
        public string Code { get; set; } = null;
        public DateOnly anneeRecrutement { get; set; } 

        //role
        public string Role = "client";




    }
}
