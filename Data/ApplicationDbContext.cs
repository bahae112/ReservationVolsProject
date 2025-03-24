using reservation_vols.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using reservation_vols.Models;

namespace reservation_vols.Data
{




    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vol>().HasData(
    new Vol
    {
        Id = 1,
        nombrePalces = 150,
        destination = "Paris",
        depart = "Casablanca",
        dateDepart = new DateTime(2025, 04, 15, 08, 30, 00),
        dateArrivee = new DateTime(2025, 04, 15, 12, 00, 00),
        prix = 1200
    },
    new Vol
    {
        Id = 2,
        nombrePalces = 200,
        destination = "New York",
        depart = "Casablanca",
        dateDepart = new DateTime(2025, 05, 10, 14, 00, 00),
        dateArrivee = new DateTime(2025, 05, 10, 23, 45, 00),
        prix = 4500
    },
    new Vol
    {
        Id = 3,
        nombrePalces = 180,
        destination = "Dubai",
        depart = "Marrakech",
        dateDepart = new DateTime(2025, 06, 20, 22, 15, 00),
        dateArrivee = new DateTime(2025, 06, 21, 06, 30, 00),
        prix = 3000
    }
);






        }

    }
}
    
