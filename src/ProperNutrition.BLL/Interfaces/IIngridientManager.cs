using ProperNutrition.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProperNutrition.BLL.Interfaces
{
    /// <summary>
    /// interface manager interface.
    /// </summary>
    public interface IIngridientManager
    {
        /// <summary>
        /// Get ingridient by Id.
        /// </summary>
        /// <param name="Userid">User idetifier.</param>
        /// <returns>Ingridient.</returns>
        public Task<IEnumerable<IngridientDto>> GetIngridientsByUserIdAsync(string Userid);
    }
}
