namespace SK8TOONY.objetos
{
    partial class ObjProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjProduto));
            this.preco = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.imagem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.SuspendLayout();
            // 
            // preco
            // 
            this.preco.AutoSize = true;
            this.preco.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.preco.Location = new System.Drawing.Point(10, 210);
            this.preco.Name = "preco";
            this.preco.Size = new System.Drawing.Size(91, 26);
            this.preco.TabIndex = 1;
            this.preco.Text = "PREÇO";
            this.preco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nome
            // 
            this.nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nome.Location = new System.Drawing.Point(10, 250);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(200, 85);
            this.nome.TabIndex = 2;
            this.nome.Text = "NOME - DESCRIÇÃO - CARACTERÍSTICA - INFORMAÇÕES DESNECESSÁRIAS - BLÁ BLÁ BLÁ BLÁ " +
    "BLÁ - SALA MALEIKO - DANTE - RIAS GREMORY";
            this.nome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(70)))), ((int)(((byte)(61)))));
            this.btnComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnComprar.ForeColor = System.Drawing.Color.Transparent;
            this.btnComprar.Location = new System.Drawing.Point(10, 350);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(200, 40);
            this.btnComprar.TabIndex = 3;
            this.btnComprar.Text = "COMPRAR";
            this.btnComprar.UseVisualStyleBackColor = false;
            // 
            // imagem
            // 
            this.imagem.InitialImage = ((System.Drawing.Image)(resources.GetObject("imagem.InitialImage")));
            this.imagem.Location = new System.Drawing.Point(0, 0);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(220, 200);
            this.imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagem.TabIndex = 0;
            this.imagem.TabStop = false;
            // 
            // ObjProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(220, 400);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.preco);
            this.Controls.Add(this.imagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ObjProduto";
            this.Text = "ObjProduto";
            this.Load += new System.EventHandler(this.ObjProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Label preco;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.Button btnComprar;
    }
}