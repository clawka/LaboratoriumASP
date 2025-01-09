using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Models;

public class AppDbContext : DbContext 
{ 
    public DbSet<ContactEntity> Contacts { get; set; } 
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; } 
    public AppDbContext() 
    { 
        var folder = Environment.SpecialFolder.LocalApplicationData; 
        var path = Environment.GetFolderPath(folder); 
        DbPath = System.IO.Path.Join(path, "contacts.db"); 
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>()
            .HasOne(e => e.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(e => e.OrganizationId);
        
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Title = "WSEI",
                    Nip = "83492384",
                    Regon = "13424234",
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    Title = "Firma",
                    Nip = "2498534",
                    Regon = "0873439249",
                }
            ); ;
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new { City="Krkaow", Street="sw. Filipa", OrganizationEntityId = 101 },
                new { City="Warszawa", Street="Dworcowa 8", OrganizationEntityId = 102 }
            );
        
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Testowich",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "test@test.com",
                    PhoneNumber = "123 456 789",
                    Category = Category.Friend,
                    OrganizationId = 101,
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Test2",
                    LastName = "Testowich2",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "test2@test.com",
                    PhoneNumber = "123 456 789",
                    Category = Category.Business,
                    OrganizationId = 102
                },
                new ContactEntity()
                {
                    Id = 3,
                    FirstName = "Test3",
                    LastName = "Testowich3",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "test3@test.com",
                    PhoneNumber = "123 456 789",
                    Category = Category.Business,
                    OrganizationId = 101,
                });
        
    }
} 