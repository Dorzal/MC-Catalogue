using Microsoft.EntityFrameworkCore;

namespace Catalogue.Model
{
    public class CatalogueContext : DbContext
    {
        public DbSet<Article> Article { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=toto;");
        }
    }
}
