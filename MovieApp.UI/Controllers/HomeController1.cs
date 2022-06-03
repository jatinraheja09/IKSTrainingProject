using Microsoft.AspNetCore.Mvc;

namespace MovieApp.UI.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
