using ProperNutrition.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// ReadyMeal.
    /// </summary>
    public class ReadyMeal : IHasDbIdentity, IHasUserIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Name of meal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Reaction of child on ready meat.
        /// </summary>
        public string ChildReacrion { get; set; }

        /// <summary>
        /// Mark of testy meal.
        /// </summary>
        public string TeastyMeal { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Ready date time.
        /// </summary>
        public DateTime ReadyTime { get; set; }

        /// <summary>
        /// Avatar picture.
        /// </summary>
        public byte[] Picture { get; set; }

        /// <inheritdoc/>
        public string UserId { get; set; }

        /// <inheritdoc/>
        public ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Navigation to ReadyMealIngridients
        /// </summary>
        public ICollection<ReadyMealIngridients> ReadyMealIngridients { get; set; }
    }
}