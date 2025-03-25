using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reservation_vols.Data;
using reservation_vols.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace reservation_vols.Controllers
{
    // Assure que seuls les utilisateurs connectés peuvent accéder au contrôleur
    public class UtilisateurController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UtilisateurController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Liste des vols disponibles
        public async Task<IActionResult> Index()
        {
            var vols = await _context.Vols.OrderBy(f => f.dateDepart).ToListAsync();
            return View(vols);
        }

        // Recherche de vols selon plusieurs critères
        public async Task<IActionResult> SearchVols(DateTime? date, string depart, string destination)
        {
            var vols = _context.Vols.AsQueryable();

            if (date.HasValue)
                vols = vols.Where(v => v.dateDepart.Date == date.Value.Date);

            if (!string.IsNullOrEmpty(depart))
                vols = vols.Where(v => v.départ.Contains(depart));

            if (!string.IsNullOrEmpty(destination))
                vols = vols.Where(v => v.destination.Contains(destination));

            var result = await vols.OrderBy(v => v.dateDepart).ToListAsync();
            return View("Index", result);
        }

        // Détails d'un vol
        public async Task<IActionResult> Details(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
                return NotFound();

            return View(vol);
        }


        
        // Réserver un vol
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ReserverVol(int idVol)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var reservation = new Reservation
            {
                clientId = user.Id,
                volId = idVol,
                Statut = "En attente"
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AfficherReservations()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var reservations = await _context.Reservations
                .Where(r => r.clientId == user.Id)
                .Include(r => r.vol)
                .OrderByDescending(r => r.vol.dateDepart)
                .ToListAsync();

            return View(reservations);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> InfosReservation(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.vol)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
                return NotFound();

            return View(reservation);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AnnulerReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
                return NotFound();

            if (reservation.Statut == "En attente")
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Utilisateur");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profil()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ModifierProfil(string email, string ancienMotDePasse, string nouveauMotDePasse)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            bool emailModifie = false, motDePasseModifie = false;

            if (!string.IsNullOrEmpty(email) && email != user.Email)
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, email);
                var result = await _userManager.ChangeEmailAsync(user, email, token);
                if (result.Succeeded)
                    emailModifie = true;
                else
                {
                    TempData["Error"] = "Erreur lors de la mise à jour de l'email.";
                    return RedirectToAction("Profil");
                }
            }

            if (!string.IsNullOrEmpty(ancienMotDePasse) && !string.IsNullOrEmpty(nouveauMotDePasse))
            {
                var result = await _userManager.ChangePasswordAsync(user, ancienMotDePasse, nouveauMotDePasse);
                if (result.Succeeded)
                    motDePasseModifie = true;
                else
                {
                    TempData["Error"] = "Ancien mot de passe incorrect ou nouveau mot de passe invalide.";
                    return RedirectToAction("Profil");
                }
            }

            if (emailModifie || motDePasseModifie)
            {
                await _signInManager.RefreshSignInAsync(user);
                TempData["Message"] = "Profil mis à jour avec succès !";
            }
            else
            {
                TempData["Error"] = "Aucune modification détectée.";
            }

            return RedirectToAction("Profil");
        }
    }
}