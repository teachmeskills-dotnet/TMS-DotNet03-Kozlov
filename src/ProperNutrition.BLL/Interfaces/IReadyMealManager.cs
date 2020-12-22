using ProperNutrition.BLL.Models;
using System.Collections.Generic;
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
        Task CreateAsync(ReadyMealDto readyMealDto);

        /// <summary>
        /// Get ReadyMeal by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>ReadyMeal data transfer objects.</returns>
        Task<ReadyMealDto> GetReadyMealAsync(int id, string userId);

        /// <summary>
        /// Get Ready Meal by User Idintifier.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of ReadyMeal data transfer object.</returns>
        public Task<IEnumerable<ReadyMealDto>> GetReadyMealsAsync(string userId);

        /// <summary>
        /// Delete Ready Meal by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        Task DeleteAsync(int id, string userId);

        /// <summary>
        /// Change Ready Meal Status.
        /// </summary>
        /// <param name="UserId">User idetifier.</param>
        /// <param name="id">Idetifier.</param>
        Task ChangeReadyMealStatusAsync(string UserId, int id);

        /// <summary>
        /// Update Ready Meal by identifier.
        /// </summary>
        /// <param name="readyMealDto">Ready Meal data transfer object.</param>
        Task UpdateAsync(ReadyMealDto readyMealDto);
    }
}