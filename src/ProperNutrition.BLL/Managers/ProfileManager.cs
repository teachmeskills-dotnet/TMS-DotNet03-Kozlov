using Microsoft.EntityFrameworkCore;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProperNutrition.BLL.Managers
{
    /// <inheritdoc cref="IProfileManager">
    public class ProfileManager : IProfileManager
    {
        private readonly IRepositoryManager<Profile> _repositoryProfile;

        public ProfileManager(IRepositoryManager<Profile> repositoryProfile)
        {
            _repositoryProfile = repositoryProfile ?? throw new ArgumentNullException(nameof(repositoryProfile));
        }

        public async Task<IEnumerable<ProfileDto>> GetProfilesByUserIdAsync(string userId)
        {
            var profiles = await _repositoryProfile
                .GetAll()
                .AsNoTracking()
                .Where(profiles => profiles.UserId == userId)
                .ToListAsync();
            var profilesDtos = new List<ProfileDto>();

            foreach (var profile in profiles)
            {
                profilesDtos.Add(new ProfileDto
                {
                    Id = profile.Id,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    MiddleName = profile.MiddleName,
                    BirthDate = profile.BirthDate,
                    Phone = profile.Phone,
                    Telegram = profile.Telegram,
                    SocialNetwork = profile.SocialNetwork,
                    Avatar = profile.ProfilePicture,
                });
            }
            return profilesDtos;
        }
    }
}
