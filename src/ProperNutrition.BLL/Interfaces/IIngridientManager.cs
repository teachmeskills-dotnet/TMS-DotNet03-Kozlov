using ProperNutrition.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProperNutrition.BLL.Interfaces
{
    /// <summary>
    /// Interface manager of Ingridients.
    /// </summary>
    public interface IIngridientManager
    {
        /// <summary>
        /// Create ingridient async by User Idintifier.
        /// </summary>
        /// <param name="ingridientDto">Ingridient data transfer object.</param>
        Task CreateAsync(IngridientDto ingridientDto);

        /// <summary>
        /// Get ingridient by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Ingridient data transfer objects.</returns>
        Task<IngridientDto> GetIngridientAsync(int id, string userId);

        /// <summary>
        /// Get ingridients by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>List of Ingridients data transfer objects.</returns>
        Task<IEnumerable<IngridientDto>> GetIngridientsAsync(string userId);


        /// <summary>
        /// Delete ingridient by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        Task DeleteAsync(int id, string userId);

        /// <summary>
        /// Change Ingridient Status.
        /// </summary>
        /// <param name="UserId">User idetifier.</param>
        /// <param name="id">Idetifier.</param>
        Task ChangeIngridientStatusAsync(string UserId, int id);

        /// <summary>
        /// Update ingridient by identifier.
        /// </summary>
        /// <param name="ingridientDto">Ingridient data transfer object.</param>
        Task UpdateAsync(IngridientDto ingridientDto);
    }
}
