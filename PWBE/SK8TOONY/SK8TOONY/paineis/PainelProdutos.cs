using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SK8TOONY.objetos;
using SK8TOONY.classes.crud;
using SK8TOONY.classes.database;

namespace SK8TOONY.paineis
{
    public partial class PainelProdutos : Form
    {
        private String categoria;
        private List<Produto> produtos;
        private List<ObjProduto> objProdutos;

        public PainelProdutos(String categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }

        private void PainelProdutos_Load(object sender, EventArgs e)
        {
            produtos = new ComandosProduto().ComandoMostrarProdutos(categoria);
            objProdutos = new List<ObjProduto>();

            foreach (Produto produto in produtos)
            {
                objProdutos.Add(new ObjProduto(produto) { TopLevel = false });
            }

            if (objProdutos.Count > 0)
            {
                int positionX = 60;
                int positionY = 0;
                foreach (ObjProduto produto in objProdutos)
                {
                    if (positionX > 922)
                    {
                        positionY += 440;
                        positionX = 60;
                    }

                    produto.Location = new Point(positionX, 20 + positionY);
                    this.Controls.Add(produto);
                    produto.Show();

                    positionX += 287;
                }
            }
        }
    }
}