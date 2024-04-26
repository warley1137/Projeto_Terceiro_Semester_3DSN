using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SK8TOONY.classes;

namespace SK8TOONY
{
    public partial class Apresentacao : Form
    {
        public Apresentacao()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            
            if (Program.telaLogin == null) 
            {
                Program.telaLogin = new Login();
                Program.telaLogin.Visible = true;
                this.Hide();
            }
            else
            {
                Program.telaLogin.Show();
                this.Hide();
            }
            
        }
    }
}
