using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Gerador.Conexao;
using Gerador.Entity;
using Gerador.Data;
using Gerador.Business;
using System.Data.Sql;
using System.Threading;

namespace Gerador
{
    public partial class Principal : Form
    {
        public String barraLabel = string.Empty;
        public Int32 barraMin = 0;
        public Int32 barraMax = 0;
        public Int32 barraPasso = 0;
        
        public Data.DAL objGeradorDAL = null;
        public Entity.Entity objGeradorTAB = null;
        public Business.BLL objGeradorBLL = null;
        public SqlDataReader dr = null;
        public StringBuilder strConnstring = null;
        public String[] arrTabelas = null;
        public Conexao.Conexao objBanco = null;

     
        public Principal()
        {
            InitializeComponent();
        }


 
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void ListarTabelas()
        {
            Thread thr = new Thread(delegate()
            {
                doAguarde("Aguarde", "Processando...");
            });
            thr.Start();

            for (int i = 0; i < ListBoxTabelas.Items.Count; i++)
            {
                //ListBoxTabelas.Items.RemoveAt(i);
                ListBoxTabelas.Items.Clear();
            }

            if ( (cboServidor.Text.Trim() != "") || (cboBanco.Text.Trim() != ""))
            {
                // Monta a string de conexão
                strConnstring = new StringBuilder();
                strConnstring.Append(@"Data Source=" + cboServidor.Text.ToString().Replace("'", "").Replace("//", "/") + ";");
                strConnstring.Append("Initial Catalog=" + cboBanco.Text.ToString().Replace("'", "") + ";");
             
                if ((ckAutentica.Checked == false) && (txtUsuario.Text.Trim() != ""))
                {
                    strConnstring.Append("User ID=" + txtUsuario.Text.Replace("'", "") + ";");
                    strConnstring.Append("Password=" + txtSenha.Text.Replace("'", "") + ";");
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
        private void buttonLerBanco_Click(object sender, EventArgs e)
        {
            if (cboServidor.Text.Length < 1)
            {
                MessageBox.Show("Informe o nome de um servidor SQL válido.");
            }
            else
            {
                if (cboBanco.SelectedValue.ToString().Length < 1)
                {
                    MessageBox.Show("Informe o nome de um banco de dados válido.");

                }
                else
                {
                    ListarTabelas();
                }
            }
            
        }


        private void Principal_Load(object sender, EventArgs e)
        {
            textBoxNamespace.Focus();
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
        private void buttonGerarTAB_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {
                    Thread thr = new Thread(delegate()
                    {
                        doAguarde("Aguarde", "Processando...");
                    });
                    thr.Start();
                    {
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString(); ;
                        }
                        Gerador.Entity.Entity objGeradorEntity = new Gerador.Entity.Entity();
                        txtCodigo.Text = objGeradorEntity.GeraCodigoTAB(arrTabelas, strConnstring.ToString(), cboBanco.SelectedValue.ToString().Trim(), textBoxNamespace.Text.Trim()).ToString();
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
        private void buttonGerarDALConexao_Click_1(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                Thread thr = new Thread(delegate()
                {
                    doAguarde("Aguarde", "Processando...");
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
        private void buttonGerarDALpersistencias_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {
                    Thread thr = new Thread(delegate()
                    {
                        doAguarde("Aguarde", "Processando...");
                    });
                    thr.Start();
                    {
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString();
                        }
                        Gerador.Data.DAL objGeradorDAL = new Gerador.Data.DAL();
                        txtCodigo.Text = objGeradorDAL.GerarClasseDadosPersistencia(arrTabelas, strConnstring.ToString(), cboBanco.SelectedValue.ToString().Trim(), textBoxNamespace.Text.Trim()).ToString();
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
        private void buttonGerarBLL_Click(object sender, EventArgs e)
        {
            if (ChecaLeitura())
            {
                if (ListBoxTabelas.SelectedItems.Count != 0)
                {
                    Thread thr = new Thread(delegate()
                    {
                        doAguarde("Aguarde", "Processando...");
                    });
                    thr.Start();
                    {
                        arrTabelas = new string[ListBoxTabelas.SelectedItems.Count];
                        for (int i = 0; i < ListBoxTabelas.SelectedItems.Count; i++)
                        {
                            arrTabelas[i] = ListBoxTabelas.SelectedItems[i].ToString();
                        }
                        Gerador.Business.BLL objGeradorBLL = new Gerador.Business.BLL();
                        txtCodigo.Text = objGeradorBLL.GerarClasseBLL(arrTabelas, strConnstring.ToString(), cboBanco.SelectedValue.ToString().Trim(), textBoxNamespace.Text.Trim()).ToString();
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
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Defina a propriedade do objeto saveFileDialog
            saveFileDialog1.Title = "Salvar Arquivo";
            saveFileDialog1.Filter = "Classe do Visual Studio (*.cs)|*.cs";
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
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Definindo as propriedades do objeto OpenFileDialog
            openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.Filter = "Classe do Visual Studio (*.cs)|*.cs";
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
        private void creditosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public static List<string> GetDatabaseNames(string _connString) 
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
    
   

        /// <summary>
        /// Autor: Marcos
        /// Interação com o usuário, principalemente em processos demorados
        /// </summary> 
        /// <param name="texto">Aviso</param>
        /// <returns>Aviso</returns>
        private void doAguarde(string _strTitulo, string _strTexto)
        {
            FormProgressBar frm = new FormProgressBar();
            frm._titulo = _strTitulo;
            frm._texto = _strTexto;
            frm.ControlBox = false;
            frm.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(delegate()
            {
                doAguarde("Aguarde","Processando...");
            });
            thr.Start();

            if (cboServidor.Text.Length < 1)
            {
                SqlDataSourceEnumerator servers = SqlDataSourceEnumerator.Instance;
                DataTable serversTable = servers.GetDataSources();
                foreach (DataRow dr in serversTable.Rows)
                {
                    string serverName = null;
                    serverName = string.Format(@"{0}\{1}", dr[0], dr[1]);
                    cboServidor.Items.Add(serverName);
                }
            }

            thr.Abort();
         
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Thread thr = new Thread(delegate()
            {
                doAguarde("Aguarde", "Processando...");
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

                    if ((ckAutentica.Checked == false) && (txtUsuario.Text.Trim() != ""))
                    {
                        strConnstring.Append("User ID=" + txtUsuario.Text.Replace("'", "") + ";");
                        strConnstring.Append("Password=" + txtSenha.Text.Replace("'", "") + ";");
                    }
                    else
                    {
                        // Usar autenticação segura
                        strConnstring.Append("Integrated Security=True;");
                    }
                    //cboBanco.DataSource = GetDatabaseNames(cboServidor.Text);
                    cboBanco.DataSource = GetDatabaseNames(strConnstring.ToString());
                }
                catch
                {
                    thr.Abort();
                    MessageBox.Show("Não foi possível estabelecer uma comunicação com o banco. Verifique sua senha ou nome de usuário","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            thr.Abort();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
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
                }
            }
        }

  
        //passo 1
        private void cboServidor_Leave(object sender, EventArgs e)
        {
            if (cboServidor.Text.Length >= 1)
                groupBox6.Enabled = true;
            else
                groupBox6.Enabled = false;
         
        }

        //passo 2
        private void groupBox6_Leave(object sender, EventArgs e)
        {
            if ((txtUsuario.Text.Length >= 1 && txtSenha.Text.Length >= 1) || ckAutentica.Checked)
                groupBox7.Enabled = true;
            else
                groupBox7.Enabled = false;
        }

        private void ckAutentica_Click(object sender, EventArgs e)
        {
            if (ckAutentica.Checked == true)
            {
                txtSenha.Enabled = false;
                txtUsuario.Enabled = false;
            }
            else
            {
                txtSenha.Enabled = true;
                txtUsuario.Enabled = true;
            }
            if ((txtUsuario.Text.Length >= 1 && txtSenha.Text.Length >= 1) || ckAutentica.Checked)
                groupBox7.Enabled = true;
            else
                groupBox7.Enabled = false;
        }

        private void groupBox7_Leave(object sender, EventArgs e)
        {
           if (cboBanco.Text.Length >= 1)
               button1.Enabled = true;
            else
               button1.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSaibaMais frm = new FormSaibaMais();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}