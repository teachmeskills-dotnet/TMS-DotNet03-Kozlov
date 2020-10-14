using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Common.Constants;
using ProperNutrition.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

            builder.ToTable(TablesConstants.Ingridient, BranchConstants.Food)
                  .HasKey(ingridient => ingridient.Id);

            builder.Property(ingridient => ingridient.NameIngridient)
                  .IsRequired()
                  .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(ingridient => ingridient.Category)
                    .IsRequired()
                    .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(ingridient => ingridient.Description)
                    .HasMaxLength(ConfigurationConstants.MaxLenghtSimvbol);

           builder.Property(ingridient => ingridient.Reaction)
                    .IsRequired()
                    .HasMaxLength(ConfigurationConstants.MaxLenghtSimvbol);

            builder.HasOne(ingridient => ingridient.ApplicationUser)
                .WithMany(identity => identity.Ingridients);

            builder.HasMany(ingridient => ingridient.ReadyMealIngridients)
                .WithOne(readyMealIngridients => readyMealIngridients.Ingridient)
                .HasForeignKey(readyMealIngridients => readyMealIngridients.IngridientId)
                .OnDelete(DeleteBehavior.Restrict);
            //TODO: Are decimal entities has configuration
        }
    }
}
