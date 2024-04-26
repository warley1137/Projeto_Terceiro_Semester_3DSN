using System;
using System.Windows.Forms;
using SK8TOONY.classes;
using SK8TOONY.classes.crud;
using SK8TOONY.classes.database;
using ViaCep;

namespace SK8TOONY
{
    public partial class Cadastro : Form
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
        private string confSenha;
        //Endereço
        String cep;
        String rua;
        String numero;
        String bairro;
        String cidade;
        String uf;
        String complemento;

        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            cbGenero.Text = "Selecionar";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            nome = tbNome.Text;
            sobrenome = tbSobrenome.Text;
            dataNasc = mtbDataNasc.Text;
            genero = cbGenero.Text;
            cpf = mtbCPF.Text;
            telefone = mtbTelefone.Text;
            email = tbEmail.Text;
            senha = tbSenha.Text;
            confSenha = tbConfSenha.Text;
            cep = mtbCEP.Text;
            rua = tbRua.Text;
            numero = tbNumero.Text;
            bairro = tbBairro.Text;
            cidade = tbCidade.Text;
            uf = tbUF.Text;
            complemento = tbComplemento.Text;


            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(sobrenome) || string.IsNullOrEmpty(dataNasc) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(telefone) || string.IsNullOrEmpty(email) || 
                string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confSenha) || string.IsNullOrEmpty(cep) || string.IsNullOrEmpty(rua) || string.IsNullOrEmpty(numero) || string.IsNullOrEmpty(bairro) ||
                string.IsNullOrEmpty(cidade) || string.IsNullOrEmpty(uf))
            {
                MessageBox.Show("Preencha todos os campos!", "Falha Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!genero.Equals("Selecionar"))
                {
                    if (senha.Equals(confSenha))
                    {
                        String hashSenha = new Encryption().CalculateMD5Hash(senha);
                        string dataValidada = ValidarData(dataNasc);

                        new ComandosUsuario().ComandoCadastrarUsuario(nome, sobrenome, telefone, cpf, email, hashSenha, dataValidada, genero);

                        Program.telaLogin.user = new Usuario(nome, sobrenome, dataNasc, genero, cpf, telefone, email, hashSenha);

                        Program.telaLogin.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("As senhas devem ser iguais!", "Falha Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("Escolha uma das opções de gênero!", "Falha Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
            }
            
        }

        private string ValidarData(string dataNasc)
        {
            string[] data = dataNasc.Split('/');
            return $"{data[2]}-{data[1]}-{data[0]}";
        }

        private void mtbCEP_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mtbCEP.Text))
            {
                cep = mtbCEP.Text.Replace("-", "");

                ViaCepClient buscaEndereco = new ViaCepClient();
                ViaCepResult endereco = buscaEndereco.Search(cep);

                if (endereco != null)
                {
                    tbRua.Text = endereco.Street;
                    tbBairro.Text = endereco.Neighborhood;
                    tbCidade.Text = endereco.City;
                    tbUF.Text = endereco.StateInitials;
                }
                else
                {
                    MessageBox.Show("CEP não encontrado!", "Falha busca CEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido", "Falha busca CEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Program.telaLogin.Show();
            this.Hide();
            
        }
    }
}
