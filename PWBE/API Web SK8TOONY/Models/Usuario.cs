namespace API_Web_SK8TOONY.Models
{
	public class Usuario
	{
        //Atributos
        //Dados Pessoais
        public int _id { get; set; }
        public String _nome { get; set; }
        public String _sobrenome { get; set; }
        public DateTime _dataNasc { get; set; }
		public String _genero { get; set; }
		public String _documento { get; set; }
		public String _telefone { get; set; }
		public String _email { get; set; }
		public String _senha { get; set; }
        public String _imagem { get; set; }
        public int _isOnline { get; set; }
        //Endereço
        private List<Endereco> _enderecos { get; set; }

		public Usuario(int id, string nome, string sobrenome, DateTime dataNasc, string genero, string documento, string telefone, string email, string senha, string imagem, int isOnline)
		{
			this._id = id;
			this._nome = nome;
			this._sobrenome = sobrenome;
			this._dataNasc = dataNasc;
			this._genero = genero;
			this._documento = documento;
			this._telefone = telefone;
			this._email = email;
			this._senha = senha;
			this._imagem = imagem;
			this._isOnline = isOnline;
		}

		//Construtor vazio - utilizado para Serializar a classe (JSON)
		public Usuario() { }
	}
}
