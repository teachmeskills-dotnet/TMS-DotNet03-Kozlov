using ProperNutrition.Common.Enums;
using System;

namespace ProperNutrition.Web.ViewModels
{
    /// <summary>
    /// Ingridient View Model. 
    /// </summary>
    public class IngridientViewModel
    {
        /// <summary>
        /// Ingridient identity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of ingridient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Category of ingridient.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Vegan or Meat.
        /// </summary>
        public bool IsVeggie { get; set; }

        /// <summary>
        /// Description of ingridient.
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
    }
}
