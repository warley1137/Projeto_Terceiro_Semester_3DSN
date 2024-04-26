using API_Web_SK8TOONY.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API_Web_SK8TOONY.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutoController : Controller
	{
		//O método que será montado abaixo será chamado via POST
		[HttpPost]
		public IActionResult cadastrar([FromBody] Produto produto)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("INSERT INTO produto VALUES(null, @sku, @nome, @marca, @categoria, @descricao, @preco, @estoque);", connection);
			sql.Parameters.AddWithValue("@sku", produto._sku);
			sql.Parameters.AddWithValue("@nome", produto._nome);
			sql.Parameters.AddWithValue("@marca", produto._marca);
			sql.Parameters.AddWithValue("@categoria", produto._categoria);
			sql.Parameters.AddWithValue("@descricao", produto._descricao);
			sql.Parameters.AddWithValue("@preco", produto._preco);
			sql.Parameters.AddWithValue("@estoque", produto._estoque);

			connection.Open();//Abre a conexão

			if (sql.ExecuteNonQuery() != 0)//Executar o comando no banco de dados e testar o seu retorno
			{
				connection.Close(); //Fecha a conexão e libera os recursos
				return Ok(produto); //Retorna OK (sucesso) e exibe o usuario cadastrado
			}
			else
			{
				connection.Close();
				return NoContent(); //Retorna em branco (sem conteúdo)
			}
		}

		//Método para realizar a remoção de um produto no banco de dados
		//Ao remover um produto precisamos do cod, que será passado na URL
		[HttpDelete("{id}")] //Indicação que o método irá receber um valor do codigo
		public IActionResult remover(int cod)
		{ //Valor que será recebido
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("DELETE FROM produto WHERE cod = @cod;", connection);
			sql.Parameters.AddWithValue("@cod", cod); //Passar o valor do @cod

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

		//Método para atualizar um Produto. Os dados do produto serão enviados
		//no corpo (Body) igual no método de cadastrar
		[HttpPut]
		public IActionResult atualizar([FromBody] Produto produto)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("UPDATE produto SET sku = @sku, nome = @nome, marca = @marca, categoria = @categoria, descricao = @descricao, preco = @preco, estoque = @estoque WHERE cod = @cod;", connection);
			sql.Parameters.AddWithValue("@sku", produto._sku);
			sql.Parameters.AddWithValue("@nome", produto._nome);
			sql.Parameters.AddWithValue("@marca", produto._marca);
			sql.Parameters.AddWithValue("@categoria", produto._categoria);
			sql.Parameters.AddWithValue("@descricao", produto._descricao);
			sql.Parameters.AddWithValue("@preco", produto._preco);
			sql.Parameters.AddWithValue("@estoque", produto._estoque);
			sql.Parameters.AddWithValue("@cod", produto._cod);

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

		//Método para buscar todos os produtos
		[HttpGet]
		public IActionResult buscarTodos()
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("SELECT * FROM produto;", connection);
			List<Produto> lista = new List<Produto>(); //Criar uma lista para receber os produtos cadastrados no banco de dados

			connection.Open();

			MySqlDataReader reader = sql.ExecuteReader(); //Criar um objeto do MySqlDataReader para receber os dados

			while (reader.Read()) //Percorrer cada resultado do select
			{
				Produto produto = new Produto(
					reader.GetInt32("cod"),
					reader.GetString("sku"),
					reader.GetString("nome"),
					reader.GetString("marca"),
					reader.GetString("categoria"),
					reader.GetString("descricao"),
					reader.GetDouble("preco"),
					reader.GetInt32("estoque"));

				lista.Add(produto); //Adicionar o produto na lista
			}

			connection.Close();

			return lista.Count == 0 ? NoContent() : Ok(lista); //Retornar NoContent (se estiver vazia) ou OK (se não estiver vazia)
		}

		//Como existem dois métodos usando HttpGet, um deles precisa estar com um
		//caminho/link diferente. Para configurar o link utilizamos o comando Route
		//e atribuímos um nome para a rota. Nesse caso o link ficará:
		//http://localhost:XXXX/api/Produto/buscarCodigo
		[Route("buscarCodigo")]
		//Método para buscar todos os produtos
		[HttpGet]
		public IActionResult buscarTodos(int cod)
		{
			MySqlConnection connection = new MySqlConnection("server=ESN509VMYSQL;database=sk8toony;uid=aluno;pwd=Senai1234");
			MySqlCommand sql = new MySqlCommand("SELECT * FROM produto WHERE cod = @cod;", connection);
			sql.Parameters.AddWithValue("@cod", cod);

			Produto produto = null; //Criar um objeto Produto para retornar no final

			connection.Open();

			MySqlDataReader reader = sql.ExecuteReader();

			while (reader.Read())
			{
				produto = new Produto(
					reader.GetInt32("cod"),
					reader.GetString("sku"),
					reader.GetString("nome"),
					reader.GetString("marca"),
					reader.GetString("categoria"),
					reader.GetString("descricao"),
					reader.GetDouble("preco"),
					reader.GetInt32("estoque"));
			}

			connection.Close();

			return produto == null ? NoContent() : Ok(produto);
		}
	}
}
