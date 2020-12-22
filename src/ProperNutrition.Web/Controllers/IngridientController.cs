using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProperNutrition.BLL.Interfaces;
using ProperNutrition.BLL.Models;
using ProperNutrition.Common.Enums;
using ProperNutrition.Common.Extensions;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.Web.Models;
using ProperNutrition.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProperNutrition.Web.Controllers
{
    [Authorize]
    public class IngridientController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IIngridientManager _ingridientManager;

        public IngridientController(
            IAccountManager accountManager,
            IIngridientManager ingridientManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _ingridientManager = ingridientManager ?? throw new ArgumentNullException(nameof(ingridientManager));
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var ingridientDtos = await _ingridientManager.GetIngridientsAsync(userId);

            var ingridientViewModels = new List<IngridientViewModel>();
            foreach (var ingridientDto in ingridientDtos)
            {
                ingridientViewModels.Add(new IngridientViewModel
                {
                    Id = ingridientDto.Id,
                    Name = ingridientDto.Name,
                    Category = ingridientDto.Category,
                    IsVeggie = ingridientDto.IsVeggie,
                    Description = ingridientDto.Description,
                    Colories = ingridientDto.Colories,
                    IsRecomended = ingridientDto.IsRecomended,
                    ReactionType = ingridientDto.ReactionType.ValidateReactionType(),
                    Date = ingridientDto.Date
                });
            }
            return View(ingridientViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GenerateReactionTypeList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IngridientActionViewModel model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var ingridientDto = new IngridientDto
                {
                    UserId = userId,
                    Name = model.Name,
                    Category = model.Category,
                    IsVeggie = model.IsVeggie,
                    Description = model.Description,
                    ReactionType = ReactionTypeExtension.ToReactionType(model.Reaction),
                    Colories = model.Colories,
                    //Date = model.DateTime,
                };

                await _ingridientManager.CreateAsync(ingridientDto);

                return RedirectToAction("Index", "Ingridient");
            }
            GenerateReactionTypeList();
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var ingridientDto = await _ingridientManager.GetIngridientAsync(id, userId);

            var ingridientViewModel = new IngridientViewModel
            {
                Id = ingridientDto.Id,
                Name = ingridientDto.Name,
                Category = ingridientDto.Category,
                IsVeggie = ingridientDto.IsVeggie,
                Description = ingridientDto.Description,
                ReactionType = ingridientDto.ReactionType.ToLocal(),
                Colories = ingridientDto.Colories,
            };
            return View(ingridientViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var ingridientDto = await _ingridientManager.GetIngridientAsync(id, userId);

            var ingridientActionViewModel = new IngridientActionViewModel
            {
                Id = ingridientDto.Id,
                UserId = ingridientDto.UserId,
                Name = ingridientDto.Name,
                Category = ingridientDto.Category,
                IsVeggie = ingridientDto.IsVeggie,
                Description = ingridientDto.Description,
                Reaction = (int)ingridientDto.ReactionType,
                Colories = ingridientDto.Colories,
            };
            GenerateReactionTypeList();
            return View(ingridientActionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IngridientActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var ingridientDto = new IngridientDto
                {
                    Id = model.Id,
                    UserId = userId,
                    Name = model.Name,
                    Category = model.Category,
                    IsVeggie = model.IsVeggie,
                    Description = model.Description,
                    ReactionType = ReactionTypeExtension.ToReactionType(model.Reaction),
                    Colories = model.Colories,
                    //Date = model.DateTime,
                };
                await _ingridientManager.UpdateAsync(ingridientDto);
                return RedirectToAction("Index", "Ingridient");
            }

            GenerateReactionTypeList();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _ingridientManager.DeleteAsync(id, userId);

            return RedirectToAction("Index", "Ingridient");
        }

        [NonAction]
        private void GenerateReactionTypeList()
        {
            IEnumerable<ReactionTypeModel> reactionTypes = new List<ReactionTypeModel>
            {
                new ReactionTypeModel { Id = (int)ReactionType.NoReaction, Type = ReactionType.NoReaction.ToLocal() },
                new ReactionTypeModel { Id = (int)ReactionType.Low, Type = ReactionType.Low.ToLocal() },
                new ReactionTypeModel { Id = (int)ReactionType.Medium, Type = ReactionType.Medium.ToLocal() },
                new ReactionTypeModel { Id = (int)ReactionType.High, Type = ReactionType.High.ToLocal() }
            };

            ViewBag.ReactionTypes = new SelectList(reactionTypes, "Id", "Type");
        }
    }
}