namespace API_Web_SK8TOONY.Models
{
    public class Login
    {
        public int _id { get; init; }
        public string _usernameEmail { get; set; }
        public string _passwordSalt { get; set; }
        public string _passwordHash { get; set; }
        public string _access_token { get; set; }
        public DateTime _expiration { get; set; }
        public int _userID { get; set; }

        public Login(int id, string usernameEmail, string passwordSalt, string passwordHash, string access_token, DateTime expiration, int userID)
        {
            _id = id;
            _usernameEmail = usernameEmail;
            _passwordSalt = passwordSalt;
            _passwordHash = passwordHash;
            _access_token = access_token;
            _expiration = expiration;
            _userID = userID;
        }
    }
}
