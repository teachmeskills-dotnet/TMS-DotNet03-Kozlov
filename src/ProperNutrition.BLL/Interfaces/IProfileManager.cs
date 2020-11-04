using ProperNutrition.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.BLL.Interfaces
{
    /// <summary>
    /// Interface manager of Profiles.
    /// </summary>
    public interface IProfileManager
    {
        /// <summary>
        /// Get Profiles by Id.
        /// </summary>
        /// <param name="Userid">User idetifier.</param>
        /// <returns>Profiles.</returns>
        public Task<IEnumerable<ProfileDto>> GetProfilesByUserIdAsync(string Userid);
        
    }
}
