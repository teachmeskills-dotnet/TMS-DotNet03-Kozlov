using System;

namespace ProperNutrition.Web.ViewModels
{
    public class ReadyMealViewModels
    {
        /// <summary>
        /// Id.
        /// </summary>
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
        /// Avatar picture.
        /// </summary>
        public byte[] Picture { get; set; }

        /// <summary>
        /// Ready date time.
        /// </summary>
        public DateTime ReadyTime { get; set; }
    }
}
