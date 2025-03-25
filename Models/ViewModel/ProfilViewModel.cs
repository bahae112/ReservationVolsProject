using System.ComponentModel.DataAnnotations;

namespace reservation_vols.Models.ViewModel
{
    
        public class ProfilViewModel
        {
        public string? Email { get; set; } // Peut être null si non modifié
        public string? AncienMotDePasse { get; set; } // Peut être null si non modifié
        public string? NouveauMotDePasse { get; set; } // Peut être null si non modifié
    }
    
}
