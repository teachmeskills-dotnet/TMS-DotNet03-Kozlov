using System.ComponentModel.DataAnnotations;

namespace ProperNutrition.Web.ViewModels
{
    public class IngridientActionViewModel
    {
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
    }
}
