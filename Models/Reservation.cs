using System.ComponentModel.DataAnnotations.Schema;

namespace reservation_vols.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        // Clé étrangère pour l'utilisateur (Client)
        public string clientId { get; set; }

        // Clé étrangère pour le vol
        public int volId { get; set; }

        // Navigation vers Utilisateur (anciennement Client)
        [ForeignKey("clientId")]
        public Utilisateur client { get; set; }

        // Navigation vers Vol
        [ForeignKey("volId")]
        public Vol vol { get; set; }

        // Statut de la réservation
        public string Statut { get; set; } = "En attente";
    }
}
