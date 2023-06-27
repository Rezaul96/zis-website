using Microsoft.AspNetCore.Mvc;

namespace zayanitsolution.Areas.Website.Controllers
{
    [Area("Website")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
