using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador.Teste2
{
    public partial class Form1 : Form
    {
        //public GeradorDO.GeradorDO objGeradorDO = null;
        //public GeradorVO.GeradorVO objGeradorVO = null;
        //public GeradorBO.GeradorBO objGeradorBO = null;

        public Gerador.Connection.Connection objBanco = null;
        public Gerador.Entity.Entity obj1 = null;
        public Gerador.Business.Business obj2 = null;
        public Gerador.Dal.Dal obj3 = null;

        public SqlDataReader dr = null;
        public StringBuilder strConnstring = null;
        public String[] arrTabelas = null;

        SqlDataSourceEnumerator servers;
        DataTable tableServers;
        String server;
   
        public Form1()
        {
            InitializeComponent();
            servers = SqlDataSourceEnumerator.Instance;
            tableServers = new DataTable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
          

        }
        private void pesquisabanco(string servidor, string banco)
        {
            for (int i = 0; i < lstTabelas.Items.Count; i++)
            {
                lstTabelas.Items.RemoveAt(i);
            }
            if ((servidor.Trim() != "") || (banco.Trim() != ""))
            {

                // Monta a string de conexão
                //Data Source=ELNBSBSRV12;Initial Catalog=Eletronorte;User ID=elnweb; Password=elnweb;
                strConnstring = new StringBuilder();
                strConnstring.Append("Data Source=" + servidor.Replace("'", "") + ";");
                strConnstring.Append("Initial Catalog=" + banco.Replace("'", "") + ";");

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
                    objBanco = new  Connection.Connection(strConnstring.ToString());
                    try
                    {
                        // Ler as tabelas                        
                        dr = objBanco.QueryConsulta("SELECT * FROM SYSOBJECTS WHERE TYPE = 'U' ORDER BY NAME");
                        while (dr.Read())
                        {
                            lstTabelas.Items.Add(dr["NAME"].ToString());
                        }
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
        }

        private void btnLerBanco_Click(object sender, EventArgs e)
        {
            pesquisabanco(txtServidor.Text, txtBanco.Text);
        }


 
        private void btnGerarDO_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbServers()
        {

           
           
        }
       
    }
}
