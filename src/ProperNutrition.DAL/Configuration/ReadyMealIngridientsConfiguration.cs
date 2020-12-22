using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Common.Constants;
using ProperNutrition.DAL.Entities;
using System;

namespace ProperNutrition.DAL.Configuration
{
    /// <summary>
    /// EF Configuration for Ready Meal Ingridients.
    /// </summary>
    public class ReadyMealIngridientsConfiguration : IEntityTypeConfiguration<ReadyMealIngridients>
    {
        public void Configure(EntityTypeBuilder<ReadyMealIngridients> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TablesConstants.ReadyMealIngridients, BranchConstants.Food)
                  .HasKey(readyMealIngridients => readyMealIngridients.Id);

            builder.Property(readyMealIngridients => readyMealIngridients.Weight);

            //builder.HasMany(readyMealIngridients => readyMealIngridients.)
        }
    }
}