namespace APP.Models
{
    public class CadastroUsuario
    {
        public string _nome { get; set; }
        public string _sobrenome { get; set; }
        public string _username { get; set; }
        public string _genero { get; set; }
        public string _dataNasc { get; set; }
        public string _cpf { get; set; }
        public string _telefone { get; set; }
        public string _email { get; set; }
        public string _password { get; set; }

        public CadastroUsuario()
        {
        }
    }
}
