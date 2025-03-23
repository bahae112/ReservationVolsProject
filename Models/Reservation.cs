using System.ComponentModel.DataAnnotations.Schema;

namespace reservation_vols.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public string clientId { get; set; }
        public int volId { get; set; }
        [ForeignKey("clientId")]
        public Client client { get; set; }
        [ForeignKey("volId")]
        public Vol vol { get; set; }

        public string Statut { get; set; } = "En attente";

    }
}
