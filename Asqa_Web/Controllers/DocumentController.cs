using Microsoft.AspNetCore.Mvc;

namespace Asqa_Web.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
