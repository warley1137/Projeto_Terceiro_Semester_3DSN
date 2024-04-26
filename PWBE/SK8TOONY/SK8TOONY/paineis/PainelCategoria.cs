using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SK8TOONY.Panels;
using SK8TOONY.classes.crud;
using System.Collections.Generic;

namespace SK8TOONY.paineis
{
    public partial class PainelCategoria : Form
    {
        private List<string> categorias;

        public PainelCategoria()
        {
            InitializeComponent();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            categorias = new ComandosProduto().ComandoMostrarCategoiras();

            if (categorias.Count > 0)
            {
                int positionX = 60;
                int positionY = 0;
                foreach (string categoria in categorias)
                {
                    if (positionX > 922)
                    {
                        positionX = 60;
                        positionY += 300;
                    }

                    ObjCategoria item = new ObjCategoria(categoria) { TopLevel = false };
                    item.Location = new Point(positionX, 20 + positionY);
                    this.Controls.Add(item);
                    item.Show();

                    positionX += 285;
                }
            }
        }
    }
}
