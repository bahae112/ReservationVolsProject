using reservation_vols.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace reservation_vols.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Gestionnaire> Gestionnaires { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration TPC : chaque classe héritée a sa propre table
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Gestionnaire>().ToTable("Gestionnaires");

            // Insertion de données initiales pour la table Vols
            modelBuilder.Entity<Vol>().HasData(
                new Vol
                {
                    Id = 1,
                    nombrePalces = 150,
                    destination = "Paris",
                    départ = "Casablanca",
                    dateDepart = new DateTime(2024, 08, 15, 14, 30, 00),
                    dateArrivee = new DateTime(2024, 08, 15, 18, 00, 00),
                    prix = 1200
                },
                new Vol
                {
                    Id = 2,
                    nombrePalces = 200,
                    destination = "New York",
                    départ = "Marrakech",
                    dateDepart = new DateTime(2024, 09, 10, 08, 00, 00),
                    dateArrivee = new DateTime(2024, 09, 10, 16, 00, 00),
                    prix = 4500
                }
            );

            

            // Insertion de données initiales pour les Réservations (commentée)
            //modelBuilder.Entity<Reservation>().HasData(
            //    new Reservation
            //    {
            //        Id = 1,
            //        clientId = "C1",
            //        volId = 1
            //    },
            //    new Reservation
            //    {
            //        Id = 2,
            //        clientId = "C2",
            //        volId = 2
            //    }
            //);
        }
    }
}
