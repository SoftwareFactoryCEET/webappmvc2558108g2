using Microsoft.EntityFrameworkCore;
using sena.cee.adso.WebApplicationMVC01.Models;

namespace sena.cee.adso.WebApplicationMVC01.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API
    }
    //Enfoque Code First (Primero el Código)
    //Mapeamos las clases modelo
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorBiography> AuthorBiographies { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Contract> Contracts { get; set; }
    public DbSet<MobileContract> MobileContracts { get; set; }
    public DbSet<TvContract> TvContracts { get; set; }
    public DbSet<BroadBandContract> BroadBandContracts { get; set; }


}