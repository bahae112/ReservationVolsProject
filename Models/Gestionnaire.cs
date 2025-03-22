using System.ComponentModel.DataAnnotations;

namespace reservation_vols.Models
{
    public class Gestionnaire: Utilisateur
    {
        
        public string Code { get; set; }
        public DateOnly anneeRecrutement { get; set; }

    }
}
