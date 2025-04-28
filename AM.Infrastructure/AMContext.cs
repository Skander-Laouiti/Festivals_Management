using Microsoft.EntityFrameworkCore;
using System.Linq;

public class AMContext : DbContext
{
    public DbSet<Artiste> Artistes { get; set; }
    public DbSet<Chanson> Chansons { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Festival> Festivals { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                          Initial Catalog=FestivalDB;
                                          Integrated Security=true;
                                          MultipleActiveResultSets=true");
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Concert>()
            .HasKey(c => new { c.ArtisteFk, c.FestivalFk, c.DateConcert });

        
        modelBuilder.Entity<Concert>()
            .HasOne(c => c.Artiste)
            .WithMany()
            .HasForeignKey(c => c.ArtisteFk);

        
        modelBuilder.Entity<Concert>()
            .HasOne(c => c.Festival)
            .WithMany()
            .HasForeignKey(c => c.FestivalFk);

        
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.ClrType == typeof(string)))
        {
            property.SetMaxLength(50);
        }
    }

}