using System;
using System.Collections.Generic;
using System.Text;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// ReadyMeal.
    /// </summary>
    public class ReadyMeal
    {
        /// <summary>
        /// Name of meal. 
        /// </summary>
        public string NameMeal { get; set; }

        /// <summary>
        /// Vegan or Meat.
        /// </summary>
        public bool VegMeat { get; set; }

        /// <summary>
        /// Reaction of child on ready meat.
        /// </summary>
        public int ChildReacrion { get; set; }

        /// <summary>
        /// Mark of testy meal.
        /// </summary>
        public int TeastyMeal { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Ready date time.
        /// </summary>
        public DateTime ReadyTime { get; set; }


    }
}
