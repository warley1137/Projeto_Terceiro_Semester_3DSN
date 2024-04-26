using API_Web_SK8TOONY.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API_Web_SK8TOONY.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnderecoController : Controller
	{
		//O método que será montado abaixo será chamado via POST
		[HttpPost]
		public IActionResult cadastrar([FromBody] Endereco endereco)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("INSERT INTO endereco VALUES(@id, @nome, @cep, @rua, @numero, @bairro, @cidade, @uf, @complemento);", connection);
			sql.Parameters.AddWithValue("@id", endereco._id);
			sql.Parameters.AddWithValue("@nome", endereco._nome);
			sql.Parameters.AddWithValue("@cep", endereco._cep);
			sql.Parameters.AddWithValue("@rua", endereco._rua);
			sql.Parameters.AddWithValue("@numero", endereco._numero);
			sql.Parameters.AddWithValue("@bairro", endereco._bairro);
			sql.Parameters.AddWithValue("@cidade", endereco._cidade);
			sql.Parameters.AddWithValue("@uf", endereco._uf);
			sql.Parameters.AddWithValue("@complemento", endereco._complemento);

			connection.Open();//Abre a conexão

			if (sql.ExecuteNonQuery() != 0)//Executar o comando no banco de dados e testar o seu retorno
			{
				connection.Close(); //Fecha a conexão e libera os recursos
				return Ok(endereco); //Retorna OK (sucesso) e exibe o usuario cadastrado
			}
			else
			{
				connection.Close();
				return NoContent(); //Retorna em branco (sem conteúdo)
			}
		}

		//Método para realizar a remoção de um endereco no banco de dados
		//Ao remover um endereco precisamos do ID, que será passado na URL
		[HttpDelete("{id}")] //Indicação que o método irá receber um valor do ID
		public IActionResult remover(int id)
		{ //Valor que será recebido
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("DELETE FROM endereco WHERE cod = @cod;", connection);
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

		//Método para atualizar um Endereco. Os dados do endereco serão enviados
		//no corpo (Body) igual no método de cadastrar
		[HttpPut]
		public IActionResult atualizar([FromBody] Endereco endereco)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("UPDATE endereco SET id = @id, nome = @nome, cep = @cep, rua = @rua, numero = @numero, bairro = @bairro, cidade = @cidade, uf = @uf, complemento = @complemento WHERE id = @id;", connection);
			sql.Parameters.AddWithValue("@nome", endereco._nome);
			sql.Parameters.AddWithValue("@cep", endereco._cep);
			sql.Parameters.AddWithValue("@rua", endereco._rua);
			sql.Parameters.AddWithValue("@numero", endereco._numero);
			sql.Parameters.AddWithValue("@bairro", endereco._bairro);
			sql.Parameters.AddWithValue("@cidade", endereco._cidade);
			sql.Parameters.AddWithValue("@uf", endereco._uf);
			sql.Parameters.AddWithValue("@complemento", endereco._complemento);
			sql.Parameters.AddWithValue("@id", endereco._id);

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

		//Método para buscar todos os enderecos
		[HttpGet]
		public IActionResult buscarTodos()
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("SELECT * FROM endereco;", connection);
			List<Endereco> lista = new List<Endereco>(); //Criar uma lista para receber os enderecos cadastrados no banco de dados

			connection.Open();

			MySqlDataReader reader = sql.ExecuteReader(); //Criar um objeto do MySqlDataReader para receber os dados

			while (reader.Read()) //Percorrer cada resultado do select
			{
				Endereco endereco = new Endereco(
					reader.GetInt32("id"),
					reader.GetString("nome"),
					reader.GetString("cep"),
					reader.GetString("rua"),
					reader.GetString("numero"),
					reader.GetString("bairro"),
					reader.GetString("cidade"),
					reader.GetString("uf"),
					reader.GetString("complemento"));

				lista.Add(endereco); //Adicionar o endereco na lista
			}

			connection.Close();

			return lista.Count == 0 ? NoContent() : Ok(lista); //Retornar NoContent (se estiver vazia) ou OK (se não estiver vazia)
		}

		//Como existem dois métodos usando HttpGet, um deles precisa estar com um
		//caminho/link diferente. Para configurar o link utilizamos o comando Route
		//e atribuímos um nome para a rota. Nesse caso o link ficará:
		//http://localhost:XXXX/api/Endereco/buscarCodigo
		[Route("buscarCodigo")]
		//Método para buscar todos os enderecos
		[HttpGet]
		public IActionResult buscarTodos(int id)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("SELECT * FROM endereco WHERE id = @id;", connection);
			sql.Parameters.AddWithValue("@id", id);

			Endereco endereco = null; //Criar um objeto Usuario para retornar no final

			connection.Open();

			MySqlDataReader reader = sql.ExecuteReader();

			while (reader.Read())
			{
				endereco = new Endereco(
					reader.GetInt32("id"),
					reader.GetString("nome"),
					reader.GetString("cep"),
					reader.GetString("rua"),
					reader.GetString("numero"),
					reader.GetString("bairro"),
					reader.GetString("cidade"),
					reader.GetString("uf"),
					reader.GetString("complemento"));
			}

			connection.Close();

			return endereco == null ? NoContent() : Ok(endereco);
		}
	}
}
