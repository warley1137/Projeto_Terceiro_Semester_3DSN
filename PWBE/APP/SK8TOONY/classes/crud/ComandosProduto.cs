using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using SK8TOONY.classes.database;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SK8TOONY.classes.crud
{
    internal class ComandosProduto
    {
        public List<string> ComandoMostrarCategoiras()
        {
            MySqlConnection connection = ConnectionMySQL.ConectarMySQL(new MySqlConnection());
            List<string> categorias = new List<string>();

            try
            {
                connection.Open();


                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT DISTINCT categoria FROM produto;";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categorias.Add(reader.GetString("categoria"));

                }

                reader.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERRO AO MOSTRAR PRODUTO POR CATEGORIA: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return categorias;
        }

        public List<Produto> ComandoMostrarProdutos(string categoria)
        {
            MySqlConnection connection = ConnectionMySQL.ConectarMySQL(new MySqlConnection());
            List<Produto> produtos = new List<Produto>();

            try
            {
                connection.Open();


                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM produto WHERE categoria = @categoria;";
                command.Parameters.AddWithValue("@categoria", categoria);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    produtos.Add(new Produto(
                        reader.GetInt32("COD"),
                        reader.GetString("SKU"),
                        reader.GetString("NOME"),
                        reader.GetString("MARCA"),
                        reader.GetString("CATEGORIA"),
                        reader.GetString("DESCRICAO"),
                        reader.GetDouble("PRECO"),
                        reader.GetInt32("ESTOQUE")
                    ));
                }

                reader.Close();
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERRO AO MOSTRAR PRODUTO POR CATEGORIA: {ex.Message}");
            }
            finally { 
                connection.Close(); 
            }

            return produtos;
        }

        public int ComandoProdutoCategoria(string categoria)
        {
            MySqlConnection connection = ConnectionMySQL.ConectarMySQL(new MySqlConnection());
            int cod = 0;

            try
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT cod FROM produto WHERE categoria = @categoria;";
                command.Parameters.AddWithValue("@categoria", categoria);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cod = reader.GetInt32("COD");
                }

                reader.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERRO AO PEGAR CÓDIGO DO PRODUTO: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return cod;
        }

        public string ComandoImagemCategoria(string categoria)
        {
            MySqlConnection connection = ConnectionMySQL.ConectarMySQL(new MySqlConnection());
            string imagem = null;

            int cod = ComandoProdutoCategoria(categoria);

            try
            {
                connection.Open();


                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT imagem FROM imagemproduto WHERE produto = @cod;";
                command.Parameters.AddWithValue("@cod", cod);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    imagem = reader.GetString("imagem");
                }

                reader.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERRO AO MOSTRAR IMAGEM: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return imagem;
        }

        public string ComandoMostrarImagem(Produto produto)
        {
            MySqlConnection connection = ConnectionMySQL.ConectarMySQL(new MySqlConnection());
            string imagem = null;

            try
            {
                connection.Open();


                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT imagem FROM imagemproduto WHERE produto = @produto;";
                command.Parameters.AddWithValue("@produto", produto.GetCodigo());

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    imagem = reader.GetString("imagem");
                }

                reader.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERRO AO MOSTRAR IMAGEM: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return imagem;
        }
    }
}
