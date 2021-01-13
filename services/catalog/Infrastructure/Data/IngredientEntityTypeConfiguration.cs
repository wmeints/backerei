using Backerei.Catalog.Domain.Aggregates.PieAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backerei.Catalog.Infrastructure.Data
{
    public class IngredientEntityTypeConfiguration: IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        }
    }
}