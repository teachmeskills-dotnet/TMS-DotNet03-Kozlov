using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ProperNutrition.Common.Interfaces
{
    /// <summary>
    /// Account manager interface.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Registration.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <returns>IdentityResult.</returns>
        Task<IdentityResult> RegisterAsync(string email, string applicationUserMame, string password);
    }
}
