using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reservation_vols.Data;
using reservation_vols.Models;
using reservation_vols.Models.ViewModel;
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
            var vols = await _context.Vols
                .OrderBy(f => f.dateDepart)
                .Select(f => new ListeVols
                {
                    Id = f.Id,
                    depart = f.depart,
                    destination = f.destination,
                    dateDepart = f.dateDepart
                })
                .ToListAsync();

            return View(vols);
        }

        // Recherche de vols selon plusieurs critères
        public async Task<IActionResult> SearchVols(DateTime? date, string depart, string destination)
        {
            var vols = _context.Vols.AsQueryable();

            if (date.HasValue)
            {
                vols = vols.Where(v => v.dateDepart.Date == date.Value.Date);
            }

            if (!string.IsNullOrEmpty(depart))
            {
                vols = vols.Where(v => v.depart.Contains(depart));
            }

            if (!string.IsNullOrEmpty(destination))
            {
                vols = vols.Where(v => v.destination.Contains(destination));
            }

            var result = await vols
                .OrderBy(v => v.dateDepart)
                .Select(v => new ListeVols
                {
                    Id = v.Id,
                    depart = v.depart,
                    destination = v.destination,
                    dateDepart = v.dateDepart
                })
                .ToListAsync();

            return View("Index", result); // Recharge la vue avec les résultats filtrés
        }

        // Détails d'un vol
        public async Task<IActionResult> Details(int id)
        {
            var vol = await _context.Vols.FirstOrDefaultAsync(f => f.Id == id);
            if (vol == null)
            {
                return NotFound();
            }
            return View(vol);
        }

        // Réserver un vol
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ReserverVol(int idVol)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var reservation = new Reservation
            {
                clientId = user.Id,
                volId = idVol
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        // Afficher les réservations par ordre décroissant de la date
        public async Task<IActionResult> AfficherReservations()
        {
            var user = await _userManager.GetUserAsync(User); // Récupérer l'utilisateur connecté

            if (user == null)
            {
                return Unauthorized(); // Si l'utilisateur n'est pas connecté
            }

            var reservations = await _context.Reservations
                .Where(r => r.clientId == user.Id) // Filtrer par utilisateur connecté
                .Include(r=>r.vol) // Inclure les informations du vol
                .OrderByDescending(r => r.vol.dateDepart) // Trier par date de départ du vol (ordre décroissant)
                .ToListAsync();

            return View(reservations);
            
        }

        [HttpGet]
        [Authorize]
        // Afficher les détails d'une réservation
        public async Task<IActionResult> InfosReservation(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.vol) // Inclure les infos du vol
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                
                return NotFound();
            }
           
            return View(reservation);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AnnulerReservation(int id)
        {
            var reservation = _context.Reservations.Find(id);

            if (reservation == null)
            {
                return NotFound();
            }

            // Vérifie si l'état est bien "en cours" avant de supprimer
            if (reservation.Etat == "en cours")
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Utilisateur");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profil()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new ProfilViewModel
            {
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ModifierProfil(ProfilViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Profil", model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            bool emailModifie = false, motDePasseModifie = false;

            // Vérifier si l'email doit être modifié
            if (!string.IsNullOrEmpty(model.Email) && model.Email != user.Email)
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, model.Email);
                var result = await _userManager.ChangeEmailAsync(user, model.Email, token);
                if (result.Succeeded)
                {
                    emailModifie = true;
                }
                else
                {
                    TempData["Error"] = "Erreur lors de la mise à jour de l'email.";
                    return RedirectToAction("Profil");
                }
            }

            // Vérifier si le mot de passe doit être modifié
            if (!string.IsNullOrEmpty(model.AncienMotDePasse) && !string.IsNullOrEmpty(model.NouveauMotDePasse))
            {
                var result = await _userManager.ChangePasswordAsync(user, model.AncienMotDePasse, model.NouveauMotDePasse);
                if (result.Succeeded)
                {
                    motDePasseModifie = true;
                }
                else
                {
                    TempData["Error"] = "Ancien mot de passe incorrect ou nouveau mot de passe invalide.";
                    return RedirectToAction("Profil");
                }
            }

            // Rafraîchir la connexion si une modification a eu lieu
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
