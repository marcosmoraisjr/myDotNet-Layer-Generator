namespace Gerador
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            this.grupTabelas = new System.Windows.Forms.GroupBox();
            this.ListBoxTabelas = new System.Windows.Forms.ListBox();
            this.textBoxNamespace = new System.Windows.Forms.TextBox();
            this.buttonGerarBLL = new System.Windows.Forms.Button();
            this.buttonGerarTAB = new System.Windows.Forms.Button();
            this.grupCodigo = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAbrir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSalvar = new System.Windows.Forms.ToolStripButton();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.grupBanco = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cboServidor = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.ckAutentica = new System.Windows.Forms.CheckBox();
            this.lblConnstring = new System.Windows.Forms.Label();
            this.buttonGerarDALConexao = new System.Windows.Forms.Button();
            this.buttonGerarDALpersistencias = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grupTabelas.SuspendLayout();
            this.grupCodigo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grupBanco.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupTabelas
            // 
            this.grupTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grupTabelas.Controls.Add(this.ListBoxTabelas);
            this.grupTabelas.ForeColor = System.Drawing.Color.Black;
            this.grupTabelas.Location = new System.Drawing.Point(12, 77);
            this.grupTabelas.Name = "grupTabelas";
            this.grupTabelas.Size = new System.Drawing.Size(204, 359);
            this.grupTabelas.TabIndex = 4;
            this.grupTabelas.TabStop = false;
            this.grupTabelas.Text = "3 - Tabelas";
            // 
            // ListBoxTabelas
            // 
            this.ListBoxTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxTabelas.BackColor = System.Drawing.SystemColors.Info;
            this.ListBoxTabelas.FormattingEnabled = true;
            this.ListBoxTabelas.Location = new System.Drawing.Point(9, 23);
            this.ListBoxTabelas.Name = "ListBoxTabelas";
            this.ListBoxTabelas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxTabelas.Size = new System.Drawing.Size(189, 329);
            this.ListBoxTabelas.Sorted = true;
            this.ListBoxTabelas.TabIndex = 0;
            // 
            // textBoxNamespace
            // 
            this.textBoxNamespace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxNamespace.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxNamespace.Location = new System.Drawing.Point(9, 17);
            this.textBoxNamespace.Name = "textBoxNamespace";
            this.textBoxNamespace.Size = new System.Drawing.Size(189, 20);
            this.textBoxNamespace.TabIndex = 0;
            this.textBoxNamespace.Text = "namespace";
            // 
            // buttonGerarBLL
            // 
            this.buttonGerarBLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGerarBLL.Location = new System.Drawing.Point(6, 32);
            this.buttonGerarBLL.Name = "buttonGerarBLL";
            this.buttonGerarBLL.Size = new System.Drawing.Size(190, 32);
            this.buttonGerarBLL.TabIndex = 0;
            this.buttonGerarBLL.Text = "Regras de Negócio";
            this.toolTip1.SetToolTip(this.buttonGerarBLL, "Métodos com as regras do seu negócio.");
            this.buttonGerarBLL.UseVisualStyleBackColor = true;
            this.buttonGerarBLL.Click += new System.EventHandler(this.buttonGerarBLL_Click);
            // 
            // buttonGerarTAB
            // 
            this.buttonGerarTAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGerarTAB.Location = new System.Drawing.Point(6, 32);
            this.buttonGerarTAB.Name = "buttonGerarTAB";
            this.buttonGerarTAB.Size = new System.Drawing.Size(105, 32);
            this.buttonGerarTAB.TabIndex = 0;
            this.buttonGerarTAB.Text = "Entidade";
            this.toolTip1.SetToolTip(this.buttonGerarTAB, "Métodos Get e Set");
            this.buttonGerarTAB.UseVisualStyleBackColor = true;
            this.buttonGerarTAB.Click += new System.EventHandler(this.buttonGerarTAB_Click);
            // 
            // grupCodigo
            // 
            this.grupCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grupCodigo.AutoSize = true;
            this.grupCodigo.Controls.Add(this.toolStrip1);
            this.grupCodigo.Controls.Add(this.txtCodigo);
            this.grupCodigo.Enabled = false;
            this.grupCodigo.Location = new System.Drawing.Point(222, 229);
            this.grupCodigo.Name = "grupCodigo";
            this.grupCodigo.Size = new System.Drawing.Size(560, 207);
            this.grupCodigo.TabIndex = 3;
            this.grupCodigo.TabStop = false;
            this.grupCodigo.Text = "Codigo fonte gerado";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAbrir,
            this.toolStripButtonSalvar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(554, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAbrir
            // 
            this.toolStripButtonAbrir.Image = global::Gerador.Properties.Resources.edge;
            this.toolStripButtonAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbrir.Name = "toolStripButtonAbrir";
            this.toolStripButtonAbrir.Size = new System.Drawing.Size(53, 22);
            this.toolStripButtonAbrir.Text = "Abrir";
            this.toolStripButtonAbrir.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButtonSalvar
            // 
            this.toolStripButtonSalvar.Image = global::Gerador.Properties.Resources.save_alt;
            this.toolStripButtonSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSalvar.Name = "toolStripButtonSalvar";
            this.toolStripButtonSalvar.Size = new System.Drawing.Size(58, 22);
            this.toolStripButtonSalvar.Text = "Salvar";
            this.toolStripButtonSalvar.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.BackColor = System.Drawing.SystemColors.Info;
            this.txtCodigo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(3, 44);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCodigo.Size = new System.Drawing.Size(549, 156);
            this.txtCodigo.TabIndex = 10;
            // 
            // grupBanco
            // 
            this.grupBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grupBanco.Controls.Add(this.button1);
            this.grupBanco.Controls.Add(this.label2);
            this.grupBanco.Controls.Add(this.groupBox8);
            this.grupBanco.Controls.Add(this.groupBox7);
            this.grupBanco.Controls.Add(this.groupBox6);
            this.grupBanco.ForeColor = System.Drawing.Color.Black;
            this.grupBanco.Location = new System.Drawing.Point(222, 27);
            this.grupBanco.Name = "grupBanco";
            this.grupBanco.Size = new System.Drawing.Size(560, 162);
            this.grupBanco.TabIndex = 0;
            this.grupBanco.TabStop = false;
            this.grupBanco.Text = "2 - Banco de Dados SQL Server ";
            this.toolTip1.SetToolTip(this.grupBanco, "Dica: após selecionar uma opção, pressione a tecla <TAB>");
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::Gerador.Properties.Resources.mini_ok;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(322, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 30);
            this.button1.TabIndex = 24;
            this.button1.Text = "       Continuar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.button1, "Clique no botão <continuar> para visualizar as tabelas do banco escolhido");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(409, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 42);
            this.label2.TabIndex = 25;
            this.label2.Text = "Dica: após selecionar uma opção, pressione a tecla <TAB>";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cboServidor);
            this.groupBox8.Controls.Add(this.button3);
            this.groupBox8.Location = new System.Drawing.Point(6, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(310, 75);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "2.1 - Selecione ou entre com o nome do Servidor:";
            this.toolTip1.SetToolTip(this.groupBox8, "Após selecionar sua opção, use a tecla <TAB>");
            // 
            // cboServidor
            // 
            this.cboServidor.BackColor = System.Drawing.SystemColors.Info;
            this.cboServidor.FormattingEnabled = true;
            this.cboServidor.Location = new System.Drawing.Point(6, 26);
            this.cboServidor.Name = "cboServidor";
            this.cboServidor.Size = new System.Drawing.Size(256, 21);
            this.cboServidor.TabIndex = 0;
            this.cboServidor.Leave += new System.EventHandler(this.cboServidor_Leave);
            // 
            // button3
            // 
            this.button3.Image = global::Gerador.Properties.Resources.server;
            this.button3.Location = new System.Drawing.Point(268, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 21);
            this.button3.TabIndex = 19;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cboBanco);
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(6, 100);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(310, 53);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "2.3 - Selecione ou entre com o nome do banco de dados:";
            this.toolTip1.SetToolTip(this.groupBox7, "Após selecionar sua opção, use a tecla <TAB>");
            this.groupBox7.Leave += new System.EventHandler(this.groupBox7_Leave);
            // 
            // cboBanco
            // 
            this.cboBanco.BackColor = System.Drawing.SystemColors.Info;
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(6, 26);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(256, 21);
            this.cboBanco.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Image = global::Gerador.Properties.Resources.db;
            this.button4.Location = new System.Drawing.Point(268, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 21);
            this.button4.TabIndex = 20;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtUsuario);
            this.groupBox6.Controls.Add(this.lblUsuario);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txtSenha);
            this.groupBox6.Controls.Add(this.ckAutentica);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(322, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(230, 77);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "2.2 Autenticação";
            this.toolTip1.SetToolTip(this.groupBox6, "Após selecionar sua opção, use a tecla <TAB>");
            this.groupBox6.Leave += new System.EventHandler(this.groupBox6_Leave);
            // 
            // txtUsuario
            // 
            this.txtUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Info;
            this.txtUsuario.Location = new System.Drawing.Point(6, 31);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(103, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(3, 15);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Senha:";
            // 
            // txtSenha
            // 
            this.txtSenha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSenha.BackColor = System.Drawing.SystemColors.Info;
            this.txtSenha.Location = new System.Drawing.Point(115, 31);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(109, 20);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // ckAutentica
            // 
            this.ckAutentica.Location = new System.Drawing.Point(6, 57);
            this.ckAutentica.Name = "ckAutentica";
            this.ckAutentica.Size = new System.Drawing.Size(206, 16);
            this.ckAutentica.TabIndex = 3;
            this.ckAutentica.Text = "Usar Autenticação Windows";
            this.ckAutentica.UseVisualStyleBackColor = true;
            this.ckAutentica.Click += new System.EventHandler(this.ckAutentica_Click);
            // 
            // lblConnstring
            // 
            this.lblConnstring.ForeColor = System.Drawing.Color.Maroon;
            this.lblConnstring.Location = new System.Drawing.Point(222, 192);
            this.lblConnstring.Name = "lblConnstring";
            this.lblConnstring.Size = new System.Drawing.Size(560, 34);
            this.lblConnstring.TabIndex = 11;
            this.lblConnstring.Text = "String de Conexão";
            this.lblConnstring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonGerarDALConexao
            // 
            this.buttonGerarDALConexao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGerarDALConexao.Location = new System.Drawing.Point(117, 32);
            this.buttonGerarDALConexao.Name = "buttonGerarDALConexao";
            this.buttonGerarDALConexao.Size = new System.Drawing.Size(105, 32);
            this.buttonGerarDALConexao.TabIndex = 1;
            this.buttonGerarDALConexao.Text = "Conexão";
            this.toolTip1.SetToolTip(this.buttonGerarDALConexao, "Métodos de conexão e métodos CRUD.");
            this.buttonGerarDALConexao.UseVisualStyleBackColor = true;
            this.buttonGerarDALConexao.Click += new System.EventHandler(this.buttonGerarDALConexao_Click_1);
            // 
            // buttonGerarDALpersistencias
            // 
            this.buttonGerarDALpersistencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGerarDALpersistencias.Location = new System.Drawing.Point(230, 32);
            this.buttonGerarDALpersistencias.Name = "buttonGerarDALpersistencias";
            this.buttonGerarDALpersistencias.Size = new System.Drawing.Size(105, 32);
            this.buttonGerarDALpersistencias.TabIndex = 2;
            this.buttonGerarDALpersistencias.Text = "Persistência";
            this.toolTip1.SetToolTip(this.buttonGerarDALpersistencias, "Métodos de Persistência específicos.");
            this.buttonGerarDALpersistencias.UseVisualStyleBackColor = true;
            this.buttonGerarDALpersistencias.Click += new System.EventHandler(this.buttonGerarDALpersistencias_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNamespace);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(15, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1 - Namespace do projeto:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 96);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "4 - Clique no botão adequado para gerar as classes, propiedades e métodos.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(372, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(61, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Saiba mais.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(564, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(194, 70);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "UIL - Uses Interface Layer";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(6, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 32);
            this.button2.TabIndex = 0;
            this.button2.Text = "Interface";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonGerarBLL);
            this.groupBox4.Location = new System.Drawing.Point(356, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 70);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "BLL - Business Logic Layer";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.buttonGerarTAB);
            this.groupBox3.Controls.Add(this.buttonGerarDALConexao);
            this.groupBox3.Controls.Add(this.buttonGerarDALpersistencias);
            this.groupBox3.Location = new System.Drawing.Point(9, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 70);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DAL - Data Access Layer";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(794, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::Gerador.Properties.Resources.fundo;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(49, 20);
            this.toolStripMenuItem1.Text = "Sobre";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(794, 576);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grupBanco);
            this.Controls.Add(this.grupTabelas);
            this.Controls.Add(this.lblConnstring);
            this.Controls.Add(this.grupCodigo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de classes para C#  + .NET + SQL Server";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.grupTabelas.ResumeLayout(false);
            this.grupCodigo.ResumeLayout(false);
            this.grupCodigo.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grupBanco.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grupTabelas;
        private System.Windows.Forms.ListBox ListBoxTabelas;
        private System.Windows.Forms.GroupBox grupCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox grupBanco;
        private System.Windows.Forms.Button buttonGerarBLL;
        private System.Windows.Forms.Button buttonGerarTAB;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.CheckBox ckAutentica;
        private System.Windows.Forms.Label lblConnstring;
        private System.Windows.Forms.TextBox textBoxNamespace;
        private System.Windows.Forms.Button buttonGerarDALConexao;
        private System.Windows.Forms.Button buttonGerarDALpersistencias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSalvar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.ComboBox cboServidor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}