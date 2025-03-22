using System.ComponentModel.DataAnnotations;

namespace reservation_vols.Models
{
    public class Client:Utilisateur
    {
        
        public string TypeClient { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
