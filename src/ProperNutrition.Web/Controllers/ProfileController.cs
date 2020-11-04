using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProperNutrition.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IProfileManager _profileManager;

        public ProfileController(
            IAccountManager accountManager,
            IProfileManager profileManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager)); ;
            _profileManager = profileManager ?? throw new ArgumentNullException(nameof(profileManager)); ;
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var profileDtos = await _profileManager.GetProfilesByUserIdAsync(userId);

            var profileViewModels = new List<ProfileViewModels>();
            foreach (var profileDto in profileDtos)
            {
                profileViewModels.Add(new ProfileViewModels
                {
                    Id = profileDto.Id,
                    FirstName = profileDto.FirstName,
                    LastName = profileDto.LastName,
                    MiddleName = profileDto.MiddleName,
                    BirthDate = profileDto.BirthDate,
                    Phone = profileDto.Phone,
                    Telegram = profileDto.Telegram,
                    SocialNetwork = profileDto.SocialNetwork,
                    ChatId = profileDto.ChatId,
                    SecretKey = profileDto.SecretKey,
                    Created = profileDto.Created,
                });
            }
            return View(profileViewModels);
        }
    }
}
