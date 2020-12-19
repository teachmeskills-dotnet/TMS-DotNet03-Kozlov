using System.ComponentModel.DataAnnotations;

namespace ProperNutrition.Web.ViewModels
{
    public class IngridientActionViewModel
    {
        /// <summary>
        /// Ingridient identity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Name of ingridient.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Category of ingridient.
        /// </summary>
        [Required]
        public string Category { get; set; }

        /// <summary>
        /// Vegan or Meat.
        /// </summary>
        [Required]
        public bool IsVeggie { get; set; }

        /// <summary>
        /// Description of ingridient.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Reaction.
        /// </summary>
        [Required]
        public int Reaction { get; set; }

        /// <summary>
        /// Number of calories.
        /// </summary>
        public decimal Colories { get; set; }
    }
}
