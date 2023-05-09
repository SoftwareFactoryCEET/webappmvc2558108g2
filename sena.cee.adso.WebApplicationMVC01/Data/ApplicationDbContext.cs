using Microsoft.EntityFrameworkCore;
using sena.cee.adso.WebApplicationMVC01.Models;

namespace sena.cee.adso.WebApplicationMVC01.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :base(options)
    {
        
    }
    
    //Enfoque Code First (Primero el Código)
    //Mapeamos las clases modelo
    public DbSet<Customer> Customers { get; set; }
}