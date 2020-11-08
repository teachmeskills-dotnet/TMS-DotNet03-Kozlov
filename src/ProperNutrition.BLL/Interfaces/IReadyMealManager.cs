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
        // <summary>
        /// Get ReadyMeal by Id.
        /// </summary>
        /// <param name="Id">Idetifier.</param>
        /// <returns>ReadyMeal.</returns>
        public Task<IEnumerable<ReadyMealDto>> GetReadyMealByIdAsync(string Name);
    }
}
