namespace API_Web_SK8TOONY.Models
{
	public class Endereco
	{
        //Atributos
        public int _id { get; set; }
        public String _nome { get; set; }
        public String _cep { get; set; }
		public String _rua { get; set; }
        public String _numero { get; set; }
        public String _bairro { get; set; }
        public String _cidade { get; set; }
        public String _uf { get; set; }
        public String _complemento { get; set; }

		public Endereco(int id, string nome, string cep, string rua, string numero, string bairro, string cidade, string uf, string complemento)
		{
			this._id = id;
			this._nome = nome;
			this._cep = cep;
			this._rua = rua;
			this._numero = numero;
			this._bairro = bairro;
			this._cidade = cidade;
			this._uf = uf;
			this._complemento = complemento;
		}

		//Construtor vazio - utilizado para Serializar a classe (JSON)
		public Endereco() { }
	}
}
