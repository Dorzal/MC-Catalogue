using Microsoft.EntityFrameworkCore;

namespace Catalogue.Model
{
    public class CatalogueContext : DbContext
    {
        public DbSet<Article> Article { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=bdd;User Id=psql_bdd;Password=psql_bdd_password;");
        }
    }
}
