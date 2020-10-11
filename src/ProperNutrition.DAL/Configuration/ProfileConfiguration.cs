using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Common.Constants;
using ProperNutrition.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProperNutrition.DAL.Configuration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profiles")
                .HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);
            
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(p => p.MiddleName)
                .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(p => p.BirthDate)
                .IsRequired()
                .HasColumnType(ConfigurationConstants.DateFormat);
            
            builder.Property(p => p.Phone)
                .HasMaxLength(ConfigurationConstants.ShotLenghtSimvbol);

            builder.Property(p => p.Telegram)
                .HasMaxLength(ConfigurationConstants.ShotLenghtSimvbol);

            builder.Property(p => p.SocialNetwork)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.SmallLenghtSimvbol);

            builder.Property(p => p.ChatId)
                .HasMaxLength(ConfigurationConstants.MaxLenghtSimvbol);

            builder.Property(p => p.SecretKey)
                .IsRequired()
                .HasMaxLength(ConfigurationConstants.MiddLenghtSimvbol);

            builder.HasOne(p => p.User)
                .WithOne(i => i.Profile)
                .HasForeignKey<Profile>(p => p.UserId);   
        }
    }
}
