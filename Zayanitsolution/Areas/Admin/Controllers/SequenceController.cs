using Microsoft.AspNetCore.Mvc;

namespace Scorerecord.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SequenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
