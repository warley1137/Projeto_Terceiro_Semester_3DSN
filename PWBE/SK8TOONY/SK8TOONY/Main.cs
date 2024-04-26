using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SK8TOONY.paineis;
using SK8TOONY.Panels;

namespace SK8TOONY
{
    public partial class Main : Form
    {
        private static Panel panelAtual;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Controls.Add(panel);
            panelAtual = panel;

            alterarTela(new PainelCategoria() { TopLevel = false });
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            alterarTela(new PainelCategoria() { TopLevel = false });
        }

        private void btnFavorito_Click(object sender, EventArgs e)
        {
            alterarTela(new PainelFavoritos() { TopLevel = false });
        }

        private void btnCarrinho_Click(object sender, EventArgs e)
        {
            alterarTela(new PainelCarrinho() { TopLevel = false });
        }

        public static void alterarTela(Form novoPanel)
        {
            panelAtual.Controls.Clear();
            novoPanel.Location = new Point(0, 0);
            panelAtual.Controls.Add(novoPanel);
            novoPanel.Show();
        }
    }
}