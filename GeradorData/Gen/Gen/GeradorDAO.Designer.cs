namespace Gen
{
    partial class GeradorDAO
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
            this.grupTabelas = new System.Windows.Forms.GroupBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.lstTabelas = new System.Windows.Forms.ListBox();
            this.grupCodigo = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.grupBanco = new System.Windows.Forms.GroupBox();
            this.btnLerBanco = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblString = new System.Windows.Forms.Label();
            this.grupTabelas.SuspendLayout();
            this.grupCodigo.SuspendLayout();
            this.grupBanco.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupTabelas
            // 
            this.grupTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grupTabelas.AutoSize = true;
            this.grupTabelas.Controls.Add(this.btnGerar);
            this.grupTabelas.Controls.Add(this.lstTabelas);
            this.grupTabelas.Location = new System.Drawing.Point(12, 12);
            this.grupTabelas.Name = "grupTabelas";
            this.grupTabelas.Size = new System.Drawing.Size(189, 288);
            this.grupTabelas.TabIndex = 4;
            this.grupTabelas.TabStop = false;
            this.grupTabelas.Text = "Tabelas";
            // 
            // btnGerar
            // 
            this.btnGerar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGerar.Location = new System.Drawing.Point(3, 262);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(183, 23);
            this.btnGerar.TabIndex = 4;
            this.btnGerar.Text = "Gerar DAO >>";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // lstTabelas
            // 
            this.lstTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTabelas.FormattingEnabled = true;
            this.lstTabelas.Location = new System.Drawing.Point(9, 18);
            this.lstTabelas.Name = "lstTabelas";
            this.lstTabelas.Size = new System.Drawing.Size(174, 225);
            this.lstTabelas.TabIndex = 3;
            // 
            // grupCodigo
            // 
            this.grupCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grupCodigo.AutoSize = true;
            this.grupCodigo.Controls.Add(this.txtCodigo);
            this.grupCodigo.Location = new System.Drawing.Point(227, 75);
            this.grupCodigo.Name = "grupCodigo";
            this.grupCodigo.Size = new System.Drawing.Size(490, 222);
            this.grupCodigo.TabIndex = 3;
            this.grupCodigo.TabStop = false;
            this.grupCodigo.Text = "Classes C#";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 19);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(472, 191);
            this.txtCodigo.TabIndex = 0;
            // 
            // grupBanco
            // 
            this.grupBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grupBanco.AutoSize = true;
            this.grupBanco.Controls.Add(this.btnLerBanco);
            this.grupBanco.Controls.Add(this.textBox1);
            this.grupBanco.Controls.Add(this.lblString);
            this.grupBanco.Location = new System.Drawing.Point(222, 12);
            this.grupBanco.Name = "grupBanco";
            this.grupBanco.Size = new System.Drawing.Size(489, 60);
            this.grupBanco.TabIndex = 5;
            this.grupBanco.TabStop = false;
            this.grupBanco.Text = "Banco de Dados";
            // 
            // btnLerBanco
            // 
            this.btnLerBanco.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLerBanco.Location = new System.Drawing.Point(414, 15);
            this.btnLerBanco.Name = "btnLerBanco";
            this.btnLerBanco.Size = new System.Drawing.Size(69, 23);
            this.btnLerBanco.TabIndex = 2;
            this.btnLerBanco.Text = "Ler Banco";
            this.btnLerBanco.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(110, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lblString
            // 
            this.lblString.AutoSize = true;
            this.lblString.Location = new System.Drawing.Point(7, 20);
            this.lblString.Name = "lblString";
            this.lblString.Size = new System.Drawing.Size(97, 13);
            this.lblString.TabIndex = 0;
            this.lblString.Text = "String de Conexão:";
            // 
            // GeradorDAO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(729, 312);
            this.Controls.Add(this.grupBanco);
            this.Controls.Add(this.grupTabelas);
            this.Controls.Add(this.grupCodigo);
            this.Name = "GeradorDAO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GeradorDAO";
            this.grupTabelas.ResumeLayout(false);
            this.grupCodigo.ResumeLayout(false);
            this.grupCodigo.PerformLayout();
            this.grupBanco.ResumeLayout(false);
            this.grupBanco.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grupTabelas;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.ListBox lstTabelas;
        private System.Windows.Forms.GroupBox grupCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox grupBanco;
        private System.Windows.Forms.Button btnLerBanco;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblString;
    }
}