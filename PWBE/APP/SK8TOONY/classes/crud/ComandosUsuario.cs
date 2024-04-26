using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace SK8TOONY.classes.crud
{
    public class ComandosUsuario
    {
        public void ComandoCadastrarUsuario(string nome, string sobrenome, string telefone, string documento, string email, string senha, string dataNasc, string genero)
        {
            MySqlConnection connection = ConnectionMySQL.ConectarMySQL(new MySqlConnection());

            try
            {
                connection.Open();


                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO usuario VALUES(@nome, @sobrenome, @telefone, @documento, @email, @senha, @dataNasc, @genero, null);";
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@sobrenome", sobrenome);
                command.Parameters.AddWithValue("@telefone", telefone);
                command.Parameters.AddWithValue("@documento", documento);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                command.Parameters.AddWithValue("@dataNasc", dataNasc);
                command.Parameters.AddWithValue("@genero", genero);
                command.ExecuteNonQuery();

                MessageBox.Show("Usuário cadastrado com sucesso!");
            
            }

            catch (MySqlException ex)
            {
                MessageBox.Show($"ERRO AO CADASTRAR USUÁRIO: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public bool VerificarUsuario(string email, string senha)
        {
            MySqlConnection connection = ConnectionMySQL.ConectarMySQL(new MySqlConnection());

            string dbEmail;
            string dbSenha;


            try
            {
                connection.Open();


                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT email, senha FROM usuario WHERE email = @email;";
                command.Parameters.AddWithValue("@email", email);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dbEmail = reader.GetString("email");
                    dbSenha = reader.GetString("senha");
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado!");
                    return false;
                }

                if (email.ToLower().Equals(dbEmail))
                {
                    if (senha.Equals(dbSenha))
                    {
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado!");
                    return false;
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show($"ERRO AO CADASTRAR USUÁRIO: {ex.Message}");
                return false;

            }
            finally
            {
                connection.Close();
            }

            return true;
        }
    }
}
