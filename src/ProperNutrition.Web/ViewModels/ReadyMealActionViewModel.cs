using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProperNutrition.Web.ViewModels
{
    public class ReadyMealActionViewModel
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
        /// Name of meal. 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Reaction of child on ready meat.
        /// </summary>
        [Required]
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
        /// Avatar picture.
        /// </summary>
        public byte[] Picture { get; set; }

        /// <summary>
        /// Ready date time.
        /// </summary>
        [Required]
        public DateTime ReadyTime { get; set; }
    }
}
