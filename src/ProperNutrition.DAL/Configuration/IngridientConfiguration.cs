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
    public class IngridientConfiguration : IEntityTypeConfiguration<Ingridient>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Ingridient> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TablesConstants.Ingridients, BranchConstants.Food)
                   .HasKey(ingridient => ingridient.Id);

            builder.Property(ingridient => ingridient.Name)
                   .IsRequired()
                   .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(ingridient => ingridient.Category)
                   .IsRequired()
                   .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(ingridient => ingridient.IsVeggie)
                   .IsRequired();

            builder.Property(ingridient => ingridient.Description)
                   .HasMaxLength(ConfigurationConstants.MaxLenghtSimvbol);

            builder.Property(ingridient => ingridient.Reaction)
                   .IsRequired();

            builder.HasOne(ingridient => ingridient.ApplicationUser)
                   .WithMany(identity => identity.Ingridients)
                   .HasForeignKey(ingridient => ingridient.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ingridient => ingridient.ReadyMealIngridients)
                   .WithOne(readyMealIngridients => readyMealIngridients.Ingridient)
                   .HasForeignKey(readyMealIngridients => readyMealIngridients.IngridientId)
                   .OnDelete(DeleteBehavior.Restrict);

            //TODO: Are decimal entities has configuration?
        }
    }
}
