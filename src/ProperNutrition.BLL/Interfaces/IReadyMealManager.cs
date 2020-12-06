using ProperNutrition.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.BLL.Interfaces
{
    /// <summary>
    /// Interface manager of Ready Meal.
    /// </summary>
    public interface IReadyMealManager
    {
        /// <summary>
        /// Create ReadyMeal async.
        /// </summary>
        /// <param name="readyMealDto">ReadyMeal data transfer object.</param>
        /// <returns>ReadyMeal data transfer object.</returns>
        Task CreateReadyMealAsync(ReadyMealDto readyMealDto);

        /// <summary>
        /// Get ReadyMeal by User Idintifier.
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns>List of ReadyMeal data transfer object.</returns>
        public Task<IEnumerable<ReadyMealDto>> GetReadyMealAsync(string Userid);

    }
}
