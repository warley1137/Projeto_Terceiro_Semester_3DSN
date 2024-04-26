using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using SK8TOONY.classes.database;
using SK8TOONY.classes;

namespace SK8TOONY.objetos
{
    public partial class ObjProduto : Form
    {
        private Produto produto;

        public ObjProduto(Produto produto)
        {
            InitializeComponent();
            this.produto = produto;
        }

        private void ObjProduto_Load(object sender, EventArgs e)
        {
            nome.Text = produto.GetNome();
            preco.Text = "R$ " + produto.GetPreco().ToString("0.00");
            Console.WriteLine(produto.GetImagem());

            try
            {
                imagem.Image = new ConversorImagem().Base64ToImage(produto.GetImagem());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao exibir imagem: Produto {produto.GetNome()} \n {ex.Message}");
            }
        }
    }
}
