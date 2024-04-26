using System;
using System.Windows.Forms;
using SK8TOONY.classes;
using SK8TOONY.classes.crud;
using SK8TOONY.classes.database;


namespace SK8TOONY
{
    public partial class Login : Form
    {
        public Usuario user;

        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            String email = tbLogin.Text;
            String senha = new Encryption().CalculateMD5Hash(tbSenha.Text);

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos!", "Falha Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (new ComandosUsuario().VerificarUsuario(email, senha))
                {

                    Program.telaPrincipal = new Main();
                    Program.telaPrincipal.Visible = true;
                    this.Hide();

                    MessageBox.Show("Login realizado com sucesso!");

                }
                else
                {
                    MessageBox.Show("Login ou senha incorretos!", "Falha Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (Program.telaCadastro == null)
            {
                Program.telaCadastro = new Cadastro();
                Program.telaCadastro.Visible = true;
                this.Hide();
            }
            else
            {
                Program.telaCadastro.Show();
                this.Hide();
            }
            
        }
    }
}
