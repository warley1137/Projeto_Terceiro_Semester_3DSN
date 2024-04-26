using System.Collections.Generic;

namespace SK8TOONY.classes.database
{
    public class Usuario
    {
        //Dados Pessoais
        private string nome;
        private string sobrenome;
        private string dataNasc;
        private string genero;
        private string cpf;
        private string telefone;
        private string email;
        private string senha;

        //Endereço
        private List<Endereco> enderecos;

        public Usuario(){}

        public Usuario(string nome, string sobrenome, string dataNasc, string genero, string cpf, string telefone, string email, string senha)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.dataNasc = dataNasc;
            this.genero = genero;
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
            this.senha = senha;
        }

        public string GetNome() { return nome; }
        public string GetSobrenome() {  return sobrenome; }
        public string GetEmail() { return email; }
        public string GetSenha() {  return senha; }
    }
}
