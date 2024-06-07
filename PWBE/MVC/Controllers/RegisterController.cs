using System;
using System.Net.Http;
using System.Text;
using API_Web_SK8TOONY.Models;
using APP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APP.Controllers
{
    public class RegisterController : Controller
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
                CadastroUsuario usuario = new CadastroUsuario();

                usuario._nome = form["firstName"];
                usuario._sobrenome = form["lastName"];
                usuario._username = form["username"];
                usuario._genero = form["gender"];
                usuario._dataNasc = form["date"];
                usuario._cpf = form["cpf"];
                usuario._telefone = form["phone"];
                usuario._email = form["email"];
                usuario._password = form["password"];

                if (usuario._password == form["confpassword"])
                {
                    var url = "http://localhost:5058/api/Register";
                    var usuarioJson = JsonConvert.SerializeObject(usuario);
                    var requestContent = new StringContent(usuarioJson, Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsync(url, requestContent);

                        
                        if (response.Content != null)
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseString);
                        }

                        return RedirectToAction("Index", "Home");

                    }
                }
            }

            return NoContent();
        }
    }
}
