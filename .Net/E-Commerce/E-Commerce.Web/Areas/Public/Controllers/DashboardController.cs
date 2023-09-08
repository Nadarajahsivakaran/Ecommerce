using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.Areas.Public.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
