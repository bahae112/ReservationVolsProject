using System.ComponentModel.DataAnnotations.Schema;

namespace reservation_vols.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Etat { get; set; } = "en cours";

        public string clientId { get; set; }
        public int volId { get; set; }
        [ForeignKey("clientId")]
        public Utilisateur utilisateur { get; set; }
        [ForeignKey("volId")]
        public Vol vol { get; set; }

    }
}
