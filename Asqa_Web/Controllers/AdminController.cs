using Microsoft.AspNetCore.Mvc;

namespace Asqa_Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
