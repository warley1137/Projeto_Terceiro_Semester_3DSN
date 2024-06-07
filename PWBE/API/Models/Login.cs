using MySql.Data.MySqlClient;

namespace API_Web_SK8TOONY.Models
{
    public class Login
    {
        public int _id { get; set; }
        public string _username { get; set; }
        public string _email { get; set; }
        public string _passwordSalt { get; set; }
        public string _passwordHash { get; set; }
        public string _accessToken { get; set; }
        public DateTime _expirationTime { get; set; }

        public Login(int id, string username, string email, string passwordSalt, string passwordHash, string accessToken, DateTime expirationTime)
        {
            this._id = id;
            this._username = username;
            this._email = email;
            this._passwordSalt = passwordSalt;
            this._passwordHash = passwordHash;
            this._accessToken = accessToken;
            this._expirationTime = expirationTime;
        }

        public Login() { }

        public void verificarUsuario(string usuario)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionDB.stringConnection());
            MySqlCommand sql = new MySqlCommand("SELECT usuario.ID, usuario.username, membership.email FROM usuario " +
                "INNER JOIN membership ON membership.Usuario_ID = usuario.ID WHERE usuario.username = @usuario OR membership.email = @usuario;", connection);
            sql.Parameters.AddWithValue("@usuario", usuario);

            connection.Open();

            MySqlDataReader reader = sql.ExecuteReader();

            while (reader.Read())
            {
                this._id = reader.GetInt32("id");
            }

            connection.Close();
        }
    }
}
