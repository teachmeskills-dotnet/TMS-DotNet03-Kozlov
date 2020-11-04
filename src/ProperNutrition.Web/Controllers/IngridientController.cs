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
            var ingridientDtos = await _ingridientManager.GetIngridientsByUserIdAsync(userId);

            var ingridientViewModels = new List<IngridientViewModel>();
            foreach (var ingridientDto in ingridientDtos)
            {
                ingridientViewModels.Add(new IngridientViewModel
                {
                    Id = ingridientDto.Id,
                    NameIngridient = ingridientDto.NameIngridient,
                    Category = ingridientDto.Category,
                    Description = ingridientDto.Description,
                    Colories = ingridientDto.Colories,
                    IsRecomended = ingridientDto.IsRecomended,
                    Reaction = ingridientDto.Reaction,
                    IngridientDate = ingridientDto.IngridientDate
                });
            }
            return View(ingridientViewModels);
        }
    }
}
