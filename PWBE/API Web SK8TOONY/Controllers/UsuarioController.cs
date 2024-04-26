using API_Web_SK8TOONY.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API_Web_SK8TOONY.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : Controller
	{
		//O método que será montado abaixo será chamado via POST
		[HttpPost]
		public IActionResult cadastrar([FromBody] Usuario usuario)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("INSERT INTO usuario VALUES(null, @nome, @sobrenome, @dataNasc, @genero, @documento, @telefone, @email, @senha, @imagem, null);", connection);
			sql.Parameters.AddWithValue("@nome", usuario._nome);
			sql.Parameters.AddWithValue("@sobrenome", usuario._sobrenome);
			sql.Parameters.AddWithValue("@dataNasc", usuario._dataNasc);
			sql.Parameters.AddWithValue("@genero", usuario._genero);
			sql.Parameters.AddWithValue("@documento", usuario._documento);
			sql.Parameters.AddWithValue("@telefone", usuario._telefone);
			sql.Parameters.AddWithValue("@email", usuario._email);
			sql.Parameters.AddWithValue("@senha", usuario._senha);
			sql.Parameters.AddWithValue("@imagem", usuario._imagem);

			connection.Open();//Abre a conexão

			if (sql.ExecuteNonQuery() != 0)//Executar o comando no banco de dados e testar o seu retorno
			{
				connection.Close(); //Fecha a conexão e libera os recursos
				return Ok(usuario); //Retorna OK (sucesso) e exibe o usuario cadastrado
			}
			else
			{
				connection.Close();
				return NoContent(); //Retorna em branco (sem conteúdo)
			}
		}

		//Método para realizar a remoção de um usuario no banco de dados
		//Ao remover um usuario precisamos do ID, que será passado na URL
		[HttpDelete("{id}")] //Indicação que o método irá receber um valor do ID
		public IActionResult remover(int id)
		{ //Valor que será recebido
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("DELETE FROM usuario WHERE id = @id;", connection);
			sql.Parameters.AddWithValue("@id", id); //Passar o valor do @id
			
			connection.Open(); 
							
			if (sql.ExecuteNonQuery() != 0)
			{
				connection.Close();
				return Ok(new { resposta = "sucesso" });//Retorna o código 200 (Sucesso) com uma mensagem personalizada
			}
			else
			{
				connection.Close();
				return NoContent();
			}
		}

		//Método para atualizar um Usuario. Os dados do usuario serão enviados
		//no corpo (Body) igual no método de cadastrar
		[HttpPut]
		public IActionResult atualizar([FromBody] Usuario usuario)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("UPDATE usuario SET nome = @nome, sobrenome = @sobrenome, dataNasc = @dataNasc, genero = @genero, documento = @documento, telefone = @telefone, email = @email, senha = @senha, imagem = @imagem WHERE id = @id;", connection);
			sql.Parameters.AddWithValue("@nome", usuario._nome);
			sql.Parameters.AddWithValue("@sobrenome", usuario._sobrenome);
			sql.Parameters.AddWithValue("@dataNasc", usuario._dataNasc);
			sql.Parameters.AddWithValue("@genero", usuario._genero);
			sql.Parameters.AddWithValue("@documento", usuario._documento);
			sql.Parameters.AddWithValue("@telefone", usuario._telefone);
			sql.Parameters.AddWithValue("@email", usuario._email);
			sql.Parameters.AddWithValue("@senha", usuario._senha);
			sql.Parameters.AddWithValue("@imagem", usuario._imagem);
			sql.Parameters.AddWithValue("@id", usuario._id);

			connection.Open();

			if (sql.ExecuteNonQuery() != 0)
			{
				connection.Close();
				return Ok(new { result = "sucesso" });
			}
			else
			{
				connection.Close();
				return NoContent();
			}
		}

		//Método para buscar todos os usuários
		[HttpGet]
		public IActionResult buscarTodos()
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("SELECT * FROM usuario;", connection);
			List<Usuario> lista = new List<Usuario>(); //Criar uma lista para receber os usuários cadastrados no banco de dados

			connection.Open();
			
			MySqlDataReader reader = sql.ExecuteReader(); //Criar um objeto do MySqlDataReader para receber os dados
			
			while (reader.Read()) //Percorrer cada resultado do select
			{
				Usuario usuario = new Usuario(
					reader.GetInt32("id"),
					reader.GetString("nome"),
					reader.GetString("sobrenome"),
					reader.GetDateTime("dataNasc"),
					reader.GetString("genero"),
					reader.GetString("documento"),
					reader.GetString("telefone"),
					reader.GetString("email"),
					reader.GetString("senha"),
					reader.GetString("imagem"),
					reader.GetInt16("isOnline"));

				lista.Add(usuario); //Adicionar o usuario na lista
			}

			connection.Close();
			
			return lista.Count == 0 ? NoContent() : Ok(lista); //Retornar NoContent (se estiver vazia) ou OK (se não estiver vazia)
		}

		//Como existem dois métodos usando HttpGet, um deles precisa estar com um
		//caminho/link diferente. Para configurar o link utilizamos o comando Route
		//e atribuímos um nome para a rota. Nesse caso o link ficará:
		//http://localhost:XXXX/api/Usuario/buscarCodigo
		[Route("buscarCodigo")]
		//Método para buscar todos os usuários
		[HttpGet]
		public IActionResult buscarTodos(int id)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("SELECT * FROM usuario WHERE id = @id;", connection);
			sql.Parameters.AddWithValue("@id", id);
			
			Usuario usuario = null; //Criar um objeto Usuario para retornar no final

			connection.Open();
			
			MySqlDataReader reader = sql.ExecuteReader();

			while (reader.Read())
			{
				usuario = new Usuario(
					reader.GetInt32("id"),
					reader.GetString("nome"),
					reader.GetString("sobrenome"),
					reader.GetDateTime("dataNasc"),
					reader.GetString("genero"),
					reader.GetString("documento"),
					reader.GetString("telefone"),
					reader.GetString("email"),
					reader.GetString("senha"),
					reader.GetString("imagem"),
					reader.GetInt16("isOnline"));
			}

			connection.Close();

			return usuario == null ? NoContent() : Ok(usuario);
		}
	}
}
