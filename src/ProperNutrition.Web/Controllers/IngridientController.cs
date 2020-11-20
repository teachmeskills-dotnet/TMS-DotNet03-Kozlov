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

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    IEnumerable<ReactionTypeModel> reactionType = new List<ReactionTypeModel>
        //    {
        //        //new ReactionTypeModel{Id = 0, Type = ReactionType.NoReaction.ToLocal()},
        //        new ReactionTypeModel{Id = 1, Type = ReactionType.Low.ToLocal()},
        //        new ReactionTypeModel{Id = 2, Type = ReactionType.Medium.ToLocal()},
        //        new ReactionTypeModel{Id = 3, Type = ReactionType.High.ToLocal()},
        //        new ReactionTypeModel{Id = 4, Type = ReactionType.Unknown.ToLocal()}
        //    };
        //    ViewBag.ReactionType = new SelectList(reactionType, "Id", "Type");

        //    return View();
        //}

        [HttpGet]
        public IActionResult Create()
        {
            GenerateReactionTypeList();
            return View();
        }





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(IngridientActionViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
        //        var ingridientDto = new IngridientDto
        //        {
        //            Name = model.Name,
        //            Category = model.Category,
        //            IsVeggie = model.IsVeggie,
        //            Description = model.Description,
        //            ReactionType = ReactionTypeExtension.ToReactionType(model.ReactionType)
        //        };

        //        await _ingridientManager.CreateAsync(userId, ingridientDto);

        //        return RedirectToAction("Index", "Ingridient");
        //    }
        //    GeneratePriorityTypeList();
        //    return View(model);
        //}




        [NonAction]
        private void GenerateReactionTypeList()
        {
            IEnumerable<ReactionTypeModel> reactionTypes = new List<ReactionTypeModel>
            {
                new ReactionTypeModel { Id = (int)ReactionType.Low, Type = ReactionType.Low.ToLocal() },
                new ReactionTypeModel { Id = (int)ReactionType.Medium, Type = ReactionType.Medium.ToLocal() },
                new ReactionTypeModel { Id = (int)ReactionType.High, Type = ReactionType.High.ToLocal() }
            };

            ViewBag.ReactionTypes = new SelectList(reactionTypes, "Id", "Type");
        }
    }
}
