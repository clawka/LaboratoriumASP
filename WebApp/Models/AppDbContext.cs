using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Models;

public class AppDbContext : DbContext 
{ 
    public DbSet<ContactEntity> Contacts { get; set; } 
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
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Testowich",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "test@test.com",
                    PhoneNumber = "123 456 789",
                    Category = Category.Friend
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Test2",
                    LastName = "Testowich2",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "test2@test.com",
                    PhoneNumber = "123 456 789",
                    Category = Category.Business
                },
                new ContactEntity()
                {
                    Id = 3,
                    FirstName = "Test3",
                    LastName = "Testowich3",
                    BirthDate = new DateOnly(2000, 10, 10),
                    Email = "test3@test.com",
                    PhoneNumber = "123 456 789",
                    Category = Category.Business
                });
    }
} 