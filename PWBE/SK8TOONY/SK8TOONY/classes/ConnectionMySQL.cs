using System;
using System.Windows;
using MySql.Data.MySqlClient; // IMPORTAR DO DRIVER MySQL QUE ACABAMOS DE INSTALAR MySQL.Data

namespace SK8TOONY.classes
{
    public class MySqlConnectionManager
    {

        private string connectionString; // GERENCIAR A CONEXÃO COM O BANCO DE DADOS MySQL

        public MySqlConnectionManager(string server, int port, string database, string user, string password)
        {
            connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password};";
        }

        public MySqlConnection CreateConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }

    class ConnectionMySQL
    {
        public static MySqlConnection ConectarMySQL(MySqlConnection connection)
        {
            // CONFIGURAR AS INFORMAÇÕES DE CONEXÃO 
            string server = "ESN509VMYSQL";
            int port = 3306;
            string database = "sk8toony";
            string user = "aluno";
            string password = "Senai1234";

            // CRIA UM INSTÂNCIA DO MySqlConnectionManager COM AS INFORMAÇÕES DE CONEXÃO 
            MySqlConnectionManager connectionManager = new MySqlConnectionManager(server, port, database, user, password);

            try
            {
                // TENTA ABRIR UMA CONEXÃO
                using (connection = connectionManager.CreateConnection())
                {
                    connection.Open();
                    Console.WriteLine("CONECTADO AO BANCO DE DADOS COM SUCESSO!");
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"ERRO NA CONEXÃO: {ex.Message}");
            }

            return connection;
        }

        public void ComandoCadastrarFuncionario(MySqlConnection connection, string nomeFuncionario, double salario, string statusFuncionario)
        {
            try
            {
                string query = "INSERT INTO funcionarios (NOME_FUNCIONARIO, SALARIO_FUNCIONARIO, STATUS_FUNCIONARIO) VALUES (@nomeFuncionario, @salario, @statusFuncionario)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nomeFuncionario", nomeFuncionario);
                command.Parameters.AddWithValue("@salario", salario);
                command.Parameters.AddWithValue("@statusFuncionario", statusFuncionario);
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERRO AO CADASTRAR O FUNCIONÁRIO: {ex.Message}");
            }
        }

        public void ComandoMostrarFuncionarios(MySqlConnection connection)
        {
            try
            {
                string query = "SELECT * FROM funcionarios";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteReader();

                Console.WriteLine(command.ExecuteReader());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERRO AO MOSTRAR OS FUNCIONÁRIO CADASTRADOS: {ex.Message}");
            }
        }
    }
}
