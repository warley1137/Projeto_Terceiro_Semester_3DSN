using API_Web_SK8TOONY.Models;
using APP.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API_Web_SK8TOONY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [Route("validarLogin")]
        [HttpGet]
        public IActionResult validarLogin(string usernameEmail, string senha)
        {
            Login login = new Login();
            login.verificarUsuario(usernameEmail);

            MySqlConnection connection = new MySqlConnection(ConnectionDB.stringConnection());
            MySqlCommand sql = new MySqlCommand("SELECT usuario.ID, usuario.username, membership.email, login.passwordSalT, login.passwordHash, login.access_token, login.expiration_time FROM usuario " +
                "INNER JOIN membership ON membership.usuario_ID = usuario.ID " +
                "INNER JOIN login ON login.usuario_ID = usuario.ID WHERE usuario.ID = @id;", connection);
            sql.Parameters.AddWithValue("@id", login._id);

            connection.Open();

            MySqlDataReader reader = sql.ExecuteReader();

            while (reader.Read())
            {
                login._username = reader.GetString("username");
                login._email = reader.GetString("email");
                login._passwordSalt = reader.GetString("passwordSalt");
                login._passwordHash = reader.GetString("passwordHash");
                login._accessToken = reader.GetString("access_token");
                login._expirationTime = reader.GetDateTime("expiration_time");
            }

            connection.Close();

            if (login != null) {
                string pwdUsuario = EncryptedPassword.EncryptedNoSalt(senha, login._passwordSalt);

                if (pwdUsuario == login._passwordHash)
                {
                    return Ok(login);
                }
            }

            return NoContent();
        }
    }
}