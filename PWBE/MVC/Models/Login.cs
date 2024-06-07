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
    }
}
