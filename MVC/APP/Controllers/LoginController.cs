using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
