using API_Web_SK8TOONY.Models;
using APP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APP.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                var url = $"http://localhost:5058/api/Login/validarLogin?usernameEmail={form["email"]}&senha={form["password"]}";

                using (var httpClient = new HttpClient())
                {
                    var content = await httpClient.GetStringAsync(url);

                    if (content != null) 
                    {
                        var login = JsonConvert.DeserializeObject<Login>(content);

                        if (login != null)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        

                    }
                }
            }

            return NoContent();
        }
    }
}
