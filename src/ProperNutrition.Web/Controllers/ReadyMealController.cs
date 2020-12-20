using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProperNutrition.Web.Controllers
{
    [Authorize]
    public class ReadyMealController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IReadyMealManager _readyMealManager;

        public ReadyMealController(
            IAccountManager accountManager,
            IReadyMealManager readyMealManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _readyMealManager = readyMealManager ?? throw new ArgumentNullException(nameof(readyMealManager));
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var readymealDtos = await _readyMealManager.GetReadyMealsAsync(userId);

            var readymealViewModels = new List<ReadyMealViewModels>();
            foreach (var readymealDto in readymealDtos)
            {
                readymealViewModels.Add(new ReadyMealViewModels
                {
                    Id = readymealDto.Id,
                    Name = readymealDto.Name,
                    ChildReacrion = readymealDto.ChildReacrion,
                    TeastyMeal = readymealDto.TeastyMeal,
                    Comment = readymealDto.Comment,
                    ReadyTime = readymealDto.ReadyTime,   //TODO: Change type in int
                    Picture = readymealDto.Picture,
                });
            }
            return View(readymealViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReadyMealActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var readyMealDto = new ReadyMealDto
                {
                    UserId = userId,
                    Name = model.Name,
                    ChildReacrion = model.ChildReacrion,
                    TeastyMeal = model.TeastyMeal,
                    Comment = model.Comment,
                    Picture = model.Picture,
                    ReadyTime = model.ReadyTime
                };

                await _readyMealManager.CreateAsync(readyMealDto);

                return RedirectToAction("Index", "ReadyMeal");
            }
            return View(model);
        }
    }
}
