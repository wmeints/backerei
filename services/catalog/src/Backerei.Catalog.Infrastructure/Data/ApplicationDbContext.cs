using System.Diagnostics;
using Backerei.Catalog.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backerei.Catalog.Infrastructure.Data
{
    /// <summary>
    /// Provides a way to access the database from the application.
    /// </summary>
    public class ApplicationDbContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationDbContext"/>
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the cakes dataset.
        /// </summary>
        public DbSet<Cake> Cakes { get; set; }
        
        /// <summary>
        /// Gets or sets the ingredients dataset.
        /// </summary>
        public DbSet<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the categories dataset.
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Make sure that each category is unique.
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            
            // Make sure that each of the ingredients is unique.
            modelBuilder.Entity<Ingredient>().HasIndex(x => x.Name).IsUnique();

            // Make sure that each cake is unique.
            modelBuilder.Entity<Cake>().HasIndex(x => x.Name).IsUnique();
            
            // The serving size we encode as a sub-object of the cake table.
            // It suits value objects really well.
            modelBuilder.Entity<Cake>().OwnsOne(x=> x.Serving);
            
            // The shape is an enumeration object. We're encoding that as a numeric value.
            // We convert unknown sizes to blob shaped cakes here, since we don't know what else to do with it.
            modelBuilder.Entity<Cake>().Property(x => x.Shape).HasConversion(
                x => x.Id, x => CakeShape.FromRawValue(x));

            modelBuilder.Entity<Cake>().Property<byte[]>("Version").IsRowVersion();
            modelBuilder.Entity<Ingredient>().Property<byte[]>("Version").IsRowVersion();
            modelBuilder.Entity<Category>().Property<byte[]>("Version").IsRowVersion();
        }
    }
}