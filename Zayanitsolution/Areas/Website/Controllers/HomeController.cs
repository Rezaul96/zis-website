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

        [HttpGet("services/erp-solution")]
        public IActionResult Erp()
        {
            return View();
        }

        [HttpGet("services/customizes-software-development")]
        public IActionResult CustomSoftware()
        {
            return View();
        }

        [HttpGet("services/website-development")]
        public IActionResult WebsiteDevlopment()
        {
            return View();
        }

        [HttpGet("services/mobile-app-development")]
        public IActionResult MobileAppDevelopment()
        {
            return View();
        }

        [HttpGet("services/ecommerce-platfrom-development")]
        public IActionResult Ecommerce()
        {
            return View();
        }

        [HttpGet("services/it-consultation")]
        public IActionResult ITConsultation()
        {
            return View();
        }

        [HttpGet("product/erp")]
        public IActionResult ProductErp()
        {
            return View();
        }


        [HttpGet("product/smart-business")]
        public IActionResult ProductSmartBusiness()
        {
            return View();
        }


        [HttpGet("product/accounting")]
        public IActionResult ProductAccounting()
        {
            return View();
        }


        [HttpGet("product/ecommerce")]
        public IActionResult ProductECommerce()
        {
            return View();
        }

        [HttpGet("aboutus")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
