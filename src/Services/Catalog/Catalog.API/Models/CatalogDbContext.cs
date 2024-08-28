using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Models
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options):base(options)
        {
        }

        DbSet<Product> Products { get; set;}
    }
}
