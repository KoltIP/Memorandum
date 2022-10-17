using Microsoft.AspNetCore.Mvc;

namespace Memorandum.UI.Controllers
{
    [Route("/about")]
    public class AboutController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("About");
        }
    }
}
