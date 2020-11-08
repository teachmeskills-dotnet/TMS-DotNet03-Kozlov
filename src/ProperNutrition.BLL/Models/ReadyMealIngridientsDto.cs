namespace ProperNutrition.BLL.Models
{
    /// <summary>
    /// ReadyMealIngridients data transfer object.
    /// </summary>
    class ReadyMealIngridientsDto
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
        /// IngridientId identifier.
        /// </summary>
        public int IngridientId { get; set; }
    }
}
