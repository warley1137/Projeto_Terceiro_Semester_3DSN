namespace SK8TOONY.classes.database
{
    public class Endereco
    {
        private string cep;
        private string rua;
        private string numero;
        private string bairro;
        private string cidade;
        private string uf;
        private string complemento;

        public Endereco(string cep, string rua, string numero, string bairro, string cidade, string uf, string complemento)
        {
            this.cep = cep;
            this.rua = rua;
            this.numero = numero;
            this.bairro = bairro;
            this.cidade = cidade;
            this.uf = uf;
            this.complemento = complemento;
        }
    }
}