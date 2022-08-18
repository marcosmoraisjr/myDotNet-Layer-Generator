using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.Sql;
using Gerador.Data;
using Gerador.Entity;
using Gerador.Business;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace Gerador
{
    public partial class Form2010 : Form
    {
        private Int32    codigoTabPag = 1;
        private TabPage  _tabPage;
        private String   _cboBanco;
        private Boolean  _tabPageValidador = false;

        public String   barraLabel = string.Empty;
        public Int32    barraMin = 0;
        public Int32    barraMax = 0;
        public Int32    barraPasso = 0;

        public Data.DAL objGeradorDAL = null;
        public Entity.Entity objGeradorTAB = null;
        public Business.BLL objGeradorBLL = null;
        public SqlDataReader dr = null;
        public StringBuilder strConnstring = null;
        public String[] arrTabelas = null;
        public Conexao.Conexao objBanco = null;

        public Form2010()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " " + Application.ProductVersion;
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
                            
                            //*********************************************************
                            Thread thr = new Thread(delegate()
                            {
                                doAguarde("Aguarde", "Procurando servidores de banco de dados...");
                            });
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
                            //*********************************************************

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
                                    doAguarde("Aguarde", "Procurando bancos de dados no servidor selecionado...");
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
                                        thr.Abort();
                                        MessageBox.Show("A forma de acesso informada, não permite estabelecer \ncomunicação com um dos bancos localizados. Verifique sua senha ou nome de usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                thr.Abort();

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

    
        
        /// <summary>
        /// Autor: Marcos
        /// Interação com o usuário, principalemente em processos demorados
        /// </summary> 
        /// <param name="texto">Aviso</param>
        /// <returns>Aviso</returns>
        private void doAguarde(string _strTitulo, string _strTexto)
        {
            try
            {
                FormProgressBar frm = new FormProgressBar();
                frm._titulo = _strTitulo;
                frm._texto = _strTexto;
                frm.ControlBox = false;
                frm.ShowDialog();
            }
            catch
            {
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
                doAguarde("Aguarde", "Procurando tabelas no banco selecionado...");
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
                    objBanco = new Conexao.Conexao(strConnstring.ToString());
                    try
                    {
                        // Ler as tabelas                        
                        dr = objBanco.QueryConsulta("SELECT * FROM SYSOBJECTS WHERE TYPE = 'U' ORDER BY NAME");
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
            thr.Abort();
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
            
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {

                    Thread thr = new Thread(delegate()
                    {
                        doAguarde("Aguarde", "Gerando código para Entidades...");
                    });
                    thr.Start();
                    {
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString(); ;
                        }
                        Gerador.Entity.Entity objGeradorEntity = new Gerador.Entity.Entity();
                        txtCodigo.Text = objGeradorEntity.GeraCodigoTAB(arrTabelas, strConnstring.ToString(), _cboBanco /*cboBanco.SelectedValue.ToString().Trim()*/, textBoxNamespace.Text.Trim()).ToString();
                    }
                    thr.Abort();
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
            if (ChecaLeitura())
            {
                Thread thr = new Thread(delegate()
                {
                    doAguarde("Aguarde", "Gerando código para conexão ao banco...");
                });
                thr.Start();
                {
                    objGeradorDAL = new Data.DAL();
                    txtCodigo.Text = objGeradorDAL.GerarClasseDados(strConnstring.ToString(), textBoxNamespace.Text.Trim()).ToString();
                }
                thr.Abort();
                grupCodigo.Enabled = true;
            }
        }
        private void btnPersistencia_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {
                    Thread thr = new Thread(delegate()
                    {
                        doAguarde("Aguarde", "Gerando código para persistências...");
                    });
                    thr.Start();
                    {
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString();
                        }
                        Gerador.Data.DAL objGeradorDAL = new Gerador.Data.DAL();
                        txtCodigo.Text = objGeradorDAL.GerarClasseDadosPersistencia(arrTabelas, strConnstring.ToString(), _cboBanco /*cboBanco.SelectedValue.ToString().Trim()*/, textBoxNamespace.Text.Trim()).ToString();
                    }
                    thr.Abort();
                    grupCodigo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selecione pelo menos uma tabela.");
                }

            }
        }
        private void btnRegrasDeNegocio_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {
                    Thread thr = new Thread(delegate()
                    {
                        doAguarde("Aguarde", "Gerando código de Regras de Negócio...");
                    });
                    thr.Start();
                    {
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString();
                        }
                        Gerador.Business.BLL objGeradorBLL = new Gerador.Business.BLL();
                        txtCodigo.Text = objGeradorBLL.GerarClasseBLL(arrTabelas, strConnstring.ToString(),_cboBanco /*cboBanco.SelectedValue.ToString().Trim()*/, textBoxNamespace.Text.Trim()).ToString();
                    }
                    thr.Abort();
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
            openFileDialog1.Filter = "Classe do MS Visual Studio (*.cs)|*.cs";
            //Verificando ao importa o arquivo não ocorreu erro
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Recuperando o nome do arquivo e colocando no textbox
                //txtimport.Text = openFileDialog1.FileName;
                try
                {
                    //Criando um objeto para leitura do arquivo txt
                    StreamReader objReader = new StreamReader(openFileDialog1.OpenFile());
                    txtCodigo.Text = objReader.ReadToEnd();
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
            saveFileDialog1.Filter = "Classe do MS Visual Studio (*.cs)|*.cs";
            //Verifica se não ocorreu erro ao exportar o conteúdo do textbox para arquivo txt
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Defina o objeto para escrever o conteúdo do textbox no arquivo txt
                StreamWriter sWriter = new StreamWriter(saveFileDialog1.OpenFile());
                //Escreva o conteúno no arquivo
                sWriter.Write(txtCodigo.Text);
                //Encerre o objeto StreamWriter
                sWriter.Close();
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form2010_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja Finalizar o Sistema ?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

     
    }
}
