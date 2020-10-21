using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProperNutrition.DAL.Configuration;
using ProperNutrition.DAL.Entities;
using System;

namespace ProperNutrition.DAL.Context
{
    /// <summary>
    /// Proper Nutrition DBase context.
    /// </summary>
    public class ProperNutritionContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// COnstructor whith param.
        /// </summary>
        /// <param name="options">Dbase context options.</param>
        public ProperNutritionContext(DbContextOptions<ProperNutritionContext> options)
       : base(options)
        {
        }

        /// <summary>
        /// ProperNutrition profiles entities.
        /// </summary>
        public DbSet<Profile> Profiles { get; set; }

        /// <summary>
        /// Ingridients entities.
        /// </summary>
        public DbSet<Ingridient> Ingridients { get; set; }

        /// <summary>
        /// ReadyMeal entities.
        /// </summary>
        public DbSet<ReadyMeal> ReadyMeals { get; set; }

        /// <summary>
        /// ReadyMealIngridients entities.
        /// </summary>
        public DbSet<ReadyMealIngridients> ReadyMealIngridients { get; set; }

        /// <summary>
        /// Users entities.
        /// </summary>
        //public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new IngridientConfiguration());
            modelBuilder.ApplyConfiguration(new ReadyMealConfiguration());
            modelBuilder.ApplyConfiguration(new ReadyMealIngridientsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
