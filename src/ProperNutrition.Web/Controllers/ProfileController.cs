using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            var profileDtos = await _profileManager.GetProfileAsync(userId);

            var profileViewModels = new List<ProfileViewModels>();
            foreach (var profileDto in profileDtos)
            {
                profileViewModels.Add(new ProfileViewModels
                {
                    Id = profileDto.Id,
                    FirstName = profileDto.FirstName,
                    MiddleName = profileDto.MiddleName,
                    LastName = profileDto.LastName,
                    BirthDate = profileDto.BirthDate,
                    Phone = profileDto.Phone,
                    Telegram = profileDto.Telegram,
                    SocialNetwork = profileDto.SocialNetwork,
                    ProfilePicture = profileDto.ProfilePicture,
                });
            }
            return View(profileViewModels);
        }
#region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfileActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var profileDto = new ProfileDto
                {
                    UserId = userId,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Phone = model.Phone,
                    Telegram = model.Telegram,
                    SocialNetwork = model.SocialNetwork,
                };

                await _profileManager.CreateProfileAsync(profileDto);

                return RedirectToAction("Index", "Profile");
            }
            return View(model);
        }
        #endregion Create

        //[HttpPost]
        //public async Task<IActionResult> SetAvatar(ProfileViewModels model)
        //{
        //    if (model != null)
        //    {
        //        if (model.ProfilePicture != null)
        //        {
        //            byte[] imageData = null;

        //            using (var binaryReader = new BinaryReader(model.ProfilePicture.OpenReadStream()))
        //            {
        //                imageData = binaryReader.ReadBytes((int)model.ProfilePicture.Length);
        //            }

        //            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
        //            var profileDtos = await _profileManager.GetProfileAsync(userId);

        //            var profileViewModels = new List<ProfileViewModels>();
        //            foreach (var profileDto in profileDtos)
        //            {
        //                profileViewModels.Add(new ProfileViewModels
        //                {
        //                    Id = profileDto.Id,
        //                    FirstName = profileDto.FirstName,
        //                    MiddleName = profileDto.MiddleName,
        //                    LastName = profileDto.LastName,
        //                    BirthDate = profileDto.BirthDate,
        //                    Phone = profileDto.Phone,
        //                    Telegram = profileDto.Telegram,
        //                    SocialNetwork = profileDto.SocialNetwork,
        //                    ProfilePicture = profileDto.ProfilePicture,
        //                });
        //            }


        //            profileDtos.ProfilePicture = imageData;
        //            await _profileManager.UpdateProfileAsync(profileDtos);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    throw new ArgumentNullException();
        //}
    }
}
