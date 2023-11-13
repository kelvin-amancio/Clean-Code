using Microsoft.AspNetCore.Mvc;

namespace Clean_Architecture.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
