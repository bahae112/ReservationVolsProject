using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Ajoutez cette ligne pour utiliser Include()
using reservation_vols.Data;
using reservation_vols.Models;
using System.Linq;

namespace reservation_vols.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action pour afficher toutes les réservations avec les relations chargées
        public IActionResult Index()
        {
            var reservations = _context.Reservations
                .Include(r => r.client) // Charge les données du client lié
                .Include(r => r.vol) // Charge les données du vol lié
                .ToList();

            return View(reservations);
        }

        // Action pour confirmer une réservation
        public IActionResult Confirmer(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                reservation.Statut = "Confirmée";  // Mise à jour du statut
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Action pour annuler une réservation
        public IActionResult Annuler(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation != null)
            {
                reservation.Statut = "Annulée";  // Mise à jour du statut
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Action pour afficher les statistiques des réservations
        public IActionResult afficherStatistiques()
        {
            // Récupérer les statistiques
            var totalVols = _context.Vols.Count(); // Nombre total des vols
            var totalReservations = _context.Reservations.Count(); // Nombre total des réservations
            var totalAnnulations = _context.Reservations.Where(r => r.Statut == "Annulée").Count(); // Nombre total des annulations

            // Créer un objet pour passer les données à la vue
            var statistiques = new
            {
                TotalVols = totalVols,
                TotalReservations = totalReservations,
                TotalAnnulations = totalAnnulations
            };

            // Passer les statistiques à la vue
            return View(statistiques);
        }
    }
}
