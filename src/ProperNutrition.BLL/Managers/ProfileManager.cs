using Microsoft.EntityFrameworkCore;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
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

        public async Task CreateProfileAsync(ProfileDto profileDto)
        {
            var profile = new Profile
            {
                Id = profileDto.Id,
                UserId = profileDto.UserId,
                FirstName = profileDto.FirstName,
                LastName = profileDto.LastName,
                MiddleName = profileDto.MiddleName,
                BirthDate = profileDto.BirthDate,
                Phone = profileDto.Phone,
                Telegram = profileDto.Telegram,
                SocialNetwork = profileDto.SocialNetwork,
                ProfilePicture = profileDto.ProfilePicture,
            };
            //Create new model
            await _repositoryProfile.CreateAsync(profile);
            //Save new model in DataBase
            await _repositoryProfile.SaveChangesAsync();
        }

        public async Task<ProfileDto> GetProfileAsync(int id, string userId)
        {
            var profile = await _repositoryProfile
                .GetEntityWithoutTrackingAsync(profile =>
                    profile.Id == id && profile.UserId == userId);

            var profileDto = new ProfileDto
            {
                Id = profile.Id,
                UserId = profile.UserId,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                MiddleName = profile.MiddleName,
                BirthDate = profile.BirthDate,
                Phone = profile.Phone,
                Telegram = profile.Telegram,
                SocialNetwork = profile.SocialNetwork,
                ProfilePicture = profile.ProfilePicture,
            };

            return profileDto;
        }

        public async Task<IEnumerable<ProfileDto>> GetProfileAsync(string userId)
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
                    UserId = profile.UserId,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    MiddleName = profile.MiddleName,
                    BirthDate = profile.BirthDate,
                    Phone = profile.Phone,
                    Telegram = profile.Telegram,
                    SocialNetwork = profile.SocialNetwork,
                    ProfilePicture = profile.ProfilePicture,
                });
            }
            return profilesDtos;
        }

        public async Task UpdateProfileAsync(ProfileDto profileDto)
        {
            if (profileDto != null)
            {
                var userProfile = await _repositoryProfile.GetEntityAsync(pr => pr.UserId == profileDto.UserId);

                static bool ValidateToUpdate(Profile userProfile, ProfileDto profileDto)
                {
                    bool updated = false;

                    if (userProfile.FirstName != profileDto.FirstName && profileDto.FirstName != null)
                    {
                        userProfile.FirstName = profileDto.FirstName;
                        updated = true;
                    }

                    if (userProfile.LastName != profileDto.LastName && profileDto.LastName != null)
                    {
                        userProfile.LastName = profileDto.LastName;
                        updated = true;
                    }

                     if (userProfile.BirthDate != profileDto.BirthDate && profileDto.BirthDate != null)
                    {
                        userProfile.BirthDate = profileDto.BirthDate;
                        updated = true;
                    }

                    if (userProfile.Telegram != profileDto.Telegram && profileDto.Telegram != null)
                    {
                        userProfile.Telegram = profileDto.Telegram;
                        updated = true;
                    }

                    if (userProfile.SocialNetwork != profileDto.SocialNetwork && profileDto.SocialNetwork != null)
                    {
                        userProfile.SocialNetwork = profileDto.SocialNetwork;
                        updated = true;
                    }

                    if (userProfile.ProfilePicture != profileDto.ProfilePicture && profileDto.ProfilePicture != null)
                    {
                        userProfile.ProfilePicture = profileDto.ProfilePicture;
                        updated = true;
                    }

                    return updated;
                }

                var result = ValidateToUpdate(userProfile, profileDto);
                if (result)
                {
                    await _repositoryProfile.SaveChangesAsync();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
