using Org.BouncyCastle.Utilities;

using SK8TOONY.classes.crud;

namespace SK8TOONY.classes.database
{
    public class Produto
    {
        private int cod;
        private string sku;
        private string nome;
        private string marca;
        private string categoria;
        private string descricao;
        private double preco;
        private int estoque;
        private string imagem;

        public Produto(int cod, string sku, string nome, string marca, string categoria, string descricao, double preco, int estoque)
        {
            this.cod = cod;
            this.sku = sku;
            this.nome = nome;
            this.marca = marca;
            this.categoria = categoria;
            this.descricao = descricao;
            this.preco = preco;
            this.estoque = estoque;

            this.imagem = new ComandosProduto().ComandoMostrarImagem(this);
        }


        public int GetCodigo() {  return cod; }
        public string GetNome() {  return nome; }
        public double GetPreco() {  return preco; }
        public string GetImagem() { return imagem;}


    }
}
