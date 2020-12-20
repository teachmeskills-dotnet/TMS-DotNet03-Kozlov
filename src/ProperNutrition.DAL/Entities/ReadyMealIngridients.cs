using ProperNutrition.Common.Interfaces;

namespace ProperNutrition.DAL.Entities
{
    /// <summary>
    /// Ingridients of ReadyMeal.
    /// </summary>
    public class ReadyMealIngridients : IHasDbIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Weight of ingridients in meal.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// ReadyMealId identifier.
        /// </summary>
        public int ReadyMealId { get; set; }
        /// <summary>
        /// Navigation to ReadyMeal. 
        /// </summary>
        public ReadyMeal ReadyMeal { get; set; }

        /// <summary>
        /// IngridientId identifier.
        /// </summary>
        public int IngridientId { get; set; }

        /// <summary>
        /// Navigation to Ingridient. 
        /// </summary>
        public Ingridient Ingridient { get; set; }
    }
}
