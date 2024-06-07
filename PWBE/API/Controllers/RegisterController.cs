using API_Web_SK8TOONY.Models;
using APP.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API_Web_SK8TOONY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        //O método que será montado abaixo será chamado via POST
        [HttpPost]
        public IActionResult cadastrar([FromBody] CadastroUsuario usuario)
        {
            int usuarioID = 0;
            MySqlConnection connection = new MySqlConnection(ConnectionDB.stringConnection());

            connection.Open();//Abre a conexão

            MySqlTransaction transation = connection.BeginTransaction();

            try
            {
                using (var cmd = new MySqlCommand("INSERT INTO usuario (Nome, Sobrenome, Username, Genero, DataNasc, CPF) VALUES(@nome, @sobrenome, @username, @genero, @dataNasc, @cpf);", connection))
                {
                    cmd.Parameters.AddWithValue("@nome", usuario._nome);
                    cmd.Parameters.AddWithValue("@sobrenome", usuario._sobrenome);
                    cmd.Parameters.AddWithValue("@username", usuario._username);
                    cmd.Parameters.AddWithValue("@genero", usuario._genero);
                    cmd.Parameters.AddWithValue("@dataNasc", usuario._dataNasc);
                    cmd.Parameters.AddWithValue("@cpf", usuario._cpf);
                    cmd.Transaction = transation;
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", connection))
                {
                    cmd.Transaction = transation;
                    cmd.ExecuteNonQuery();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarioID = reader.GetInt32("LAST_INSERT_ID()");
                    }

                    reader.Close();
                }

                using (var cmd = new MySqlCommand("INSERT INTO membership (Usuario_ID, Email, Telefone) VALUES(@usuarioID, @email, @telefone);", connection))
                {
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioID);
                    cmd.Parameters.AddWithValue("@email", usuario._email);
                    cmd.Parameters.AddWithValue("@telefone", usuario._telefone);
                    cmd.Transaction = transation;
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand("INSERT INTO login (PasswordSalt, PasswordHash, Usuario_ID) VALUES(@passwordSalt, @passwordHash, @usuarioID);", connection))
                {
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                    string[] pwd = EncryptedPassword.Encrypted(usuario._password);

                    cmd.Parameters.AddWithValue("@passwordSalt", pwd[0]);
                    cmd.Parameters.AddWithValue("@passwordHash", pwd[1]);
                    cmd.Transaction = transation;
                    cmd.ExecuteNonQuery();
                }

                transation.Commit();  // Explicitly commit the transaction
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error, rollback transaction)
                transation.Rollback();  // Roll back if an error occurs
                throw;  // Re-throw the exception for further handling
            }


            /*if (sql.ExecuteNonQuery() != 0)//Executar o comando no banco de dados e testar o seu retorno
            {
                connection.Close(); //Fecha a conexão e libera os recursos
                return Ok(produto); //Retorna OK (sucesso) e exibe o usuario cadastrado
            }
            else
            {
                connection.Close();
                return NoContent(); //Retorna em branco (sem conteúdo)
            }*/

            return NoContent();
        }
    }
}
