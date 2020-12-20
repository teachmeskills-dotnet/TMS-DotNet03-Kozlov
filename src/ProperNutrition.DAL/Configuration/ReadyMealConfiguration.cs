using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Common.Constants;
using ProperNutrition.DAL.Entities;
using System;


namespace ProperNutrition.DAL.Configuration
{
    /// <summary>
    /// EF Configuration for Ingridient entity.
    /// </summary>
    public class ReadyMealConfiguration : IEntityTypeConfiguration<ReadyMeal>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<ReadyMeal> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TablesConstants.ReadyMeals, BranchConstants.Food)
                 .HasKey(readyMeal => readyMeal.Id);

            builder.Property(readyMeal => readyMeal.Name)
                 .IsRequired()
                 .HasMaxLength(ConfigurationConstants.MiddLenghtSimvbol);

            builder.Property(readyMeal => readyMeal.ChildReacrion)
                 .IsRequired()
                 .HasMaxLength(ConfigurationConstants.MaxLenghtSimvbol);

            builder.Property(readyMeal => readyMeal.TeastyMeal)
                 .IsRequired()
                 .HasMaxLength(ConfigurationConstants.MiddLenghtSimvbol);

            builder.Property(readyMeal => readyMeal.Comment)
                 .HasMaxLength(ConfigurationConstants.MiddLenghtSimvbol);

            builder.Property(readyMeal => readyMeal.ReadyTime)
                .IsRequired();

            builder.HasMany(readyMeal => readyMeal.ReadyMealIngridients)
                .WithOne(readyMealIngridients => readyMealIngridients.ReadyMeal)
                .HasForeignKey(readyMealIngridients => readyMealIngridients.ReadyMealId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(readyMeal => readyMeal.ApplicationUser)
                   .WithMany(identity => identity.ReadyMeals)
                   .HasForeignKey(readyMeal => readyMeal.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
