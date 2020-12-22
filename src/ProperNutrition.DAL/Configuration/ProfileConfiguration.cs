using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Common.Constants;
using ProperNutrition.DAL.Entities;
using System;

namespace ProperNutrition.DAL.Configuration
{
    /// <summary>
    /// EF Configuration for Profile entity.
    /// </summary>
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(TablesConstants.Profiles, BranchConstants.Account)
                   .HasKey(profile => profile.Id);

            builder.Property(profile => profile.FirstName)
                   .IsRequired()
                   .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(profile => profile.LastName)
                   .IsRequired()
                   .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(profile => profile.MiddleName)
                   .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(profile => profile.BirthDate)
                   .IsRequired()
                   .HasColumnType(ConfigurationConstants.DateFormat);

            builder.Property(profile => profile.Phone)
                   .HasMaxLength(ConfigurationConstants.ShotLenghtSimvbol);

            builder.Property(profile => profile.Telegram)
                   .HasMaxLength(ConfigurationConstants.ShotLenghtSimvbol);

            builder.Property(profile => profile.SocialNetwork)
                   .IsRequired()
                   .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.HasOne(profile => profile.User)
                   .WithOne(identity => identity.Profile)
                   .HasForeignKey<Profile>(profile => profile.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}