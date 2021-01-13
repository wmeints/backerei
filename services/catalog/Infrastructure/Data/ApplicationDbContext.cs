using Microsoft.EntityFrameworkCore;

namespace Backerei.Catalog.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CakeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientEntityTypeConfiguration());
        }
    }
}