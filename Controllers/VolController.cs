using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using reservation_vols.Data;
using reservation_vols.Models;

namespace reservation_vols.Controllers
{
    public class VolController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VolController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize (Roles = "Admin")]

        public IActionResult Index()
        {
            List<Vol> volList = _db.Vols.ToList();
            return View(volList);
        }

        //[Authorize]

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        [Authorize(Roles = "Admin")]
        public IActionResult Create(Vol vol)
        {
            Console.WriteLine($"Vol reçu: Id = {vol.Id}, Nombre Places = {vol.nombrePalces}, Destination = {vol.destination}, Départ = {vol.départ}, Date Départ = {vol.dateDepart}, Date Arrivée = {vol.dateArrivee}, Prix = {vol.prix}");

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState)
                {
                    foreach (var subError in error.Value.Errors)
                    {
                        Console.WriteLine($"Erreur de validation sur {error.Key}: {subError.ErrorMessage}");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                _db.Vols.Add(vol);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vol);
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Vol vol = _db.Vols.Find(id);
            if (vol == null)
            {
                return NotFound();
            }

            return View(vol);
        }

        [HttpPost]

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Vol vol)
        {
            if (ModelState.IsValid)
            {
                _db.Vols.Update(vol);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vol);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Vol vol = _db.Vols.Find(id);
            if (vol == null)
            {
                return NotFound();
            }

            return View(vol);
        }


        [HttpPost, ActionName("Delete")]

        [Authorize(Roles = "Admin")]
        public IActionResult DeletePost(int? id)
        {
            Vol vol = _db.Vols.Find(id);
            if (vol == null)
            {
                return NotFound();
            }

            _db.Vols.Remove(vol);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //[Authorize(Roles = "Admin")]
        public IActionResult RechercherVolsMulticriteres(string depart, string destination, DateTime? dateDepart, DateTime? dateArrivee, float? prixMin, float? prixMax, int? places)
        {
            var vols = _db.Vols.AsQueryable(); // Récupérer tous les vols

            if (!string.IsNullOrEmpty(depart))
                vols = vols.Where(v => v.départ.Contains(depart));

            if (!string.IsNullOrEmpty(destination))
                vols = vols.Where(v => v.destination.Contains(destination));

            if (dateDepart.HasValue)
                vols = vols.Where(v => v.dateDepart.Date == dateDepart.Value.Date);

            if (dateArrivee.HasValue)
                vols = vols.Where(v => v.dateArrivee.Date == dateArrivee.Value.Date);

            if (prixMin.HasValue)
                vols = vols.Where(v => v.prix >= prixMin.Value);

            if (prixMax.HasValue)
                vols = vols.Where(v => v.prix <= prixMax.Value);

            if (places.HasValue)
                vols = vols.Where(v => v.nombrePalces == places.Value);

            return View("Index", vols.ToList());
        }

        public IActionResult Contacts()
        {
            return View();
        }

        //public IActionResult afficherStatistiques()
        //{
        //    var totalVols = _context.Vols.Count();
        //    var totalReservations = _context.Reservations.Count();

        //    // Supposons qu'une annulation est une réservation supprimée
        //    var totalAnnulations = _context.Reservations.Where(r => r.clientId == null).Count();

        //    var stats = new
        //    {
        //        TotalVols = totalVols,
        //        TotalReservations = totalReservations,
        //        TotalAnnulations = totalAnnulations
        //    };

        //    return View(stats);
        //}



    }
}
