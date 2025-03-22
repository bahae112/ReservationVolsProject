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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Gestionnaire> Gestionnaires { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration TPC : chaque classe héritée a sa propre table, sans table `Utilisateur`
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Gestionnaire>().ToTable("Gestionnaires");


        }

    }
}
    
