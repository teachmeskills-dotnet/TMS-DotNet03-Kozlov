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
        /// Sign Up.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="applicationUserMame">User.</param>
        /// <param name="password">Passowrd.</param>
        /// <returns>IdentityResult</returns>
        Task<IdentityResult> SignUpAsync(string email, string applicationUserMame, string password);

        /// <summary>
        /// Get userId by name.
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns>Identifier (GUID)</returns>
        Task<string> GetUserIdByNameAsync(string name);
    }
}
