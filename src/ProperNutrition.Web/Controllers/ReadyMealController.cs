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

        public async Task<IActionResult> Detail(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var readyMealDto = await _readyMealManager.GetReadyMealAsync(id, userId);

            var readyMealViewModel = new ReadyMealViewModels
            {
                Id = readyMealDto.Id,
                Name = readyMealDto.Name,
                ChildReacrion = readyMealDto.ChildReacrion,
                TeastyMeal = readyMealDto.TeastyMeal,
                Comment = readyMealDto.Comment,
                Picture = readyMealDto.Picture,
                ReadyTime = readyMealDto.ReadyTime
            };
            return View(readyMealViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var readyMealDto = await _readyMealManager.GetReadyMealAsync(id, userId);

            var readyMealActionViewModel = new ReadyMealActionViewModel
            {
                Id = readyMealDto.Id,
                UserId = readyMealDto.UserId,
                Name = readyMealDto.Name,
                ChildReacrion = readyMealDto.ChildReacrion,
                TeastyMeal = readyMealDto.TeastyMeal,
                Comment = readyMealDto.Comment,
                Picture = readyMealDto.Picture,
                ReadyTime = readyMealDto.ReadyTime
            };
            return View(readyMealActionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReadyMealActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var readyMealDto = new ReadyMealDto
                {
                    Id = model.Id,
                    UserId = userId,
                    Name = model.Name,
                    ChildReacrion = model.ChildReacrion,
                    TeastyMeal = model.TeastyMeal,
                    Comment = model.Comment,
                    Picture = model.Picture,
                    ReadyTime = model.ReadyTime
                };
                await _readyMealManager.UpdateAsync(readyMealDto);
                return RedirectToAction("Index", "ReadyMeal");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _readyMealManager.DeleteAsync(id, userId);

            return RedirectToAction("Index", "ReadyMeal");
        }
    }
}