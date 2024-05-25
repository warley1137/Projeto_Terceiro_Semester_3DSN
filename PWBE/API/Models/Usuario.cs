namespace API_Web_SK8TOONY.Models
{
	public class Usuario
	{
        //Atributos
        //Dados Pessoais
        public int _id { get; set; }
        public string _nome { get; set; }
        public string _sobrenome { get; set; }
        public string _username { get; set; }
        public DateTime _dataNasc { get; set; }
		public string _genero { get; set; }
		public string _cpf { get; set; }
        public string? _imagem { get; set; }

		public Usuario(int id, string nome, string sobrenome, string username, string genero, DateTime dataNasc, string cpf, string imagem)
		{
			this._id = id;
			this._nome = nome;
			this._sobrenome = sobrenome;
			this._username = username;
			this._dataNasc = dataNasc;
			this._genero = genero;
			this._cpf = cpf;
			this._imagem = imagem;
		}

		//Construtor vazio - utilizado para Serializar a classe (JSON)
		public Usuario() { }
	}
}
