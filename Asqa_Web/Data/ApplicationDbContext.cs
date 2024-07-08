using Asqa_Web.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asqa_Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       

        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Projekten> Projekten  { get; set; }
        public DbSet<Technologie> Technologie { get; set; }
        public DbSet<Ausbildungen> Ausbildungen { get; set; }
        public DbSet<Sprache> Sprache { get; set; }

        public DbSet<Mitarb_Projekt> Mitarb_Projekte { get; set; }

         public DbSet<Ma_Projekt> Ma_Projekte { get; set; }


        public DbSet<Rolle> Rollen { get; set; }
        public DbSet<Taetigkeit> Taetigkeiten { get; set; }

        public DbSet<Kompetenz> Kompetenzen { get; set; }

        public DbSet<Ma_Technologie> Ma_Technologien { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ma_Projekt>()
                .HasOne(mp => mp.Mitarbeiter)
                .WithMany(m => m.Ma_Projekte)
                .HasForeignKey(mp => mp.MitarbeiterId);

            modelBuilder.Entity<Ma_Projekt>()
                .HasOne(mp => mp.Projekten)
                .WithMany(p => p.Ma_Projekte)
                .HasForeignKey(mp => mp.ProjektId);

            base.OnModelCreating(modelBuilder);


            // Seed data
            modelBuilder.Entity<Kompetenz>().HasData(
            new Kompetenz { Id = 1, Komp_name = "Muttersprache" },
            new Kompetenz { Id = 2, Komp_name = "Sehr Gut" },
            new Kompetenz { Id = 3, Komp_name = "Gut" },
            new Kompetenz { Id = 4, Komp_name = "Grundkenntnisse" },
            new Kompetenz { Id = 5, Komp_name = "Fortgeschritten" },
            new Kompetenz { Id = 6, Komp_name = "Expertenkenntnisse" }


            );


        }

    }
}
