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
        /// <param name="UserId">User idetifier.</param>
        /// <param name="ingridientDto">Ingridient data transfer object.</param>
        Task CreateAsync(IngridientDto ingridientDto);

        /// <summary>
        /// Get ingridient by User Idintifier.
        /// </summary>
        /// <param name="Userid">User idetifier.</param>
        /// <returns>List of Ingridient data transfer object.</returns>
        public Task<IEnumerable<IngridientDto>> GetIngridientsAsync (string Userid);



        /// <summary>
        /// Change Ingridient Status.
        /// </summary>
        /// <param name="UserId">User idetifier.</param>
        /// <param name="id">Idetifier.</param>
        Task ChangeIngridientStatusAsync(string UserId, int id);
    }
}
