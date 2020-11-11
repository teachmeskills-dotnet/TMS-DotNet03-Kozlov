using ProperNutrition.Common.Enums;
using ProperNutrition.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// Ingridents.
    /// </summary>
    public class Ingridient : IHasDbIdentity, IHasUserIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string UserId { get; set; }

        /// <summary>
        /// Name of ingridient
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of ingridient
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Vegan or Meat.
        /// </summary>
        public bool IsVeggie { get; set; }

        /// <summary>
        /// Description of ingridient
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Number of calories.
        /// </summary>
        public decimal Colories { get; set; }

        /// <summary>
        /// Recomend.
        /// </summary>
        public bool IsRecomended { get; set; }

        /// <summary>
        /// Reaction.
        /// </summary>
        public ReactionType ReactionType { get; set; }

        /// <summary>
        /// Date of Ingridient.
        /// </summary>
        public DateTime? Date { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Navigation to ReadyMealIngridients
        /// </summary>
        public ICollection<ReadyMealIngridients> ReadyMealIngridients { get; set; }
    }
}
