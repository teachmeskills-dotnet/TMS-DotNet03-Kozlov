using ProperNutrition.BLL.Models;
using System.Collections.Generic;
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
        public Task<IEnumerable<ProfileDto>> GetProfileAsync(string Userid);

        /// <summary>
        /// Create Profile.
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="userName">Username</param>
        Task CreateProfileAsync(ProfileDto profileDto);

        /// <summary>
        /// Edit profile.
        /// </summary>
        /// <param name="profileDto">Profile DTO</param>
        Task UpdateProfileAsync(ProfileDto profileDto);
    }
}