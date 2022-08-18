namespace Gerador
{
    partial class FormEnviarEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelTexto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCodigoVerde = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonEnviarEmail = new System.Windows.Forms.Button();
            this.textBoxEmailRemetente = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.button1, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelTitulo, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelTexto, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.groupBox1, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.panel2, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.labelEmail, 1, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.898305F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.0678F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.474576F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.050847F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.25424F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.08265F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(417, 265);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(339, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "&OK";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::Gerador.Properties.Resources.WizModernImage;
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 7);
            this.logoPictureBox.Size = new System.Drawing.Size(131, 259);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(143, 0);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTitulo.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(271, 17);
            this.labelTitulo.TabIndex = 19;
            this.labelTitulo.Text = "ATENÇÃO";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTexto
            // 
            this.labelTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexto.Location = new System.Drawing.Point(143, 21);
            this.labelTexto.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTexto.MaximumSize = new System.Drawing.Size(0, 60);
            this.labelTexto.Name = "labelTexto";
            this.labelTexto.Size = new System.Drawing.Size(271, 45);
            this.labelTexto.TabIndex = 0;
            this.labelTexto.Text = "Digite seu email para receber o Direito de Uso";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCodigoVerde);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(140, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 89);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Código-verde";
            // 
            // textBoxCodigoVerde
            // 
            this.textBoxCodigoVerde.BackColor = System.Drawing.Color.GreenYellow;
            this.textBoxCodigoVerde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCodigoVerde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCodigoVerde.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodigoVerde.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBoxCodigoVerde.Location = new System.Drawing.Point(3, 16);
            this.textBoxCodigoVerde.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxCodigoVerde.Multiline = true;
            this.textBoxCodigoVerde.Name = "textBoxCodigoVerde";
            this.textBoxCodigoVerde.ReadOnly = true;
            this.textBoxCodigoVerde.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCodigoVerde.Size = new System.Drawing.Size(268, 70);
            this.textBoxCodigoVerde.TabIndex = 24;
            this.textBoxCodigoVerde.TabStop = false;
            this.textBoxCodigoVerde.Text = "Código-verde";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonEnviarEmail);
            this.panel2.Controls.Add(this.textBoxEmailRemetente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(140, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 30);
            this.panel2.TabIndex = 27;
            // 
            // buttonEnviarEmail
            // 
            this.buttonEnviarEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnviarEmail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonEnviarEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnviarEmail.Location = new System.Drawing.Point(196, 1);
            this.buttonEnviarEmail.Name = "buttonEnviarEmail";
            this.buttonEnviarEmail.Size = new System.Drawing.Size(75, 26);
            this.buttonEnviarEmail.TabIndex = 26;
            this.buttonEnviarEmail.Text = "&Enviar Email";
            this.buttonEnviarEmail.Click += new System.EventHandler(this.buttonEnviarEmail_Click);
            // 
            // textBoxEmailRemetente
            // 
            this.textBoxEmailRemetente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmailRemetente.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmailRemetente.Location = new System.Drawing.Point(3, 3);
            this.textBoxEmailRemetente.Name = "textBoxEmailRemetente";
            this.textBoxEmailRemetente.Size = new System.Drawing.Size(188, 20);
            this.textBoxEmailRemetente.TabIndex = 25;
            // 
            // labelEmail
            // 
            this.labelEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelEmail.Location = new System.Drawing.Point(143, 86);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelEmail.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(271, 17);
            this.labelEmail.TabIndex = 21;
            this.labelEmail.Text = "Digite seu email e clique em enviar email.";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormEnviarEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEnviarEmail";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INFORMAÇÃO IMPORTANTE";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCodigoVerde;
        private System.Windows.Forms.Label labelTexto;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonEnviarEmail;
        private System.Windows.Forms.TextBox textBoxEmailRemetente;
        private System.Windows.Forms.Button button1;
    }
}
