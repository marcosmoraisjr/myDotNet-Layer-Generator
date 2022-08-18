using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Gerador.Library;
using Gerador.Connection;
using Gerador.Entity;

namespace Gerador.Dal
{
    /// <summary>
    /// Descri��o..: Classe DAL - Data Access Layer
    /// Criador....: Marcos Morais (mmstec@gmail.com)
    /// Data.......: 22/04/2010
    /// </summary>
    public class Dal
    {
        /// <summary>
        /// Atributos
        /// </summary>
        private String strData = DateTime.Today.ToShortDateString();
        private StringBuilder objCodigo = null;
        private SqlDataReader objDr = null;
        private Int32 nunrec = 0;
        private Gerador.Library.Library objLib = null;
        private Gerador.Connection.Connection objBanco = null;
        private Gerador.Entity.Entity objEntity = null;
        
        /// <summary>
        /// gera classe de conex�o com a base de dados do sistema
        /// </summary>
        /// <param name="_conexao"></param>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        public StringBuilder GerarClasseDados(String _conexao, String _namespace)
        {
            objCodigo = new StringBuilder();
            objCodigo.AppendLine("using System;");
            objCodigo.AppendLine("using System.Collections.Generic;");
            objCodigo.AppendLine("using System.Linq;");
            objCodigo.AppendLine("using System.Text;");
            objCodigo.AppendLine("using System.Configuration;");
            objCodigo.AppendLine("using System.Data;");
            objCodigo.AppendLine("using System.Data.OleDb;");
            objCodigo.AppendLine("using System.Data.Odbc;");
            objCodigo.AppendLine("using System.Data.SqlClient;");
            objCodigo.AppendLine("using System.Data.SqlTypes;");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("namespace " + _namespace + ".DAL");
            objCodigo.AppendLine("{");
            objCodigo.AppendLine();
            objCodigo.AppendLine();
            objCodigo.AppendLine("      /// <summary>");
            objCodigo.AppendLine("      /// Descri��o.: Respons�vel pela conex�o a base de dados");
            objCodigo.AppendLine("      /// Autor.....: Marcos Morais de Sousa");
            objCodigo.AppendLine("      /// Data......: " + strData);
            objCodigo.AppendLine("      /// Email.....: mmstec@gmail.com");
            objCodigo.AppendLine("      /// </summary>");
            objCodigo.AppendLine("      public class conexao");
            objCodigo.AppendLine("      {");
            objCodigo.AppendLine();
            objCodigo.AppendLine("          public static string stringConnection");
            objCodigo.AppendLine("          {");
            objCodigo.AppendLine("              get");
            objCodigo.AppendLine("              {");
            objCodigo.AppendLine("                  //return @\"" + _conexao + "\";");
            objCodigo.AppendLine("                  return ConfigurationManager.ConnectionStrings[\"ROTA\"].ToString();");
            objCodigo.AppendLine("              }");
            objCodigo.AppendLine("          }");
            objCodigo.AppendLine("      }");
            objCodigo.AppendLine("}");
            objCodigo.AppendLine();

            #region MARCOS: classe comentados
            /*
            objCodigo.AppendLine();
            objCodigo.AppendLine("      /// <summary>");
            objCodigo.AppendLine("      /// MARCOS:");
            objCodigo.AppendLine("      /// Seleciona todos os registros com filtro e retorna um DataTable ordenado.");
            objCodigo.AppendLine("      /// </summary>");
            objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
            objCodigo.AppendLine("      /// <param name=\"_orderby\">campo de ordena��o</param>");
            objCodigo.AppendLine("      /// <returns>DataTable</returns>");
            objCodigo.AppendLine("      public DataTable FindByWhere(String _filtro, String _orderby)");
            objCodigo.AppendLine("      {");
            objCodigo.AppendLine("          var connect = conexao.stringConnection;");
            objCodigo.AppendLine("          var query = new StringBuilder();");
            objCodigo.AppendLine("          var dt = new DataTable();");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("          query.Append(\" SELECT \");");

            //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
            objBanco = new Banco.Banco(_conexao);
            objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
            nunrec = objDr.FieldCount;
            for (int i = 0; i < nunrec - 1; i++)
            {
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + ", \");");
            }
            objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
            objBanco.CloseConn();
            objBanco = null;
            //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

            objCodigo.AppendLine("          query.Append(\" FROM " + strTabela + " \");");
            objCodigo.AppendLine("          query.Append(\" WHERE ( \" + _filtro + \" ) ORDER BY \" + _orderby +\" \");");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
            objCodigo.AppendLine("          {");
            objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
            objCodigo.AppendLine("              {");
            objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
            objCodigo.AppendLine("                  using (var da = new SqlDataAdapter(cmd))");
            objCodigo.AppendLine("                  {");
            objCodigo.AppendLine("                      da.Fill(dt);");
            objCodigo.AppendLine("                      return dt;");
            objCodigo.AppendLine("                  }");
            objCodigo.AppendLine("              }");
            objCodigo.AppendLine("          }");
            objCodigo.AppendLine("      }");
            
            // M�TODO FindAllByWhere e ordena��o ============================================================
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /*
            objCodigo.AppendLine("        //M�TODOS");
            objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// MARCOS");
            objCodigo.AppendLine("        /// M�todo que retorna a conex�o com  a base de dados.");
            objCodigo.AppendLine("        /// </summary>");
            objCodigo.AppendLine("        /// <returns></returns> ");
            objCodigo.AppendLine("        public static SqlConnection connection()");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            try");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                //Inst�ncia o sqlconnection com a string de conex�o.");
            objCodigo.AppendLine("                //SqlConnection sqlconnection = new SqlConnection(ConfigurationSettings.AppSettings[\"ConnectionString\"].ToString());");
            objCodigo.AppendLine("                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[\"ROTA\"].ToString());");
            objCodigo.AppendLine("                //Verifica se a conex�o esta fechada.");
            objCodigo.AppendLine("                if (cnn.State == ConnectionState.Closed)");
            objCodigo.AppendLine("                {");
            objCodigo.AppendLine("                    //Abri a conex�o.");
            objCodigo.AppendLine("                    cnn.Open();");
            objCodigo.AppendLine("                }");
            objCodigo.AppendLine("                //Retorna o sqlconnection.");
            objCodigo.AppendLine("                return cnn;");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("            catch (SqlException ex)");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                throw ex;");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("        }");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// MARCOS");
            objCodigo.AppendLine("        /// M�todo que retorna um datareader com o resultado da query.");
            objCodigo.AppendLine("        /// </summary>");
            objCodigo.AppendLine("        /// <param name=\"query\"></param>");
            objCodigo.AppendLine("        /// <returns></returns>");
            objCodigo.AppendLine("        public SqlDataReader retornarQuery(string query)");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            try");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                //Inst�ncia o sqlcommand com a query sql que ser� executada e a conex�o.");
            objCodigo.AppendLine("                SqlCommand comando = new SqlCommand(query, conexao.connection());");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("                //Executa a query sql.");
            objCodigo.AppendLine("                var retornaQuery = comando.ExecuteReader();");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("                //Fecha a conex�o.");
            objCodigo.AppendLine("                connection().Close();");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("                //Retorna o dataReader com o resultado");
            objCodigo.AppendLine("                return retornaQuery;");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("            catch (SqlException ex)");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                throw ex;");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("        }");
            objCodigo.AppendLine("");

            objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// AUTOR: MARCOS MORAIS");
            objCodigo.AppendLine("        /// DESCRI��O: Preenche um DataTable de acordo com uma instru��o SQL.");
            objCodigo.AppendLine("        /// </ summary>");
            objCodigo.AppendLine("        /// <param name=\"query\"> instru��o SQL. </ param>");
            objCodigo.AppendLine("        /// <returns> DataTable Populado. </ returns>");
            objCodigo.AppendLine("        public DataTable retornarQuery(string query)");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            var connect = conexao.stringConnection;");
            objCodigo.AppendLine("            var datatable = new DataTable();");
            objCodigo.AppendLine("            using (var connection = new SqlConnection())");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                connection.ConnectionString = connect;");
            objCodigo.AppendLine("                using (var command = new SqlCommand())");
            objCodigo.AppendLine("                {");
            objCodigo.AppendLine("                    command.Connection = connection;");
            objCodigo.AppendLine("                    command.CommandType = CommandType.Text;");
            objCodigo.AppendLine("                    command.CommandText = query;");
            objCodigo.AppendLine("                    using (var adapter = new SqlDataAdapter())");
            objCodigo.AppendLine("                    {");
            objCodigo.AppendLine("                        adapter.SelectCommand = command;");
            objCodigo.AppendLine("                        adapter.Fill(datatable);");
            objCodigo.AppendLine("                        return datatable;");
            objCodigo.AppendLine("                     }");
            objCodigo.AppendLine("                }");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("        }");

            objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// AUTOR: MARCOS MORAIS");
            objCodigo.AppendLine("        /// DESCRI��O: Preenche um DataTable de acordo com uma instru��o SQL.");
            objCodigo.AppendLine("        /// </ summary>");
            objCodigo.AppendLine("        /// <param name=\"query\"> instru��o SQL. </ param>");
            objCodigo.AppendLine("        /// <returns> DataTable Populado. </ returns>");
            objCodigo.AppendLine("        public DataTable retornarQuery(string query)");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            var connect = conexao.stringConnection;");
            objCodigo.AppendLine("            var DataTable = new DataTable();");
            objCodigo.AppendLine("            using (var connection = new SqlConnection())");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                connection.ConnectionString = connect;");
            objCodigo.AppendLine("                using (var command = new SqlCommand())");
            objCodigo.AppendLine("                {");
            objCodigo.AppendLine("                    command.Connection = connection;");
            objCodigo.AppendLine("                    command.CommandType = CommandType.Text;");
            objCodigo.AppendLine("                    command.CommandText = query;");
            objCodigo.AppendLine("                    using (var adapter = new SqlDataAdapter())");
            objCodigo.AppendLine("                    {");
            objCodigo.AppendLine("                        adapter.SelectCommand = command;");
            objCodigo.AppendLine("                        adapter.Fill(DataTable);");
            objCodigo.AppendLine("                        return DataTable;");
            objCodigo.AppendLine("                     }");
            objCodigo.AppendLine("                }");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("        }");

            /*objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// MARCOS");
            objCodigo.AppendLine("        /// M�todo que retorna o resultado da consulta sql em um dataTable.");
            objCodigo.AppendLine("        /// </summary>");
            objCodigo.AppendLine("        /// <param name=\"query\"></param>");
            objCodigo.AppendLine("        /// <returns></returns>");
            objCodigo.AppendLine("        public DataTable retornarQuery(string query)");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            var connect = conexao.stringConnection;");
            objCodigo.AppendLine("            var dt = new DataTable();");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("            using (var conn = new SqlConnection(connect))");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                using (var cmd = new SqlCommand(query, conn))");
            objCodigo.AppendLine("                {");
            objCodigo.AppendLine("                    cmd.CommandType = CommandType.Text;");
            objCodigo.AppendLine("                    var da = new SqlDataAdapter(cmd);");
            objCodigo.AppendLine("                    da.Fill(dt);");
            objCodigo.AppendLine("                    return dt;");
            objCodigo.AppendLine("                }");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("        }");*/
     
            /*objCodigo.AppendLine("");
            objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// MARCOS");
            objCodigo.AppendLine("        /// M�todo que retorna o resultado da consulta sql em um dataTable.");
            objCodigo.AppendLine("        /// </summary>");
            objCodigo.AppendLine("        /// <param name=\"query\"></param>");
            objCodigo.AppendLine("        /// <returns></returns>");
            objCodigo.AppendLine("        public DataTable retornarQuery(string query)");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            var connect = conexao.connection().ToString();//stringConnection;");
            objCodigo.AppendLine("            var dt = new DataTable();");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("            using (var conn = new SqlConnection(connect))");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                using (var cmd = new SqlCommand(query, conn))");
            objCodigo.AppendLine("                {");
            objCodigo.AppendLine("                    cmd.CommandType = CommandType.Text;");
            objCodigo.AppendLine("                    var da = new SqlDataAdapter(cmd);");
            objCodigo.AppendLine("                    da.Fill(dt);");
            objCodigo.AppendLine("                    return dt;");
            objCodigo.AppendLine("                }");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("        }");
            

            objCodigo.AppendLine("");
            objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// MARCOS");
            objCodigo.AppendLine("        /// M�todo CRUD que executa a query sql.");
            objCodigo.AppendLine("        /// SELECT, INSERT, DELETE E UPDADE");
            objCodigo.AppendLine("        /// </summary>");
            objCodigo.AppendLine("        /// <param name=\"query\"></param>");
            objCodigo.AppendLine("        public void execQuery(string query)");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            try");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                //Inst�ncia o sqlcommand com a query sql que ser� executada e a conex�o.");
            objCodigo.AppendLine("                SqlCommand comando = new SqlCommand(query, conexao.connection());");
            objCodigo.AppendLine("                //Executa a query sql.");
            objCodigo.AppendLine("                comando.ExecuteNonQuery();");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("            catch (Exception ex)");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                throw ex;");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("        }");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("        /// <summary>");
            objCodigo.AppendLine("        /// MARCOS");
            objCodigo.AppendLine("        /// M�todo que executa a query sql e retorna o identity.");
            objCodigo.AppendLine("        /// </summary>");
            objCodigo.AppendLine("        /// <param name=\"query\"></param>");
            objCodigo.AppendLine("        public int execQueryID(string query)");
            objCodigo.AppendLine("        {");
            objCodigo.AppendLine("            try");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                //Inst�ncia o sqlcommand com a query sql que ser� executada e a conex�o.");
            objCodigo.AppendLine("                SqlCommand comando = new SqlCommand(query, conexao.connection());");
            objCodigo.AppendLine("                comando.CommandType = CommandType.Text;");
            objCodigo.AppendLine("                //Executa a query sql.");
            objCodigo.AppendLine("                return Convert.ToInt32(comando.ExecuteScalar());");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("            catch (Exception ex)");
            objCodigo.AppendLine("            {");
            objCodigo.AppendLine("                throw ex;");
            objCodigo.AppendLine("            }");
            objCodigo.AppendLine("        }");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("    }");
            objCodigo.AppendLine("}");
            objCodigo.AppendLine("");
            */
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            #endregion

            return objCodigo;
        }

        /// <summary>
        /// gera classe contendo diversos m�todos de persist�ncia
        /// </summary>
        /// <param name="_tabelas"></param>
        /// <param name="_conexao"></param>
        /// <param name="_banco"></param>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        public StringBuilder GerarClasseDadosPersistencia(String[] _tabelas, String _conexao, String _banco, String _namespace)
        {
            objCodigo = new StringBuilder();
	        objCodigo.AppendLine("using System;");
	        objCodigo.AppendLine("using System.Collections.Generic;");
	        objCodigo.AppendLine("using System.Text;");
	        objCodigo.AppendLine("using System.Data.Sql;");
	        objCodigo.AppendLine("using System.Data;");
	        objCodigo.AppendLine("using System.Collections;");
	        objCodigo.AppendLine("using System.Data.SqlClient;");
            objCodigo.AppendLine("using " + _namespace + ".Entity;");
            objCodigo.AppendLine();
            objCodigo.AppendLine("namespace " + _namespace + ".DAL");
	        objCodigo.AppendLine("{");
            objCodigo.AppendLine();
            objCodigo.AppendLine();
            
            #region MARCOS:classe especial
            objCodigo.AppendLine("    #region MARCOS: classe ESPECIAL" + _namespace.ToUpper());
            objCodigo.AppendLine("    /// <summary>");
            objCodigo.AppendLine("    /// DAL(data access layer)");
            objCodigo.AppendLine("    /// Autor.....: Marcos Morais de Sousa");
            objCodigo.AppendLine("    /// Data......: " + strData);
            objCodigo.AppendLine("    /// Email.....: mmstec@gmail.com");
            objCodigo.AppendLine("    /// </summary>");
            objCodigo.AppendLine("    public class "+_namespace.ToUpper());
            objCodigo.AppendLine("    {");

            #region MARCOS: FindBy_Query classe listar com condi��o
            objCodigo.AppendLine();
            objCodigo.AppendLine("      /// <summary>");
            objCodigo.AppendLine("      /// MARCOS:");
            objCodigo.AppendLine("      /// Seleciona todos os registros passados por query e retorna um DataTable.");
            objCodigo.AppendLine("      /// </summary>");
            objCodigo.AppendLine("      /// <param name=\"filtro da consulta</param>");
            objCodigo.AppendLine("      /// <returns>DataTable</returns>");
            objCodigo.AppendLine("      public DataTable FindBy_Query(string _query)");
            objCodigo.AppendLine("      {");
            objCodigo.AppendLine("          var connect = conexao.stringConnection;");
            objCodigo.AppendLine("          var dt = new DataTable();");
            objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
            objCodigo.AppendLine("          {");
            objCodigo.AppendLine("              using (var cmd = new SqlCommand(_query.ToString(), conn))");
            objCodigo.AppendLine("              {");
            objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
            objCodigo.AppendLine("                  using (var da = new SqlDataAdapter(cmd))");
            objCodigo.AppendLine("                  {");
            objCodigo.AppendLine("                      da.Fill(dt);");
            objCodigo.AppendLine("                      return dt;");
            objCodigo.AppendLine("                  }");
            objCodigo.AppendLine("              }");
            objCodigo.AppendLine("          }");
            objCodigo.AppendLine("      }");
            #endregion
            objCodigo.AppendLine("    }");
            objCodigo.AppendLine("    #endregion");
            #endregion

            foreach (string strTabela in _tabelas)
            {
                objCodigo.AppendLine();
                objCodigo.AppendLine("    #region MARCOS: classe " + strTabela);
                objCodigo.AppendLine("    /// <summary>");
                objCodigo.AppendLine("    /// Data Access Layer - DAL");
                objCodigo.AppendLine("    /// Descri��o.: Respons�vel pelos m�todos de persist�ncia e obten��o de dados junto a base de dados");
                objCodigo.AppendLine("    /// Autor.....: Marcos Morais de Sousa");
                objCodigo.AppendLine("    /// Data......: " + strData);
                objCodigo.AppendLine("    /// Email.....: mmstec@gmail.com");
                objCodigo.AppendLine("    /// </summary>");
                objCodigo.AppendLine("    public class " + strTabela + "");
                objCodigo.AppendLine("    {");

                #region MARCOS:classe inserir com retorno
                // INSERT ////////////////////////////////////////////////////////////////////////////////////////
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// INSERT");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"Entity." + strTabela + "\"></param>");
                objCodigo.AppendLine("      public Int32 InserirID(Entity." + strTabela + " registro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("            int resultado = 0;");
                objCodigo.AppendLine("            var connect = conexao.stringConnection;");
                objCodigo.AppendLine("            var query = new StringBuilder();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("            query.Append(\"INSERT INTO " + strTabela + " (\");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                // pega todas as colunas da tabela
                // Abre conex�o
                objBanco = new Connection.Connection(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 1; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.AppendLine("            query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                // lista a �ltima coluna sem a virgula
                objCodigo.AppendLine("            query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
                // Fecha conex�o
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("            query.Append(\") VALUES (\");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 1; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("            query.Append(\" @" + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("            query.Append(\" @" + objDr.GetName(nunrec - 1) + " \");");
                objBanco.CloseConn();
                objBanco = null;

                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------
                objCodigo.AppendLine("            query.Append(\") SELECT SCOPE_IDENTITY()\");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("            using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("            {");
                objCodigo.AppendLine("                  using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                        try");
                objCodigo.AppendLine("                        {");
                objCodigo.AppendLine("                              cmd.CommandType = CommandType.Text;");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;

                for (int i = 1; i < nunrec; i++)
                {
                    objCodigo.AppendLine("                              cmd.Parameters.AddWithValue(\"@" + objDr.GetName(i) + "\", registro." + objDr.GetName(i) + ");");
                }

                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("                        conn.Open();");
                objCodigo.AppendLine("                        resultado = Convert.ToInt32(cmd.ExecuteScalar());");
                objCodigo.AppendLine("                        if (resultado == 0)");
                objCodigo.AppendLine("                        {");
                objCodigo.AppendLine("                            throw new Exception(\"N�o foi poss�vel incluir o registro. O n�mero de registros afetados foi.\"+resultado.ToString());");
                objCodigo.AppendLine("                        }");
                objCodigo.AppendLine("                        else");
                objCodigo.AppendLine("                        {");
                objCodigo.AppendLine("                            return resultado;");
                objCodigo.AppendLine("                        }");
                objCodigo.AppendLine("                    }");
                objCodigo.AppendLine("                    catch (Exception Err)");
                objCodigo.AppendLine("                    {");
                objCodigo.AppendLine("                        throw new Exception(\"Entre em contato com o administrador do sistema. \"+Err.ToString());");
                objCodigo.AppendLine("                    }");
                objCodigo.AppendLine("                }");
                objCodigo.AppendLine("            }");
                objCodigo.AppendLine("      }");
                #endregion

                #region MARCOS:classe inserir
                // INSERT ////////////////////////////////////////////////////////////////////////////////////////
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// Respons�vel por inserir informa��es na base de dados.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"" + strTabela + "\"></param>");
                objCodigo.AppendLine("      public void Inserir(Entity." + strTabela + " registro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("            var connect = conexao.stringConnection;");
                objCodigo.AppendLine("            var query = new StringBuilder();");
                objCodigo.AppendLine();
                objCodigo.AppendLine("            query.Append(\"INSERT INTO " + strTabela + " (\");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                // pega todas as colunas da tabela
                // Abre conex�o
                objBanco = new Connection.Connection(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                // Armazena o total de campos encontrados
                nunrec = objDr.FieldCount;
                for (int i = 1; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.AppendLine("            query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                // lista a �ltima coluna sem a virgula
                objCodigo.AppendLine("            query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
                // Fecha conex�o
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("            query.Append(\") VALUES (\");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 1; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("            query.Append(\" @" + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("            query.Append(\" @" + objDr.GetName(nunrec - 1) + " \");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("            query.Append(\") \");");
                objCodigo.AppendLine();
                objCodigo.AppendLine("            using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("            {");
                objCodigo.AppendLine("                  using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                        cmd.CommandType = CommandType.Text;");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;

                for (int i = 1; i < nunrec; i++)
                {
                    objCodigo.AppendLine("                        cmd.Parameters.AddWithValue(\"@" + objDr.GetName(i) + "\", registro." + objDr.GetName(i) + ");");
                }

                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("                        conn.Open();");
                objCodigo.AppendLine("                        int resultado = cmd.ExecuteNonQuery();");
                objCodigo.AppendLine("                        if (resultado < 1)");
                objCodigo.AppendLine("                        {");
                objCodigo.AppendLine("                              throw new Exception(\"N�o foi poss�vel incluir o registro. O n�mero de registros afetados foi \"+resultado.ToString());");
                objCodigo.AppendLine("                        }");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("            }");
                objCodigo.AppendLine("      }");
                #endregion

                #region MARCOS:classe excluir com retorno
                // DELETE ////////////////////////////////////////////////////////////////////////////////////////
                objCodigo.AppendLine();
                objCodigo.AppendLine("  /// <summary>");
                objCodigo.AppendLine("  /// Deleta o registro do banco e retorna o id afetados");
                objCodigo.AppendLine("  /// </summary>");
                objCodigo.AppendLine("  /// <param name=\"Entity." + strTabela + "\"></param>");
                objCodigo.AppendLine("  public Int32 ExcluirID(string _filtro)");
                objCodigo.AppendLine("  {");
                objCodigo.AppendLine("      var resultado = 0;");
                objCodigo.AppendLine("      var connect = conexao.stringConnection;");
                objCodigo.AppendLine("      var query = new StringBuilder();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("      query.Append(\" DELETE FROM " + strTabela + " \");");
                objCodigo.AppendLine("      query.Append(\" WHERE (\" + _filtro + \") \");");
                objCodigo.AppendLine("      query.Append(\" SELECT SCOPE_IDENTITY() \");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("      using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              try");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  conn.Open();");
                objCodigo.AppendLine("                  resultado = Convert.ToInt32(cmd.ExecuteScalar());");
                objCodigo.AppendLine("                  if (resultado == 0)");
                objCodigo.AppendLine("                  {");
                //objCodigo.AppendLine("                      throw new Exception(\"N�o foi poss�vel apagar o registro.\");");
                objCodigo.AppendLine("                      throw new Exception(\"N�o foi poss�vel apagar o registro. O n�mero de registros afetados foi \"+resultado.ToString());");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("                  else");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      return resultado;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("              catch (Exception Err)");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  throw new Exception(\"Entre em contato com o administrador do sistema. \"+Err.ToString());");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                objCodigo.AppendLine("  }");
                // DELETE FIM ////////////////////////////////////////////////////////////////////////////////////
                #endregion

                #region MARCOS:classe excluir
                // DELETE ////////////////////////////////////////////////////////////////////////////////////////
                objCodigo.AppendLine();
                objCodigo.AppendLine("  /// <summary>");
                objCodigo.AppendLine("  /// Deleta os registros do banco");
                objCodigo.AppendLine("  /// </summary>");
                objCodigo.AppendLine("  /// <param name=\"string filtro\"></param>");
                objCodigo.AppendLine("  public void Excluir(string _filtro)");
                objCodigo.AppendLine("  {");
                objCodigo.AppendLine("      var resultado = 0;");
                objCodigo.AppendLine("      var connect = conexao.stringConnection;");
                objCodigo.AppendLine("      var query = new StringBuilder();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("      query.Append(\" DELETE FROM " + strTabela + " \");");
                objCodigo.AppendLine("      query.Append(\" WHERE (\" + _filtro + \")\");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("      using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              try");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  conn.Open();");
                objCodigo.AppendLine("                  resultado = cmd.ExecuteNonQuery();");
                objCodigo.AppendLine("                  if (resultado < 1)");
                objCodigo.AppendLine("                  {");
                //objCodigo.AppendLine("                      throw new Exception(\"N�o foi poss�vel apagar o registro.\");");
                objCodigo.AppendLine("                      throw new Exception(\"N�o foi poss�vel apagar o registro. O n�mero de registros afetados foi \"+resultado.ToString());");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("              catch (Exception Err)");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  throw new Exception(\"Entre em contato com o administrador do sistema. \"+Err.ToString());");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                objCodigo.AppendLine("  }");
                // DELETE FIM ////////////////////////////////////////////////////////////////////////////////////
                #endregion

                #region MARCOS:classe alterar com retorno
                // UPDATE ////////////////////////////////////////////////////////////////////////////////////////
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// UPDATE ");
                objCodigo.AppendLine("      /// Altera os registros do banco e retorna o id afetado");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"" + strTabela + "\"></param>");
                objCodigo.AppendLine("      public Int32 AlterarID(Entity." + strTabela + " registro, string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          var resultado = 0;");
                objCodigo.AppendLine("          var connect = conexao.stringConnection;");
                objCodigo.AppendLine("          var query = new StringBuilder();");
                objCodigo.AppendLine("          query.Append(\"UPDATE " + strTabela + " SET \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                // pega todas as colunas da tabela
                // Abre conex�o
                objBanco = new Connection.Connection(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);

                nunrec = objDr.FieldCount;
                for (int i = 1; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + "=@" + objDr.GetName(i) + ", \");");
                }
                // lista a �ltima coluna sem a virgula
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1) + "=@" + objDr.GetName(nunrec - 1) + " \");");

                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("          query.Append(\" WHERE (\" + _filtro + \") \");");
                objCodigo.AppendLine("          query.Append(\" SELECT SCOPE_IDENTITY() \");");
                //objCodigo.AppendLine("            query.Append(\" WHERE (\" + campo_id + \"=@\" + campo_id + \")\");");
                objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine();

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec; i++)
                {
                    objCodigo.AppendLine("                  cmd.Parameters.AddWithValue(\"@" + objDr.GetName(i) + "\", registro." + objDr.GetName(i) + ");");
                }
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine();
                objCodigo.AppendLine("                  conn.Open();");
                objCodigo.AppendLine("                  resultado = Convert.ToInt32(cmd.ExecuteScalar());");
                objCodigo.AppendLine("                  if (resultado ==0)");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      throw new Exception(\"N�o foi poss�vel salvar a alterara��o do registro. O n�mero de registros afetados foi \"+resultado.ToString());");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("                  else");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      return resultado;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                // UPDATE ////////////////////////////////////////////////////////////////////////////////////////
                #endregion

                #region MARCOS: classe alterar
                // UPDATE ////////////////////////////////////////////////////////////////////////////////////////
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// UPDATE ");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"" + strTabela + "\"></param>");
                objCodigo.AppendLine("      public void Alterar(Entity." + strTabela + " registro, string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          var connect = conexao.stringConnection;");
                objCodigo.AppendLine("          var query = new StringBuilder();");
                objCodigo.AppendLine("          query.Append(\"UPDATE " + strTabela + " SET \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                // pega todas as colunas da tabela
                // Abre conex�o
                objBanco = new Connection.Connection(_conexao);
                // Faz a leitura de todas as colunas da tabela
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                
                nunrec = objDr.FieldCount;
                for (int i = 1; i < nunrec - 1; i++)
                {
                    // lista as colunas
                    objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + "=@" + objDr.GetName(i) + ", \");");
                }
                // lista a �ltima coluna sem a virgula
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1) + "=@" + objDr.GetName(nunrec - 1) + " \");");

                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("          query.Append(\" WHERE (\" + _filtro + \")\");");
                //objCodigo.AppendLine("            query.Append(\" WHERE (\" + campo_id + \"=@\" + campo_id + \")\");");
                objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine();

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec; i++)
                {
                    objCodigo.AppendLine("                  cmd.Parameters.AddWithValue(\"@" + objDr.GetName(i) + "\", registro." + objDr.GetName(i) + ");");
                }
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine();
                objCodigo.AppendLine("                  conn.Open();");
                objCodigo.AppendLine("                  int resultado = cmd.ExecuteNonQuery();");
                objCodigo.AppendLine("                  if (resultado < 1)");
                objCodigo.AppendLine("                  {");
                //objCodigo.AppendLine("                      throw new Exception(\"N�o foi poss�vel ALTERAR o registro.\");");
                objCodigo.AppendLine("                      throw new Exception(\"N�o foi poss�vel salvar a altera��o do registro. O n�mero de registros afetados foi \"+resultado.ToString());");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                // UPDATE ////////////////////////////////////////////////////////////////////////////////////////
                #endregion

                #region MARCOS: classe listar
                // LIST INICIO //===================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// LISTA ");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"" + strTabela + "\"></param>");
                objCodigo.AppendLine("      public List<Entity." + strTabela + "> Find()");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("            List<Entity." + strTabela + "> " + strTabela.ToLower() + " = new List<Entity." + strTabela + ">();");
                objCodigo.AppendLine("            var connect = conexao.stringConnection;");
                objCodigo.AppendLine("            string commandText = (\"SELECT * FROM " + strTabela + "\");");
                objCodigo.AppendLine("            using (SqlConnection connection = new SqlConnection(connect))");
                objCodigo.AppendLine("            {");
                objCodigo.AppendLine("                  SqlCommand command = new SqlCommand(commandText, connection);");
                objCodigo.AppendLine("                  command.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  try");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                        connection.Open();");
                objCodigo.AppendLine("                        SqlDataReader dataReader = command.ExecuteReader();");
                objCodigo.AppendLine("                        if (dataReader != null)");
                objCodigo.AppendLine("                        {");
                objCodigo.AppendLine("                              while (dataReader.Read())");
                objCodigo.AppendLine("                              {");
                objCodigo.AppendLine("                                    Entity." + strTabela + " _" + strTabela + " = new Entity." + strTabela + "();");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                objLib = new Library.Library();
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec; i++)
                {
                    objCodigo.AppendLine("                          _" + strTabela + "." + objDr.GetName(i) + " = (" + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + ")dataReader[\"" + objDr.GetName(i) + "\"];");
                }
                objCodigo.AppendLine("                          " + strTabela.ToLower() + ".Add(_" + strTabela + ");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("                              }");
                objCodigo.AppendLine("                        }");
                objCodigo.AppendLine("                        return " + strTabela.ToLower() + " ;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("                  catch");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                        return null;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("                  finally");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                        connection.Close();");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("            }");
                objCodigo.AppendLine("      }");
                // LIST FIM //===================================================================
                #endregion

                #region MARCOS: classe listar tudo 
                // M�TODO FindAll =================================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindAll()");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          var connect = conexao.stringConnection;");
                objCodigo.AppendLine("          var query = new StringBuilder();");
                objCodigo.AppendLine("          var dt = new DataTable();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          query.Append(\"SELECT \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("          query.Append(\"FROM " + strTabela + " \");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  using (var da = new SqlDataAdapter(cmd))");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      da.Fill(dt);");
                objCodigo.AppendLine("                      return dt;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                // M�TODO FindAll =================================================================================
                #endregion

                #region MARCOS: classe listar tudo, ordenando
                // M�TODO FindAll com ordena��o ============================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable ordenado.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordena��o</param>");
                objCodigo.AppendLine("      public DataTable FindAll(String _campo)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          var connect = conexao.stringConnection;");
                objCodigo.AppendLine("          var query = new StringBuilder();");
                objCodigo.AppendLine("          var dt = new DataTable();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          query.Append(\"SELECT \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1)+ " \");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("          query.Append(\"FROM " + strTabela + " ORDER BY \"+_campo+\" \");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  using (var da = new SqlDataAdapter(cmd))");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      da.Fill(dt);");
                objCodigo.AppendLine("                      return dt;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                // M�TODO FindAll com ordena��o ============================================================
                #endregion

                #region MARCOS: classe listar tudo, ordenando e direcionando (crescente ou decrescente)
                // M�TODO FindAll com ordena��o e dire��o ============================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable ordenado.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordena��o</param>");
                objCodigo.AppendLine("      /// <param=\"_asc|desc\">acendente|descendente</param>");
                objCodigo.AppendLine("      public DataTable FindAll(String _campo, String _direcao)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          var connect = conexao.stringConnection;");
                objCodigo.AppendLine("          var query = new StringBuilder();");
                objCodigo.AppendLine("          var dt = new DataTable();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          query.Append(\"SELECT \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("          query.Append(\"FROM " + strTabela + " ORDER BY \"+_campo+\"  \"+_direcao+\"  \");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  using (var da = new SqlDataAdapter(cmd))");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      da.Fill(dt);");
                objCodigo.AppendLine("                      return dt;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                // M�TODO FindAll com ordena��o e dire��o ============================================================
                #endregion

                #region MARCOS: classe listar com condi��o onde
                // M�TODO FindAllByWhere ==========================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros com filtro e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindBy_Where(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          var connect = conexao.stringConnection;");
                objCodigo.AppendLine("          var query = new StringBuilder();");
                objCodigo.AppendLine("          var dt = new DataTable();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          query.Append(\" SELECT \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("          query.Append(\" FROM " + strTabela + " \");");
                objCodigo.AppendLine("          query.Append(\" WHERE ( \" + _filtro + \" ) \");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  using (var da = new SqlDataAdapter(cmd))");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      da.Fill(dt);");
                objCodigo.AppendLine("                      return dt;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                // M�TODO FindAllByWhere =========================================================================
                #endregion

                #region MARCOS: classe listar com condicao e ordenando
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros com filtro e retorna um DataTable ordenado.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <param name=\"_orderby\">campo de ordena��o</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindBy_Where(String _filtro, String _campo)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          var connect = conexao.stringConnection;");
                objCodigo.AppendLine("          var query = new StringBuilder();");
                objCodigo.AppendLine("          var dt = new DataTable();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          query.Append(\" SELECT \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("          query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("          query.Append(\" FROM " + strTabela + " \");");
                objCodigo.AppendLine("          query.Append(\" WHERE ( \" + _filtro + \" ) ORDER BY \" + _campo +\" \");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("          using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("          {");
                objCodigo.AppendLine("              using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("              {");
                objCodigo.AppendLine("                  cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                  using (var da = new SqlDataAdapter(cmd))");
                objCodigo.AppendLine("                  {");
                objCodigo.AppendLine("                      da.Fill(dt);");
                objCodigo.AppendLine("                      return dt;");
                objCodigo.AppendLine("                  }");
                objCodigo.AppendLine("              }");
                objCodigo.AppendLine("          }");
                objCodigo.AppendLine("      }");
                // M�TODO FindAllByWhere e ordena��o ============================================================
                #endregion

                #region MARCOS: classe listar com condicao, ordenando e direcionado
                // M�TODO FindAllByWhere e ordena��o e dire��o ======================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("        /// <summary>");
                objCodigo.AppendLine("        /// MARCOS:");
                objCodigo.AppendLine("        /// Seleciona todos os registros com filtro e retorna um DataTable ordenado.");
                objCodigo.AppendLine("        /// </summary>");
                objCodigo.AppendLine("        /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("        /// <param name=\"_orderby\">campo de ordena��o</param>");
                objCodigo.AppendLine("        /// <param name=\"_direction\">crescente ou decrescente</param>");
                objCodigo.AppendLine("        /// <returns>DataTable</returns>");
                objCodigo.AppendLine("        public DataTable FindBy_Where(String _filtro, String _orderby, String _direction)");
                objCodigo.AppendLine("        {");
                objCodigo.AppendLine("            var connect = conexao.stringConnection;");
                objCodigo.AppendLine("            var query = new StringBuilder();");
                objCodigo.AppendLine("            var dt = new DataTable();");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("            query.Append(\" SELECT \");");

                //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec - 1; i++)
                {
                    objCodigo.AppendLine("            query.Append(\" " + objDr.GetName(i) + ", \");");
                }
                objCodigo.AppendLine("            query.Append(\" " + objDr.GetName(nunrec - 1) + " \");");
                objBanco.CloseConn();
                objBanco = null;
                //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                objCodigo.AppendLine("            query.Append(\" FROM " + strTabela + " \");");
                objCodigo.AppendLine("            query.Append(\" WHERE ( \" + _filtro + \" ) ORDER BY \"+_orderby+\" \");");
                objCodigo.AppendLine("");
                objCodigo.AppendLine("            using (var conn = new SqlConnection(connect))");
                objCodigo.AppendLine("            {");
                objCodigo.AppendLine("                using (var cmd = new SqlCommand(query.ToString(), conn))");
                objCodigo.AppendLine("                {");
                objCodigo.AppendLine("                    cmd.CommandType = CommandType.Text;");
                objCodigo.AppendLine("                    using (var da = new SqlDataAdapter(cmd))");
                objCodigo.AppendLine("                    {");
                objCodigo.AppendLine("                        da.Fill(dt);");
                objCodigo.AppendLine("                        return dt;");
                objCodigo.AppendLine("                    }");
                objCodigo.AppendLine("                }");
                objCodigo.AppendLine("            }");
                objCodigo.AppendLine("        }");
                // M�TODO FindAllByWhere e ordena��o e dire��o  ============================================================
                #endregion

                #region MARCOS: classe listar por campo
                // M�TODO FindAllBy por campo ===================================================================
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                objLib = new Library.Library();
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec; i++)
                {
                    objCodigo.AppendLine();
                    objCodigo.AppendLine("        /// <summary>");
                    objCodigo.AppendLine("        /// MARCOS:");
                    objCodigo.AppendLine("        /// Seleciona todos os registros por " + objDr.GetName(i) + " e retorna um DataTable.");
                    objCodigo.AppendLine("        /// </summary>");
                    objCodigo.AppendLine("        /// <param name=\"_" + objDr.GetName(i) + "\">filtro da consulta</param>");
                    objCodigo.AppendLine("        /// <returns>DataTable</returns>");
                    objCodigo.AppendLine("        public DataTable FindBy_" + objDr.GetName(i) + "(" + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " _" + objDr.GetName(i) + ")");
                    objCodigo.AppendLine("        {");
                    objCodigo.AppendLine("                var connect = conexao.stringConnection;");
                    objCodigo.AppendLine("                var query = new StringBuilder();");
                    objCodigo.AppendLine("                var dt = new DataTable();");
                    objCodigo.AppendLine();
                    objCodigo.AppendLine("                query.Append(\" SELECT \");");

                    //CAMPOS - INICIO DO LA�O ---------------------------------------------------------------
                    //objBanco = new Connection.Connection(_conexao);
                    //objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                    //nunrec = objDr.FieldCount;
                    for (int j = 0; j < (nunrec-1); j++)
                    {
                        objCodigo.AppendLine("                query.Append(\" " + objDr.GetName(j) + ", \");");
                    }
                    // lista a �ltima coluna sem a virgula
                    objCodigo.AppendLine("                query.Append(\" " + objDr.GetName(nunrec-1) + " \");");
                    
                    //CAMPOS - FIM DO LA�O -------------------------------------------------------------------

                    objCodigo.AppendLine("                query.Append(\" FROM " + strTabela + " \");");
                  //objCodigo.AppendLine("                query.Append(\" WHERE ( " + objLib.SelectParam(objDr.GetName(i).ToString(), objDr.GetDataTypeName(i).ToString()) + " ) \");");
                    objCodigo.AppendLine("                query.Append(\" WHERE " + objDr.GetName(i) + "=@" + objDr.GetName(i) + "\" );");
                    objCodigo.AppendLine();
                    objCodigo.AppendLine("                using (var conn = new SqlConnection(connect))");
                    objCodigo.AppendLine("                {");
                    objCodigo.AppendLine("                        using (var cmd = new SqlCommand(query.ToString(), conn))");
                    objCodigo.AppendLine("                        {");
                    objCodigo.AppendLine("                                cmd.CommandType = CommandType.Text;");
                    objCodigo.AppendLine("                                cmd.Parameters.AddWithValue(\"@" + objDr.GetName(i) + "\", _" + objDr.GetName(i) + ");");
                    objCodigo.AppendLine("                                using (var da = new SqlDataAdapter(cmd))");
                    objCodigo.AppendLine("                                {");
                    objCodigo.AppendLine("                                        da.Fill(dt);");
                    objCodigo.AppendLine("                                        return dt;");
                    objCodigo.AppendLine("                                }");
                    objCodigo.AppendLine("                        }");
                    objCodigo.AppendLine("                }");
                    objCodigo.AppendLine("        }");
                }
                objBanco.CloseConn();
                objBanco = null;
                // M�TODO FindAllBy por campo ===================================================================
                #endregion

                objCodigo.AppendLine("  }");
                objCodigo.AppendLine();
                objCodigo.AppendLine("#endregion");
            }
            objCodigo.AppendLine();
            objCodigo.AppendLine("}");

            return objCodigo;

        }
        public StringBuilder GerarClasseDadosPersistencia(String _tabela, String _conexao, String _banco, String _namespace)
        {
            string[] _tabelas = new string[1];
            _tabelas[0] = _tabela;
            return GerarClasseDadosPersistencia(_tabelas, _conexao, _banco, _namespace);
        }
    }

}