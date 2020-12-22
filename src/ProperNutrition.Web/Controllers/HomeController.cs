using Microsoft.AspNetCore.Mvc;

namespace ProperNutrition.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}