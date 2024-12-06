using System.Diagnostics;
using DataAccessLayer.Model;
using DTO.Model;
using Medarbejder = DataAccessLayer.Model.Medarbejder;
using Sag = DataAccessLayer.Model.Sag;
using Tidsregistrering = DataAccessLayer.Model.Tidsregistrering;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

internal class TidsregistreringContext : DbContext
{
    public TidsregistreringContext()
    {
        bool created = Database.EnsureCreated();
        if (created)
        {
            Debug.WriteLine("Database Created");
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=SEBASTIAN\\SQLEXPRESS; Database=Tidsregistrering; Integrated Security=True; TrustServerCertificate=True; MultipleActiveResultSets=True");
        optionsBuilder.LogTo(message => Debug.WriteLine(message));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afdeling>().HasData(new Afdeling[] {
            new Afdeling { AfdelingId = 1, Nummer = 10, Navn = "Salg" },
            new Afdeling { AfdelingId = 2, Nummer = 31, Navn = "IT" },
            new Afdeling { AfdelingId = 3, Nummer = 32, Navn = "HR" }
        });

        modelBuilder.Entity<Medarbejder>().HasData(new Medarbejder[] {
            new Medarbejder{MedarbejderId = 1, Initial="AH" ,Navn="Anna Hansen", Cpr = "1234567890", AfdelingId = 1},
            new Medarbejder{MedarbejderId = 2, Initial="PJ" ,Navn="Peter Jensen", Cpr = "0987654321", AfdelingId = 2},
            new Medarbejder{MedarbejderId = 3, Initial="JJ" ,Navn="Jens Jensen", Cpr = "9876543210", AfdelingId = 3},
            new Medarbejder{MedarbejderId = 4, Initial="T" ,Navn="Tully", Cpr = "1234567890", AfdelingId = 1}
        });
        
        modelBuilder.Entity<Sag>().HasData(new Sag[] {
            new Sag { SagId = 1, Overskrift = "Balls", Beskrivelse = "Lav de største boller", AfdelingId = 1}
        });
        
        
        
        modelBuilder.Entity<Afdeling>()
            .HasMany(a => a.Medarbejder)
            .WithOne(m => m.Afdeling)
            .HasForeignKey(m => m.AfdelingId);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tidsregistrering>()
            .HasOne(t => t.Sag)
            .WithMany(s => s.Tidsregistreringer)
            .HasForeignKey(t => t.SagId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    public DbSet<Afdeling> Afdeling { get; set; }
    public DbSet<Medarbejder> Medarbejder { get; set; }
    public DbSet<Sag> Sag { get; set; }
    public DbSet<Tidsregistrering> Tidsregistrering { get; set; }
}