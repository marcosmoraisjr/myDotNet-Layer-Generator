using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador.TESTE
{
    class Program
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
        public String[] lstTabelas = null;
        static void Main(string[] args)
        {

        }
        public static void LocateSqlInstances()
        {
            using (DataTable sqlSources = SqlDataSourceEnumerator.Instance.GetDataSources())
            {
                int i=1;
                foreach (DataRow source in sqlSources.Rows)
                {
                    Console.WriteLine(i.ToString());
                    i++;
                    string servername;
                    string instanceName = source["InstanceName"].ToString();

                    if (!string.IsNullOrEmpty(instanceName))
                    {
                        servername = source["InstanceName"] + "\\" + source["ServerName"];
                    }
                    else
                    {
                        servername = source["ServerName"].ToString();
                    }
                    Console.WriteLine(" Server Name:{0}", servername);
                    Console.WriteLine("     Version:{0}", source["Version"]);
                    Console.WriteLine();

                }
                Console.ReadKey();
            }
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
                    objBanco = new Banco.Banco(strConnstring.ToString());

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

    }
}
