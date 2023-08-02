using Meteor.Service.Share.Interfaces;
using Meteor.Service.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meteor.Service.Shared.Context;

public class SqlServerContext : DbContext, ISqlServerContext
{
    public SqlServerContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Meteorite> Meteors { get; set; }
    public DbSet<MeteorClass> MeteorClasses { get; set; }

    public void SaveContextChanges()
    {
        this.SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Meteor;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meteorite>().HasIndex(m => new { m.Year, m.Name });
        modelBuilder.Entity<Meteorite>().HasIndex(m => m.MeteorClasses);
    }
}