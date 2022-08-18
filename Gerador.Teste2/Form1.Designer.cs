namespace Gerador.Teste2
{
    partial class Form1
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
            this.grupBanco = new System.Windows.Forms.GroupBox();
            this.lblConnstring = new System.Windows.Forms.Label();
            this.ckAutentica = new System.Windows.Forms.CheckBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.btnGerarDO = new System.Windows.Forms.Button();
            this.btnLerBanco = new System.Windows.Forms.Button();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.lstTabelas = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();

            this.grupBanco.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupBanco
            // 
            this.grupBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grupBanco.Controls.Add(this.lblConnstring);
            this.grupBanco.Controls.Add(this.ckAutentica);
            this.grupBanco.Controls.Add(this.txtSenha);
            this.grupBanco.Controls.Add(this.label1);
            this.grupBanco.Controls.Add(this.txtUsuario);
            this.grupBanco.Controls.Add(this.lblUsuario);
            this.grupBanco.Controls.Add(this.txtBanco);
            this.grupBanco.Controls.Add(this.lblBanco);
            this.grupBanco.Controls.Add(this.btnGerarDO);
            this.grupBanco.Controls.Add(this.btnLerBanco);
            this.grupBanco.Controls.Add(this.txtServidor);
            this.grupBanco.Controls.Add(this.lblServidor);
            this.grupBanco.Location = new System.Drawing.Point(12, 12);
            this.grupBanco.Name = "grupBanco";
            this.grupBanco.Size = new System.Drawing.Size(558, 127);
            this.grupBanco.TabIndex = 8;
            this.grupBanco.TabStop = false;
            this.grupBanco.Text = "Banco de Dados";
            // 
            // lblConnstring
            // 
            this.lblConnstring.AutoSize = true;
            this.lblConnstring.Location = new System.Drawing.Point(10, 97);
            this.lblConnstring.Name = "lblConnstring";
            this.lblConnstring.Size = new System.Drawing.Size(103, 13);
            this.lblConnstring.TabIndex = 11;
            this.lblConnstring.Text = "String de Conexão:  ";
            // 
            // ckAutentica
            // 
            this.ckAutentica.AutoSize = true;
            this.ckAutentica.Location = new System.Drawing.Point(13, 73);
            this.ckAutentica.Name = "ckAutentica";
            this.ckAutentica.Size = new System.Drawing.Size(161, 17);
            this.ckAutentica.TabIndex = 3;
            this.ckAutentica.Text = "Usar Autenticação Windows";
            this.ckAutentica.UseVisualStyleBackColor = true;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(232, 43);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(100, 20);
            this.txtSenha.TabIndex = 5;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Senha";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(232, 16);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(182, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(61, 43);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(102, 20);
            this.txtBanco.TabIndex = 1;
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(10, 48);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(38, 13);
            this.lblBanco.TabIndex = 4;
            this.lblBanco.Text = "Banco";
            // 
            // btnGerarDO
            // 
            this.btnGerarDO.Location = new System.Drawing.Point(354, 41);
            this.btnGerarDO.Name = "btnGerarDO";
            this.btnGerarDO.Size = new System.Drawing.Size(160, 23);
            this.btnGerarDO.TabIndex = 7;
            this.btnGerarDO.Text = "PREENCHE COMBO";
            this.btnGerarDO.UseVisualStyleBackColor = true;
            this.btnGerarDO.Click += new System.EventHandler(this.btnGerarDO_Click);
            // 
            // btnLerBanco
            // 
            this.btnLerBanco.Location = new System.Drawing.Point(354, 15);
            this.btnLerBanco.Name = "btnLerBanco";
            this.btnLerBanco.Size = new System.Drawing.Size(69, 23);
            this.btnLerBanco.TabIndex = 6;
            this.btnLerBanco.Text = "Ler Banco";
            this.btnLerBanco.UseVisualStyleBackColor = true;
            this.btnLerBanco.Click += new System.EventHandler(this.btnLerBanco_Click);
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(61, 16);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(102, 20);
            this.txtServidor.TabIndex = 0;
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(7, 20);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(46, 13);
            this.lblServidor.TabIndex = 0;
            this.lblServidor.Text = "Servidor";
            // 
            // lstTabelas
            // 
            this.lstTabelas.FormattingEnabled = true;
            this.lstTabelas.Location = new System.Drawing.Point(12, 206);
            this.lstTabelas.Name = "lstTabelas";
            this.lstTabelas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTabelas.Size = new System.Drawing.Size(558, 121);
            this.lstTabelas.Sorted = true;
            this.lstTabelas.TabIndex = 9;
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(12, 145);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(558, 57);
            this.groupBox8.TabIndex = 25;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Selecione ou entre com o nome do Servidor:";
                // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 339);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.grupBanco);
            this.Controls.Add(this.lstTabelas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grupBanco.ResumeLayout(false);
            this.grupBanco.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupBanco;
        private System.Windows.Forms.Label lblConnstring;
        private System.Windows.Forms.CheckBox ckAutentica;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Button btnGerarDO;
        private System.Windows.Forms.Button btnLerBanco;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.ListBox lstTabelas;
        private System.Windows.Forms.GroupBox groupBox8;
       
    }
}

