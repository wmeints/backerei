using Backerei.Catalog.Domain.Aggregates.PieAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backerei.Catalog.Infrastructure.Data
{
    public class CakeEntityTypeConfiguration: IEntityTypeConfiguration<Pie>
    {
        public void Configure(EntityTypeBuilder<Pie> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired();
            
            builder.HasMany(x => x.Ingredients);
            
            // Make sure the navigation is accessible through the field.
            builder.Metadata
                .FindNavigation("Ingredients")
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}