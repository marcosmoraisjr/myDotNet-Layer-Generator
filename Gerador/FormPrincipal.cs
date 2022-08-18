using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using Gerador.Library;
using Gerador.Entity;
using Gerador.Dal;
using Gerador.Business;
using Gerador.WebService;


namespace Gerador
{
    public partial class FormPrincipal : Form
    {
        private Int32    codigoTabPag = 1;
        private TabPage  _tabPage;
        private String   _cboBanco;
        private Boolean  _tabPageValidador = false;
        private Boolean  _tag = false;
        private DialogResult _resultado;

        public String   barraLabel = string.Empty;
        public Int32    barraMin = 0;
        public Int32    barraMax = 0;
        public Int32    barraPasso = 0;
        public String arquivoNome;

        public Connection.Connection objConexao = null;
        public Dal.Dal objDal = null;
        public Entity.Entity objEntity = null;
        public Business.Business objBusiness = null;

        public SqlDataReader dr = null;
        public StringBuilder strConnstring = null;
        public String[] arrTabelas = null;


        public FormPrincipal(string _validade)
        {
            InitializeComponent();

            this.Text = Application.ProductName + " " + Application.ProductVersion;
            this.lblValidade.Text = _validade;
            this.lblValidade.Visible = true;

            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            this.lblValidade.Text += " "+ windowsIdentity.Name.ToString();
            /*
               pictureBox2.Image = new Bitmap(@"128x128/128_projeto.png");     //1
               pictureBox2.Image = new Bitmap(@"128x128/128_servidor.png");    //2
               pictureBox2.Image = new Bitmap(@"128x128/128_chave.png");       //3
               pictureBox2.Image = new Bitmap(@"128x128/128_monitor.png");     //4
               pictureBox2.Image = new Bitmap(@"128x128/128_tabela.jpg");      //5
               pictureBox2.Image = new Bitmap(@"128x128/128_dollar.png");      //6
            */
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            switch (codigoTabPag)
            {
                case 6:
                    codigoTabPag = 5;
                    _tabPage = tabPage5;
                    btnVoltar.Enabled = true;
                    btnAvancar.Enabled = true;
                    try
                    {
                        //pictureBox2.Image = new Bitmap(@"128x128/128_tabela.jpg");      //5
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_tabela;
                    }
                    catch
                    {
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor; //4
                    }
                    break;
                case 5:
                    codigoTabPag = 4;
                    _tabPage = tabPage4;
                    btnVoltar.Enabled = true;
                    btnAvancar.Enabled = true;
                    
                    try
                    {
                        //pictureBox2.Image = new Bitmap(@"128x128/128_monitor.png");     //4
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                    }
                    catch
                    {
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor; 
                    }

                    break;
                case 4:
                    codigoTabPag = 3;
                    _tabPage = tabPage3;
                    btnVoltar.Enabled = true;
                    btnAvancar.Enabled = true;
                    
                    try
                    {
                        //pictureBox2.Image = new Bitmap(@"128x128/128_chave.png");       //3
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_chave;
                    }
                    catch
                    {
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                    }
                    break;
                case 3:
                    codigoTabPag = 2;
                    _tabPage = tabPage2;
                    btnVoltar.Enabled = true;
                    btnAvancar.Enabled = true;
                    
                    try
                    {
                        //pictureBox2.Image = new Bitmap(@"128x128/128_servidor.png");    //2
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_servidor;
                    }
                    catch
                    {
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                    }

                    break;
                case 2:
                case 1:
                    codigoTabPag = 1;
                    _tabPage = tabPage1;
                    btnVoltar.Enabled = false;
                    btnAvancar.Enabled = true;
                    
                    try
                    {
                        //pictureBox2.Image = new Bitmap(@"128x128/128_projeto.png");     //1
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_projeto;
                    }
                    catch
                    {
                        pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                    }
                    break;
            }
            if (codigoTabPag >= 1)
            {
                this.tabControl1.TabPages.Clear();
                this.tabControl1.TabPages.Add(_tabPage);
                this.tabControl1.SelectedTab = _tabPage;
            }

        }
        private void btnAvancar_Click(object sender, EventArgs e)
        {
                switch (codigoTabPag)
                {
                    case 1:
                        if (textBoxNamespace.Text.Trim().Length < 1)
                        {
                            MessageBox.Show("Atenção:\nObrigatório informar uma namespace para o projeto.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _tabPageValidador = false;
                        }
                        else
                        {
                            codigoTabPag = 2;
                            _tabPage = tabPage2;
                            _tabPageValidador = true;
                            btnVoltar.Enabled = true;
                            btnAvancar.Enabled = true;
                            cboServidor.SelectedValue = 0;
                            
                            try
                            {
                                //pictureBox2.Image = new Bitmap(@"128x128/128_servidor.png"); //2
                                this.pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                            }
                            catch
                            {
                                pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                            }
                            
                            //modificação//

                        }
                        break;
                    case 2:
                        if (textBoxNamespace.Text.Trim().Length < 1)
                        {
                            MessageBox.Show("Atenção:\nObrigatório informar uma servidor/instância.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _tabPageValidador = false;
                        }
                        else
                        {
                            codigoTabPag = 3;
                            _tabPage = tabPage3;
                            _tabPageValidador = true;
                            btnVoltar.Enabled = true;
                            btnAvancar.Enabled = true;
                            
                            try
                            {
                                //pictureBox2.Image = new Bitmap(@"128x128/128_chave.png"); //3
                                this.pictureBox2.Image = global::Gerador.Properties.Resources._128_chave;
                            }
                            catch
                            {
                                pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                            }
                        }
                        break;
                    case 3:
                            if ((txtUsuario1.Text.Trim().Length >= 1 && txtSenha1.Text.Trim().Length >= 1) || chkAutentica.Checked )
                            {
                                _tabPageValidador = true;
                                codigoTabPag = 4;
                                _tabPage = tabPage4;
                                btnVoltar.Enabled = true;
                                btnAvancar.Enabled = true;
                                
                                try
                                {
                                    //pictureBox2.Image = new Bitmap(@"128x128/128_bancodedados.png");
                                    pictureBox2.Image = global::Gerador.Properties.Resources._128_bancodedados;
                                }
                                catch
                                {
                                    pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor; //4
                                }

                                //*********************************************************
                                Thread thr = new Thread(delegate()
                                {
                                    Library.Message.Processando("Aguarde", "Procurando bancos de dados no servidor selecionado...");
                                });
                                thr.Start();
                                if (cboBanco.Text.Length < 1)
                                {
                                    try
                                    {
                                        // Monta a string de conexão
                                        strConnstring = new StringBuilder();
                                        strConnstring.Append(@"Data Source=" + cboServidor.Text.ToString().Replace("'", "").Replace("//", "/") + ";");
                                        strConnstring.Append("Initial Catalog=" + cboBanco.Text.ToString().Replace("'", "") + ";");
                                        if ((chkAutentica.Checked == false) && (txtUsuario1.Text.Trim() != ""))
                                        {
                                            strConnstring.Append("User ID=" + txtUsuario1.Text.Replace("'", "") + ";");
                                            strConnstring.Append("Password=" + txtSenha1.Text.Replace("'", "") + ";");
                                        }
                                        else
                                        {
                                            // Usar autenticação segura
                                            strConnstring.Append("Integrated Security=True;");
                                        }
                                        //cboBanco.DataSource = GetDatabaseNames(cboServidor.Text);
                                        cboBanco.DataSource = GetDatabaseNames(strConnstring.ToString());
                                        //cboBanco.SelectedIndex = 0;
                                        //*********************************************************
                                    }
                                    catch
                                    {
                                        thr.Abort(); //fim do processo
                                        thr.Join(); //aguarda processo finalizar
                                        if (cboBanco.Text.Length <1)
                                        {
                                            MessageBox.Show("Não foi possível localizar bancos de dados em sua rede com o login e senha informados. \n\nVerifique se existe o Servidor SQL server instalado na rede e tente novamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("A forma de acesso informada, não permite estabelecer \ncomunicação com um dos bancos localizados. \n\nVerifique sua senha ou nome de usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                thr.Abort(); //fim do processo
                                thr.Join(); //aguarda processo finalizar
                            }
                            else
                            {
                                _tabPageValidador = false;
                                MessageBox.Show("Atenção:\nObrigatório informar um usuario e senha ou marcar autenticação do windows.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                            }
                        break;
                    case 4:
                        codigoTabPag = 5;
                        _tabPage = tabPage5;
                        _tabPageValidador = true;
                        btnVoltar.Enabled = true;
                        btnAvancar.Enabled = true;
                        
                        try
                        {
                            //pictureBox2.Image = new Bitmap(@"128x128/128_tabela.jpg"); //5
                            pictureBox2.Image = global::Gerador.Properties.Resources._128_tabela;
                        }
                        catch
                        {
                            pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                        }
                        
                        //*********************************************************
                        if (cboServidor.Text.Trim().Length < 1)
                        {
                            MessageBox.Show("Informe o nome de um servidor SQL válido.");
                        }
                        else
                        {
                            if (cboBanco.SelectedValue.ToString().Trim().Length < 1)
                            {
                                MessageBox.Show("Informe o nome de um banco de dados válido.");
                            }
                            else
                            {
                                ListarTabelas();
                                _cboBanco = cboBanco.SelectedValue.ToString().Trim();
                            }
                        }
                        //*********************************************************

                        break;
                    case 5:
                    case 6:
                        codigoTabPag = 6;
                        _tabPage = tabPage6;
                        _tabPageValidador = true;
                        btnVoltar.Enabled = true;
                        btnAvancar.Enabled = false;
                        
                        try
                        {
                            //pictureBox2.Image = new Bitmap(@"128x128/128_dollar.png");
                            pictureBox2.Image = global::Gerador.Properties.Resources._128_dollar;
                        }
                        catch
                        {
                            pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
                        }

                        break;
            }
            if (codigoTabPag <= 6 && _tabPageValidador)
            {
                this.tabControl1.TabPages.Clear();
                this.tabControl1.TabPages.Add(_tabPage);
                this.tabControl1.SelectedTab = _tabPage;
                
            }
        }
        private void Form2010_Load(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Clear();
            this.tabControl1.TabPages.Add(tabPage1);
            this.tabControl1.SelectedTab = tabPage1;
            try
            {
                //pictureBox2.Image = new Bitmap(@"128x128/128_projeto.png"); //1
                pictureBox2.Image = global::Gerador.Properties.Resources._128_projeto;
            }
            catch
            {
                pictureBox2.Image = global::Gerador.Properties.Resources._128_monitor;
            }
        }
        private static List<string> GetDatabaseNames(string _connString)
        {
            List<string> databaseNames = new List<string>();
            if (!String.IsNullOrEmpty(_connString))
            {
                using (SqlConnection conexao = new SqlConnection(_connString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conexao.Open();
                        cmd.Connection = conexao;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_databases";
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while ((dataReader.Read()))
                            {
                                databaseNames.Add(dataReader.GetString(0));
                            }
                        }
                    }
                }
            }
            return databaseNames;
        }
        private void ListarTabelas()
        {
            Thread thr = new Thread(delegate()
            {
                Library.Message.Processando("Aguarde", "Procurando tabelas no banco selecionado...");
            });
            thr.Start();

            for (int i = 0; i < ListBoxTabelas.Items.Count; i++)
            {
                //ListBoxTabelas.Items.RemoveAt(i);
                ListBoxTabelas.Items.Clear();
            }

            if ((cboServidor.Text.Trim() != "") || (cboBanco.Text.Trim() != ""))
            {
                // Monta a string de conexão
                strConnstring = new StringBuilder();
                strConnstring.Append(@"Data Source=" + cboServidor.Text.ToString().Replace("'", "").Replace("//", "/") + ";");
                strConnstring.Append("Initial Catalog=" + cboBanco.Text.ToString().Replace("'", "") + ";");

                if ((ckAutentica.Checked == false) && (txtUsuario1.Text.Trim() != ""))
                {
                    strConnstring.Append("User ID=" + txtUsuario1.Text.Replace("'", "") + ";");
                    strConnstring.Append("Password=" + txtSenha1.Text.Replace("'", "") + ";");
                }
                else
                {
                    // Usar autenticação segura
                    strConnstring.Append("Integrated Security=True;");
                }

                // Conecta com o banco
                try
                {
                    objConexao = new Connection.Connection(strConnstring.ToString());
                    try
                    {
                        StringBuilder filtrosql = new StringBuilder();
                        filtrosql.Append("SELECT * FROM SYSOBJECTS ");
                        filtrosql.Append("WHERE (TYPE = 'U') ");
                        filtrosql.Append("AND (name <> 'sysdiagrams') ");
                        filtrosql.Append("AND (name NOT LIKE 'aspnet_%')");
                        filtrosql.Append("ORDER BY NAME ");
                        // Ler as tabelas                        
                        //dr = objConexao.QueryConsulta("SELECT * FROM SYSOBJECTS WHERE (TYPE = 'U') AND (NAME <> 'sysdiagrams') ORDER BY NAME");
                        
                        // MARCOS: ler tabelas mas não mostrar sysdiagramas e tabelas do aspnet_
                        dr = objConexao.QueryConsulta(filtrosql.ToString());
                        while (dr.Read())
                        {
                                ListBoxTabelas.Items.Add(dr["NAME"].ToString());
                        }
                        groupBox2.Enabled = true;
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Erro ao ler o banco de dados.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro encontrado.");
                    }
                }
                catch (SqlException sqlerr)
                {
                    MessageBox.Show(sqlerr.ToString());
                }
                finally
                {
                    lblConnstring.Text = strConnstring.ToString();
                }
            }
            else
            {
                MessageBox.Show("Informe a string de conexão com o banco.");
            }
            thr.Abort(); //fim do processo
            thr.Join(); //aguarda processo finalizar
        }
        private bool ChecaLeitura()
        {
            if (strConnstring == null)
            {
                MessageBox.Show("Faça a leitura do banco.");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void chkAutentica1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAutentica.Checked == true)
            {
                txtSenha1.Enabled = false;
                txtUsuario1.Enabled = false;
                txtUsuario1.Text = string.Empty;
                txtSenha1.Text = string.Empty;
            }
            else
            {
                txtSenha1.Enabled = true;
                txtUsuario1.Enabled = true;
            }
        }
        private void btnEntidade_Click(object sender, EventArgs e)
        {
            //MARCOS: sugere o nome do arquivo
            arquivoNome = "Entity.cs";

            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {

                    Thread thr = new Thread(delegate()
                    {
                        Library.Message.Processando("Aguarde", "Gerando código para Entidades...");
                    });
                    thr.Start();
                        {
                            arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                            for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                            {
                                arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString(); ;
                            }
                            Gerador.Entity.Entity objGeradorEntity = new Gerador.Entity.Entity();
                            richTextBox1.Text = objGeradorEntity.GeraCodigoTAB(arrTabelas, strConnstring.ToString(), _cboBanco /*cboBanco.SelectedValue.ToString().Trim()*/, textBoxNamespace.Text.Trim()).ToString();
                        }
                    thr.Abort(); 
                    thr.Join(); 
                    grupCodigo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selecione pelo menos uma tabela.");
                }
            }
        }
        private void btnConexao_Click(object sender, EventArgs e)
        {
            //MARCOS: sugere o nome do arquivo
            arquivoNome = "DalConexao.cs"; 
            if (ChecaLeitura())
            {
                Thread thr = new Thread(delegate()
                {
                    Library.Message.Processando("Aguarde", "Gerando código para conexão ao banco...");
                });
                thr.Start();
                {
                    objDal = new Dal.Dal();
                    richTextBox1.Text = objDal.GerarClasseDados(strConnstring.ToString(), textBoxNamespace.Text.Trim()).ToString();
                }
                thr.Abort(); //fim do processo
                thr.Join(); //aguarda processo finalizar
                grupCodigo.Enabled = true;
            }
        }
        private void btnPersistencia_Click(object sender, EventArgs e)
        {
            //MARCOS: sugere o nome do arquivo
            arquivoNome = "Dal.cs"; 
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {
                    //muda o mouse para processando
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        Thread.Sleep(5000);  // wait for a while
                        
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString();
                        }
                        Gerador.Dal.Dal objGeradorDAL = new Gerador.Dal.Dal();
                        richTextBox1.Text = objGeradorDAL.GerarClasseDadosPersistencia(arrTabelas, strConnstring.ToString(), _cboBanco /*cboBanco.SelectedValue.ToString().Trim()*/, textBoxNamespace.Text.Trim()).ToString();

                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                        //volta o cursor ao normal
                    }
                }
                else
                {
                    MessageBox.Show("Selecione pelo menos uma tabela.");
                }

            }
        }
        private void btnWebService_Click(object sender, EventArgs e)
        {
            GerarSalvarArquivos();
        }
        private void btnRegrasDeNegocio_Click(object sender, EventArgs e)
        {
            //MARCOS: sugere o nome do arquivo
            arquivoNome = "Bll.cs"; 
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {
                    Thread thr = new Thread(delegate()
                    {
                        Library.Message.Processando("Aguarde", "Gerando código de Regras de Negócio...");
                    });
                    thr.Start();
                    {
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString();
                        }
                        Business.Business objGeradorBLL = new Business.Business();
                        richTextBox1.Text = objGeradorBLL.GerarClasseBLL(arrTabelas, strConnstring.ToString(), _cboBanco /*cboBanco.SelectedValue.ToString().Trim()*/, textBoxNamespace.Text.Trim()).ToString();
                    }
                    thr.Abort(); //fim do processo
                    thr.Join(); //aguarda processo finalizar
                    grupCodigo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selecione pelo menos uma tabela.");
                }
            }
        }
        
        private void btnInterface_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atenção:\nOpção em desenvolvimento.\nAguarde nova release.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSaibaMais frm = new FormSaibaMais();
            frm.Show();
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            //Definindo as propriedades do objeto OpenFileDialog
            openFileDialog1.Title = "Importar Arquivo";
            openFileDialog1.Filter = "Arquivo C# (*.cs)|*.cs";
            //Verificando ao importa o arquivo não ocorreu erro
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Recuperando o nome do arquivo e colocando no textbox
                //txtimport.Text = openFileDialog1.FileName;
                try
                {
                    //Criando um objeto para leitura do arquivo txt
                    StreamReader objReader = new StreamReader(openFileDialog1.OpenFile());
                    richTextBox1.Text = objReader.ReadToEnd();
                    //Encerra o objeto de leitura do arquivo txt
                    objReader.Close();
                }
                catch (Exception err)
                {
                    //Caso há algum erro na leitura mostre um caixa especificando o erro
                    MessageBox.Show("Erro: " + err.Message);
                }
            }
            //Encerra a importação do arquivo
            openFileDialog1.Dispose();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Defina a propriedade do objeto saveFileDialog
            saveFileDialog1.Title = "Salvar Arquivo";
            saveFileDialog1.DefaultExt = "*.cs";
            saveFileDialog1.Filter = "Arquivo C# (*.cs)|*.cs";
            saveFileDialog1.FileName = arquivoNome;
            
            //Verifica se não ocorreu erro ao exportar o conteúdo do textbox para arquivo txt
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                        //Defina o objeto para escrever o conteúdo do textbox no arquivo txt
                        StreamWriter sWriter = new StreamWriter(saveFileDialog1.OpenFile());
                        //Escreva o conteúno no arquivo
                        sWriter.Write(richTextBox1.Text);
                        //Encerre o objeto StreamWriter
                        sWriter.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: Não foi possível ler o arquivo do disco. Erro original: /n/n" + ex.Message);
                }
            }
        }
        private void GerarSalvarArquivos()
        {
            StringBuilder resultado = new StringBuilder();
            String arquivoInfo = "info.txt";
            
            // Cria um SaveFileDialog para solicitar um caminho eo nome do arquivo para salvar.
            SaveFileDialog saveFile1 = new SaveFileDialog();
            SaveFileDialog saveFile2 = new SaveFileDialog();
 
            // Inicializar o SaveFileDialog especificar a extensão de CS para o arquivo.
            saveFile1.Title = "Salvar Arquivos";
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Arquivo texto|*.txt";
            saveFile1.FileName = arquivoInfo;

            // Determinar se o usuário selecionar um nome de arquivo da SaveFileDialog.
            if (saveFile1.ShowDialog() == DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                FileInfo fi = new FileInfo(saveFile1.FileName); 
                // fi.DirectoryName;    //caminho do diretório completo 
                // fi.Name;             //nome do arquivo 
                // fi.Extension;        //extensão do arquivo 

                arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                int j = 0;
                resultado.AppendLine();
                resultado.Append("ARQUIVOS DE CLASSE WEBSERVICE");
                resultado.AppendLine();
                resultado.AppendLine();
                
                Gerador.WebService.WebService objGeradorWS = new Gerador.WebService.WebService();
                
                saveFile1.FileName = fi.DirectoryName + "\\" + textBoxNamespace.Text.Trim().ToUpper() + ".asmx.cs";
                richTextBox1.Text = objGeradorWS.GerarClasseWebServiceEspecial(strConnstring.ToString(), _cboBanco, textBoxNamespace.Text.Trim()).ToString();
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);

                saveFile1.FileName = fi.DirectoryName + "\\" + textBoxNamespace.Text.Trim().ToUpper() + ".asmx";
                richTextBox1.Clear();
                richTextBox1.Text = "<%@ WebService Language='C#' CodeBehind='" + textBoxNamespace.Text.Trim().ToUpper() + ".asmx.cs' Class='" + textBoxNamespace.Text.Trim() + ".WebService." + textBoxNamespace.Text.Trim().ToUpper() + "' %>";
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
 
                for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                {
                    arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString();

                    saveFile1.FileName = fi.DirectoryName + "\\" + arrTabelas[i] + ".asmx.cs";
                    richTextBox1.Text = objGeradorWS.GerarClasseWebService(arrTabelas[i], strConnstring.ToString(), _cboBanco, textBoxNamespace.Text.Trim()).ToString();
                    richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText); 

                    resultado.Append(saveFile1.FileName.ToString());
                    resultado.AppendLine();
                    
                    saveFile2.FileName = fi.DirectoryName + "\\" + arrTabelas[i] + ".asmx";
                    richTextBox1.Text = "<%@ WebService Language='C#' CodeBehind='" + arrTabelas[i] + ".asmx.cs' Class='" + textBoxNamespace.Text.Trim() + ".WebService." + arrTabelas[i] + "' %>";
                    richTextBox1.SaveFile(saveFile2.FileName, RichTextBoxStreamType.PlainText);

                    resultado.Append(saveFile2.FileName.ToString());
                    resultado.AppendLine();
                    
                    j=i;
                } 
                resultado.AppendLine();
                resultado.Append(string.Format("ARQUIVOS GERADOS PARA {0} TABELAS.",j.ToString()));
                richTextBox1.Text = resultado.ToString();
                richTextBox1.SaveFile(fi.DirectoryName + "\\"+arquivoInfo, RichTextBoxStreamType.PlainText);
            }
        }
        private void chkAutentica_Click(object sender, EventArgs e)
        {
            if (chkAutentica.Checked)
            {
                txtUsuario1.Enabled = false;
                txtSenha1.Enabled = false;
                txtUsuario1.Text = string.Empty;
                txtSenha1.Text = string.Empty;
            }
            else
            {
                txtUsuario1.Enabled = true;
                txtSenha1.Enabled = true;
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Finalizar o Sistema ?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
            //this.Close();
            //Application.Exit();
        }
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Finalizar o Sistema ?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //System.Environment.Exit(0);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void checkBoxSelecionarTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSelecionarTodas.Checked)
            {
                // seleciona todos os itens da lista
                if (ListBoxTabelas.SelectionMode != SelectionMode.One)
                {
                    for (int i = 0; i < ListBoxTabelas.Items.Count; i++)
                    {
                        ListBoxTabelas.SetSelected(i, true);
                    }
                }
            }
            else
            {
                // não seleciona todos os itens da lista
                if (ListBoxTabelas.SelectionMode != SelectionMode.One)
                {
                    for (int i = 0; i < ListBoxTabelas.Items.Count; i++)
                    {
                        ListBoxTabelas.SetSelected(i, false);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //*********************************************************
            Thread thr = new Thread(delegate() { Library.Message.Processando("Aguarde", "Procurando servidores de banco de dados..."); });
            thr.Start(); //inicio do processo
            if (cboServidor.Text.Length < 1)
            {
                try
                {
                    SqlDataSourceEnumerator servers = SqlDataSourceEnumerator.Instance;
                    DataTable serversTable = servers.GetDataSources();
                    foreach (DataRow dr in serversTable.Rows)
                    {
                        string serverName = null;
                        serverName = string.Format(@"{0}\{1}", dr[0], dr[1]);
                        cboServidor.Items.Add(serverName);
                    }
                    cboServidor.SelectedIndex = 0;
                }
                catch
                {
                    MessageBox.Show("O sistema não encontrou o Microsoft SQL Server instalado em sua rede. \n\nFavor verificar.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    //MessageBox.Show("Sistema retornou erro número: \n\n" + ex.ToString(),Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            thr.Abort(); //fim do processo
            thr.Join(); //aguarda processo finalizar
            //*********************************************************    */
        }
    }
}
