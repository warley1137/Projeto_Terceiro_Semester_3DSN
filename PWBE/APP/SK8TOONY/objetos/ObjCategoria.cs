using System;
using System.Windows.Forms;
using SK8TOONY.classes;
using SK8TOONY.classes.crud;
using SK8TOONY.paineis;

namespace SK8TOONY.Panels
{
    public partial class ObjCategoria : Form
    {
        string categoria;

        public ObjCategoria(string categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }

        private void ObjetoCategoria_Load(object sender, EventArgs e)
        {
            btnCategoria.Text = categoria;

            try
            {
                imagem.Image = new ConversorImagem().Base64ToImage(new ComandosProduto().ComandoImagemCategoria(categoria));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao exibir imagem: Produto {categoria} \n {ex.Message}");
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Main.alterarTela(new PainelProdutos(categoria) { TopLevel = false });
        }
    }
}
