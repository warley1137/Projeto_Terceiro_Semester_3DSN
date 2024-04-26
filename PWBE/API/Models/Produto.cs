namespace API_Web_SK8TOONY.Models
{
	public class Produto
	{
        //Atributos
        public int _cod { get; set; }
        public String _sku { get; set; }
		public String _nome { get; set; }
		public String _marca { get; set; }
		public String _categoria { get; set; }
		public String _descricao { get; set; }
		public Double _preco { get; set; }
        public int _estoque { get; set; }

        public Produto(int cod, string sku, string nome, string marca, string categoria, string descricao, double preco, int estoque)
		{
			this._cod = cod;
			this._sku = sku;
			this._nome = nome;
			this._marca = marca;
			this._categoria = categoria;
			this._descricao = descricao;
			this._preco = preco;
			this._estoque = estoque;
		}

		//Construtor vazio - utilizado para Serializar a classe (JSON)
		public Produto() { }
	}
}