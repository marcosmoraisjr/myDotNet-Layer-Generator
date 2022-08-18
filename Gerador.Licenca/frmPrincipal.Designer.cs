namespace Gerador.Licenca
{
    partial class frmPrincipal
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtaExpirar = new System.Windows.Forms.DateTimePicker();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalvar = new System.Windows.Forms.ToolStripButton();
            this.btnImportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGenerateHash = new System.Windows.Forms.Button();
            this.lblHashProvider = new System.Windows.Forms.Label();
            this.cboHashProvider = new System.Windows.Forms.ComboBox();
            this.rdoFileStream = new System.Windows.Forms.RadioButton();
            this.rdoTextPlain = new System.Windows.Forms.RadioButton();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtHashTextPlain = new System.Windows.Forms.TextBox();
            this.textBoxNomeAplicacao = new System.Windows.Forms.TextBox();
            this.labelNomeAplicacao = new System.Windows.Forms.Label();
            this.btnTraduzirCodigoVerde = new System.Windows.Forms.Button();
            this.lblCryptProvider = new System.Windows.Forms.Label();
            this.cboCryptProvider = new System.Windows.Forms.ComboBox();
            this.txtCodigoVerde = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(448, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 369);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.grpResult);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 343);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Criptografar...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxNomeAplicacao);
            this.groupBox2.Controls.Add(this.labelNomeAplicacao);
            this.groupBox2.Controls.Add(this.btnTraduzirCodigoVerde);
            this.groupBox2.Controls.Add(this.lblCryptProvider);
            this.groupBox2.Controls.Add(this.cboCryptProvider);
            this.groupBox2.Controls.Add(this.txtCodigoVerde);
            this.groupBox2.Controls.Add(this.lblKey);
            this.groupBox2.Controls.Add(this.btnEncrypt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtaInicial);
            this.groupBox2.Controls.Add(this.dtaExpirar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox2.Location = new System.Drawing.Point(9, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 225);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(409, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "até:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(213, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "de:";
            // 
            // dtaInicial
            // 
            this.dtaInicial.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaInicial.Location = new System.Drawing.Point(216, 42);
            this.dtaInicial.Name = "dtaInicial";
            this.dtaInicial.Size = new System.Drawing.Size(147, 29);
            this.dtaInicial.TabIndex = 24;
            // 
            // dtaExpirar
            // 
            this.dtaExpirar.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtaExpirar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtaExpirar.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtaExpirar.Location = new System.Drawing.Point(412, 42);
            this.dtaExpirar.Name = "dtaExpirar";
            this.dtaExpirar.Size = new System.Drawing.Size(137, 29);
            this.dtaExpirar.TabIndex = 14;
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.toolStrip1);
            this.grpResult.Controls.Add(this.txtResult);
            this.grpResult.Location = new System.Drawing.Point(6, 240);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(571, 97);
            this.grpResult.TabIndex = 13;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Licença gerada";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnSalvar,
            this.btnImportar,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(565, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(42, 22);
            this.btnSalvar.Text = "Salvar";
            // 
            // btnImportar
            // 
            this.btnImportar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(37, 22);
            this.btnImportar.Text = "Abrir";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Maroon;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(299, 22);
            this.toolStripLabel1.Text = "Obs: a licença expira ao termino do período de validade";
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.PeachPuff;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Location = new System.Drawing.Point(3, 44);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(565, 47);
            this.txtResult.TabIndex = 11;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnDecrypt);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 343);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Descriptografar...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(6, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 84);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Período de validade do aplicativo:";
            this.groupBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(179, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "até:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "de:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(182, 49);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(147, 29);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(147, 29);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(557, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 29);
            this.button1.TabIndex = 22;
            this.button1.Text = "LER";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Contra-senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Método criptográfico";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(480, 212);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(106, 35);
            this.btnDecrypt.TabIndex = 15;
            this.btnDecrypt.Text = "Descriptografar";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(252, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 78);
            this.textBox1.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(252, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(335, 32);
            this.comboBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.GreenYellow;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(252, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(299, 29);
            this.textBox2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Código verde";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGenerateHash);
            this.tabPage3.Controls.Add(this.lblHashProvider);
            this.tabPage3.Controls.Add(this.cboHashProvider);
            this.tabPage3.Controls.Add(this.rdoFileStream);
            this.tabPage3.Controls.Add(this.rdoTextPlain);
            this.tabPage3.Controls.Add(this.btnSelectFile);
            this.tabPage3.Controls.Add(this.txtHashTextPlain);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(600, 343);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Gerador Hash";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGenerateHash
            // 
            this.btnGenerateHash.Location = new System.Drawing.Point(334, 201);
            this.btnGenerateHash.Name = "btnGenerateHash";
            this.btnGenerateHash.Size = new System.Drawing.Size(107, 23);
            this.btnGenerateHash.TabIndex = 16;
            this.btnGenerateHash.Text = "Gerar Hash";
            this.btnGenerateHash.UseVisualStyleBackColor = true;
            // 
            // lblHashProvider
            // 
            this.lblHashProvider.AutoSize = true;
            this.lblHashProvider.Location = new System.Drawing.Point(142, 158);
            this.lblHashProvider.Name = "lblHashProvider";
            this.lblHashProvider.Size = new System.Drawing.Size(74, 13);
            this.lblHashProvider.TabIndex = 15;
            this.lblHashProvider.Text = "Hash Provider";
            // 
            // cboHashProvider
            // 
            this.cboHashProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHashProvider.FormattingEnabled = true;
            this.cboHashProvider.Location = new System.Drawing.Point(145, 174);
            this.cboHashProvider.Name = "cboHashProvider";
            this.cboHashProvider.Size = new System.Drawing.Size(296, 21);
            this.cboHashProvider.TabIndex = 14;
            // 
            // rdoFileStream
            // 
            this.rdoFileStream.AutoSize = true;
            this.rdoFileStream.BackColor = System.Drawing.Color.Transparent;
            this.rdoFileStream.Location = new System.Drawing.Point(220, 94);
            this.rdoFileStream.Name = "rdoFileStream";
            this.rdoFileStream.Size = new System.Drawing.Size(61, 17);
            this.rdoFileStream.TabIndex = 13;
            this.rdoFileStream.Text = "Arquivo";
            this.rdoFileStream.UseVisualStyleBackColor = false;
            // 
            // rdoTextPlain
            // 
            this.rdoTextPlain.AutoSize = true;
            this.rdoTextPlain.BackColor = System.Drawing.Color.Transparent;
            this.rdoTextPlain.Checked = true;
            this.rdoTextPlain.Location = new System.Drawing.Point(142, 94);
            this.rdoTextPlain.Name = "rdoTextPlain";
            this.rdoTextPlain.Size = new System.Drawing.Size(52, 17);
            this.rdoTextPlain.TabIndex = 12;
            this.rdoTextPlain.TabStop = true;
            this.rdoTextPlain.Text = "Texto";
            this.rdoTextPlain.UseVisualStyleBackColor = false;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(334, 138);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(107, 23);
            this.btnSelectFile.TabIndex = 11;
            this.btnSelectFile.Text = "Selecionar Arquivo";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // txtHashTextPlain
            // 
            this.txtHashTextPlain.Location = new System.Drawing.Point(145, 112);
            this.txtHashTextPlain.Name = "txtHashTextPlain";
            this.txtHashTextPlain.Size = new System.Drawing.Size(296, 20);
            this.txtHashTextPlain.TabIndex = 3;
            // 
            // textBoxNomeAplicacao
            // 
            this.textBoxNomeAplicacao.BackColor = System.Drawing.Color.White;
            this.textBoxNomeAplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNomeAplicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNomeAplicacao.Location = new System.Drawing.Point(216, 151);
            this.textBoxNomeAplicacao.Name = "textBoxNomeAplicacao";
            this.textBoxNomeAplicacao.Size = new System.Drawing.Size(333, 29);
            this.textBoxNomeAplicacao.TabIndex = 35;
            // 
            // labelNomeAplicacao
            // 
            this.labelNomeAplicacao.AutoSize = true;
            this.labelNomeAplicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeAplicacao.Location = new System.Drawing.Point(31, 156);
            this.labelNomeAplicacao.Name = "labelNomeAplicacao";
            this.labelNomeAplicacao.Size = new System.Drawing.Size(178, 24);
            this.labelNomeAplicacao.TabIndex = 36;
            this.labelNomeAplicacao.Text = "Nome da aplicação:";
            // 
            // btnTraduzirCodigoVerde
            // 
            this.btnTraduzirCodigoVerde.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraduzirCodigoVerde.Location = new System.Drawing.Point(514, 77);
            this.btnTraduzirCodigoVerde.Name = "btnTraduzirCodigoVerde";
            this.btnTraduzirCodigoVerde.Size = new System.Drawing.Size(35, 29);
            this.btnTraduzirCodigoVerde.TabIndex = 34;
            this.btnTraduzirCodigoVerde.Text = "LER";
            this.btnTraduzirCodigoVerde.UseVisualStyleBackColor = true;
            // 
            // lblCryptProvider
            // 
            this.lblCryptProvider.AutoSize = true;
            this.lblCryptProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCryptProvider.Location = new System.Drawing.Point(23, 120);
            this.lblCryptProvider.Name = "lblCryptProvider";
            this.lblCryptProvider.Size = new System.Drawing.Size(186, 24);
            this.lblCryptProvider.TabIndex = 33;
            this.lblCryptProvider.Text = "Método criptográfico:";
            // 
            // cboCryptProvider
            // 
            this.cboCryptProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCryptProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCryptProvider.FormattingEnabled = true;
            this.cboCryptProvider.Location = new System.Drawing.Point(216, 112);
            this.cboCryptProvider.Name = "cboCryptProvider";
            this.cboCryptProvider.Size = new System.Drawing.Size(333, 32);
            this.cboCryptProvider.TabIndex = 32;
            // 
            // txtCodigoVerde
            // 
            this.txtCodigoVerde.BackColor = System.Drawing.Color.GreenYellow;
            this.txtCodigoVerde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoVerde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoVerde.Location = new System.Drawing.Point(216, 77);
            this.txtCodigoVerde.Name = "txtCodigoVerde";
            this.txtCodigoVerde.Size = new System.Drawing.Size(292, 29);
            this.txtCodigoVerde.TabIndex = 29;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(80, 82);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(129, 24);
            this.lblKey.TabIndex = 30;
            this.lblKey.Text = "Código verde:";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(412, 186);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(137, 30);
            this.btnEncrypt.TabIndex = 31;
            this.btnEncrypt.Text = "GERAR LICENÇA";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 24);
            this.label8.TabIndex = 37;
            this.label8.Text = "Período de Validade:";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(96, 22);
            this.toolStripButton1.Text = "Enviar por Email";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtaInicial;
        private System.Windows.Forms.DateTimePicker dtaExpirar;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalvar;
        private System.Windows.Forms.ToolStripButton btnImportar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGenerateHash;
        private System.Windows.Forms.Label lblHashProvider;
        private System.Windows.Forms.ComboBox cboHashProvider;
        private System.Windows.Forms.RadioButton rdoFileStream;
        private System.Windows.Forms.RadioButton rdoTextPlain;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtHashTextPlain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNomeAplicacao;
        private System.Windows.Forms.Label labelNomeAplicacao;
        private System.Windows.Forms.Button btnTraduzirCodigoVerde;
        private System.Windows.Forms.Label lblCryptProvider;
        private System.Windows.Forms.ComboBox cboCryptProvider;
        private System.Windows.Forms.TextBox txtCodigoVerde;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

