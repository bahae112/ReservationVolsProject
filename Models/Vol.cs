namespace reservation_vols.Models
{
    public class Vol
    {
        public int Id { get; set; }
        public int nombrePalces { get; set; }
        public string destination { get; set; }
        public string depart { get; set; }
        public DateTime dateDepart { get; set; }
        public DateTime dateArrivee { get; set; }
        public float prix { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
