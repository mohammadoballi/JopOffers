using Microsoft.AspNetCore.Mvc;

namespace JopOffers.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
