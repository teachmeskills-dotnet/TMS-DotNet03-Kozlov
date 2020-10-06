using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProperNutrition.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProperNutrition.DAL.Context
{
    /// <summary>
    /// Proper Nutrition DBase context.
    /// </summary>
    public class ProperNutritionContext : IdentityDbContext<User>
    {
        /// <summary>
        /// COnstructor whith param.
        /// </summary>
        /// <param name="options">Dbase context options.</param>
        public ProperNutritionContext(DbContextOptions<ProperNutritionContext> options)
       : base(options)
        {
        }
    }
}
