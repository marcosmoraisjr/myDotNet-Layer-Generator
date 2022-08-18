using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Gerador.WebService
{
    public class WebService
    {
        /// <summary>
        /// atributos da classe
        /// </summary>
        private String strData = null;
        private String[] arrTabelas = null;
        private String s = null;
        private String tb = null;
        private StringBuilder objCodigo = null;
        private SqlDataReader objDr = null;
        private Int32 nunrec = 0;
        private Gerador.Library.Library objLib = null;
        private Gerador.Connection.Connection objBanco = null;
        
        /// <summary>
        /// gera classe com as regras do negócio. 
        /// </summary>
        /// <param name="_tabela"></param>
        /// <param name="_conexao"></param>
        /// <param name="_banco"></param>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        public StringBuilder GerarClasseWebServiceEspecial(String _conexao, String _banco, String _namespace)
        {
            objCodigo = new StringBuilder();
            objCodigo.AppendLine("using System;");
            objCodigo.AppendLine("using System.Collections;");
            objCodigo.AppendLine("using System.Collections.Generic;");
            objCodigo.AppendLine("using System.Text;");
            objCodigo.AppendLine("using System.Data.Sql;");
            objCodigo.AppendLine("using System.Data;");
            objCodigo.AppendLine("using System.Data.SqlClient;");
            objCodigo.AppendLine("using System.Runtime.Serialization.Formatters.Binary;");
            objCodigo.AppendLine("using System.Web.Services;");
            objCodigo.AppendLine("using " + _namespace + ".Entity;");
            objCodigo.AppendLine("using " + _namespace + ".DAL;");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("namespace " + _namespace + ".WebService");
            objCodigo.AppendLine("{");
            objCodigo.AppendLine();
            objCodigo.AppendLine("  #region classe " + _namespace.ToUpper() + " : System.Web.Services.WebService");
            objCodigo.AppendLine();
            objCodigo.AppendLine("  /// <summary>");
            objCodigo.AppendLine("  /// WS (WebService)");
            objCodigo.AppendLine("  /// Descrição.: Responsável pelos métodos com as regras de negócio via WebService");
            objCodigo.AppendLine("  /// Autor.....: Marcos Morais de Sousa");
            objCodigo.AppendLine("  /// Data......: " + strData);
            objCodigo.AppendLine("  /// Email.....: mmstec@gmail.com");
            objCodigo.AppendLine("  /// </summary>");
            objCodigo.AppendLine("  [WebService(Namespace = \"http://tempuri.org/WebService1/Service1\", ");
            objCodigo.AppendLine("  Description = \"MARCOS: Classe com métodos especiais para consulta.\")] ");
            objCodigo.AppendLine("  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] ");
            objCodigo.AppendLine("  [System.ComponentModel.ToolboxItem(false)]");
            objCodigo.AppendLine("  public class " + _namespace.ToUpper() +" : System.Web.Services.WebService");
            objCodigo.AppendLine("  {");
            // MÉTODO FindByQuery ===========================================================
            objCodigo.AppendLine();
            objCodigo.AppendLine("      /// <summary>");
            objCodigo.AppendLine("      /// MARCOS:");
            objCodigo.AppendLine("      /// Lista registros da base de dados odedecendo uma query e retorna em um DataSet");
            objCodigo.AppendLine("      /// </summary>");
            objCodigo.AppendLine("      /// <param name=\"filtro da consulta</param>");
            objCodigo.AppendLine("      /// <returns>DataTable</returns>");
            objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Lista registros da base de dados odedecendo uma query e retorna em um DataSet.\")]");
            objCodigo.AppendLine("      public DataSet FindBy_Query(string _query)");
            objCodigo.AppendLine("      {");
            objCodigo.AppendLine("          DAL." + _namespace.ToUpper() + " cmd = new DAL." + _namespace.ToUpper() + "();");
            objCodigo.AppendLine("          DataSet ds = new DataSet();");
            objCodigo.AppendLine("          ds.Tables.Add(cmd.FindBy_Query(_query));");
            objCodigo.AppendLine("          return ds;");
            objCodigo.AppendLine("      }");
            // MÉTODO FindByQuery ===============================================================
            objCodigo.AppendLine("  }");
            objCodigo.AppendLine("  #endregion");
            objCodigo.AppendLine("}");
            objCodigo.AppendLine();
            return objCodigo;
        }

        public StringBuilder GerarClasseWebService(String _tabela, String _conexao, String _banco, String _namespace)
        {
            objCodigo = new StringBuilder();
            objCodigo.AppendLine("using System;");
            objCodigo.AppendLine("using System.Collections;");
            objCodigo.AppendLine("using System.Collections.Generic;");
            objCodigo.AppendLine("using System.Text;");
            objCodigo.AppendLine("using System.Data.Sql;");
            objCodigo.AppendLine("using System.Data;");
            objCodigo.AppendLine("using System.Data.SqlClient;");
            objCodigo.AppendLine("using System.Runtime.Serialization.Formatters.Binary;");
            objCodigo.AppendLine("using System.Web.Services;");
            objCodigo.AppendLine("using " + _namespace + ".Entity;");
            objCodigo.AppendLine("using " + _namespace + ".DAL;");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("namespace " + _namespace + ".WebService");
            objCodigo.AppendLine("{");
        
                objCodigo.AppendLine();
                objCodigo.AppendLine("#region classe " + _tabela);
                objCodigo.AppendLine();
                objCodigo.AppendLine("  /// <summary>");
                objCodigo.AppendLine("  /// WS - WebService Layer");
                objCodigo.AppendLine("  /// Descrição.: Responsável pelos métodos com as regras de negócio");
                objCodigo.AppendLine("  /// Autor.....: Marcos Morais de Sousa");
                objCodigo.AppendLine("  /// Data......: " + strData);
                objCodigo.AppendLine("  /// Email.....: mmstec@gmail.com");
                objCodigo.AppendLine("  /// </summary>");
                objCodigo.AppendLine("  [WebService(Namespace = \"http://tempuri.org/WebService1/Service1\", ");
                objCodigo.AppendLine("  Description = \"MARCOS: Classe com métodos especiais para consulta e persistência.\")] ");
                objCodigo.AppendLine("  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)] ");
                objCodigo.AppendLine("  [System.ComponentModel.ToolboxItem(false)]");
                objCodigo.AppendLine("  public class " + _tabela + " : System.Web.Services.WebService");
                objCodigo.AppendLine("  {");
                objCodigo.AppendLine("      //MÉTODOS");

                //PARA ACRESCENTAR NOVOS METODOS, INSIRA ABAIXO DESTA MENSAGEM

                // MÉTODO Void InsertId(registro) =======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Insere os registros do banco e retorna o identity.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Insere os registros do banco e retorna o identity.\")]");    
                objCodigo.AppendLine("      public int cmdInserirID(Entity." + _tabela + " registro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.InserirID(registro);");
                objCodigo.AppendLine("      }");
                // MÉTODO Void InsertId(registro) ========================================================================

                // MÉTODO Void Insert(registro) ========================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Insere os registros do banco");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Insere os registros do banco.\")]");     
                objCodigo.AppendLine("      public void cmdInserir(Entity." + _tabela + " registro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          cmd.Inserir(registro);");
                objCodigo.AppendLine("      }");
                // MÉTODO Void Insert(registro) ==================================================

                // MÉTODO void Update(regitros,_filtro) ==========================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Atualiza os registros do banco.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Atualiza os registros no banco.\")]"); 
                objCodigo.AppendLine("      public void cmdAlterar(Entity." + _tabela + " registro, string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          cmd.Alterar(registro,_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO void Update(regitros,_filtro) =========================================

                // MÉTODO void Update(regitros,_filtro) ==========================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Atualiza registro no banco e retorna identity.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Atualiza registro no banco e retorna o identity.\")]"); 
                objCodigo.AppendLine("      public void cmdAlterarID(Entity." + _tabela + " registro, string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          cmd.AlterarID(registro,_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO void Update(regitros,_filtro) ============================================

                // MÉTODO void Delete(_filtro) =====================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Apaga registro do banco.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Apaga registro no banco.\")]"); 
                objCodigo.AppendLine("      public void cmdExcluir(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          cmd.Excluir(_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO void Delete(_filtro) ====================================================

                // MÉTODO int DeleteId(_filtro) ===================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Apaga os registros do banco e retorna o IDENTITY.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Apaga registro no banco e retorna o IDENTITY.\")]"); 
                objCodigo.AppendLine("      public int cmdExcluirID(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.ExcluirID(_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO int DeleteId(_filtro) ====================================================

                // LIST INICIO //===================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Lista os registros da base de dados.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Lista os registros da base de dados.\")]"); 
                objCodigo.AppendLine("      public List<Entity." + _tabela + " > Find()");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("        try");
                objCodigo.AppendLine("        {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " obj = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return obj.Find();");
                objCodigo.AppendLine("        }");
                objCodigo.AppendLine("        catch");
                objCodigo.AppendLine("        {");
                objCodigo.AppendLine("          return null;");
                objCodigo.AppendLine("        }");
                objCodigo.AppendLine("      }");
                // LIST FIM //======================================================================

                // MÉTODO FindAll() ================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Lista todos os registros e retorna em um DataSet.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Lista todos os registros da base de dados e retorna em um DataSet.\")]"); 
                objCodigo.AppendLine("      public DataSet FindAll1()");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          DataSet ds = new DataSet();");
                objCodigo.AppendLine("          ds.Tables.Add(cmd.FindAll());");
                objCodigo.AppendLine("          return ds;");
                objCodigo.AppendLine("      }");
                // MÉTODO FindAll() =================================================================

                // MÉTODO FindAll() =================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataSet.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Lista os registros da base de dados e retorna um Dataset ordenado.\")]"); 
                objCodigo.AppendLine("      public DataSet FindAll2(String _orderby)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          DataSet ds = new DataSet();");
                objCodigo.AppendLine("          ds.Tables.Add(cmd.FindAll(_orderby));");
                objCodigo.AppendLine("          return ds;");
                objCodigo.AppendLine("      }");
                // MÉTODO FindAll() ==================================================================

                // MÉTODO FindAll() ==================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataSet.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <param=\"_asc|desc\">acendente|descendente</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Lista os registros que obdeceçam uma condição e retorna um DataSet ordenado.\")]"); 
                objCodigo.AppendLine("      public DataSet FindAll3(String _orderby, String _asc)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          DataSet ds = new DataSet();");
                objCodigo.AppendLine("          ds.Tables.Add(cmd.FindAll(_orderby, _asc));");
                objCodigo.AppendLine("          return ds;");
                objCodigo.AppendLine("      }");
                // MÉTODO FindAll() ========================================================================


                // MÉTODO FindByWhere ======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataSet.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Lista os registros que obdeceçam uma condição e retorna um DataSet.\")]"); 
                objCodigo.AppendLine("      public DataSet FindBy_Where1(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          DataSet ds = new DataSet();");
                objCodigo.AppendLine("          ds.Tables.Add(cmd.FindBy_Where(_filtro));");
                objCodigo.AppendLine("          return ds;");
                objCodigo.AppendLine("      }");
                // MÉTODO FindByWhere ====================================================================

                // MÉTODO FindByWhere com filtro =========================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros com filtro e retorna um DataSet ordenado.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <param name=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <returns>DataSet</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Seleciona todos os registros com filtro e retorna um DataSet ordenado.\")]"); 
                objCodigo.AppendLine("      public DataSet FindBy_Where2(String _filtro, String _orderby)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          DataSet ds = new DataSet();");
                objCodigo.AppendLine("          ds.Tables.Add(cmd.FindBy_Where(_filtro, _orderby));");
                objCodigo.AppendLine("          return ds;");
                objCodigo.AppendLine("      }");
                // MÉTODO FindByWhere com filtro ===========================================================

                // MÉTODO FindByWhere ======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataSet.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <param name=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <param name=\"_direction\">crescente ou decrescente</param>");
                objCodigo.AppendLine("      /// <returns>DataSet</returns>");
                objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Seleciona todos os registros com filtro e retorna um DataSet ordenado.\")]"); 
                objCodigo.AppendLine("      public DataSet FindBy_Where(String _filtro, String _orderby, String _direction)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          DataSet ds = new DataSet();");
                objCodigo.AppendLine("          ds.Tables.Add(cmd.FindBy_Where(_filtro, _orderby, _direction));");
                objCodigo.AppendLine("          return ds;");
                objCodigo.AppendLine("      }");
                // MÉTODO FindByWhere =======================================================================

                // MÉTODO FindAllBy por campo ===============================================================
                objBanco = new Connection.Connection(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + _tabela);
                objLib = new Library.Library();
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec; i++)
                {
                    objCodigo.AppendLine();
                    objCodigo.AppendLine("      /// <summary>");
                    objCodigo.AppendLine("      /// MARCOS:");
                    objCodigo.AppendLine("      /// Seleciona todos os registros por " + objDr.GetName(i) + " e retorna um DataSet.");
                    objCodigo.AppendLine("      /// </summary>");
                    objCodigo.AppendLine("      /// <param name=\"_" + objDr.GetName(i) + "\">filtro da consulta</param>");
                    objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                    objCodigo.AppendLine("      [WebMethod(Description = \"MARCOS: Seleciona todos os registros por " + objDr.GetName(i) + " e retorna um DataSet.\")]"); 
                    objCodigo.AppendLine("      public DataSet FindBy_" + objDr.GetName(i) + "(" + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " _" + objDr.GetName(i) + ")");
                    objCodigo.AppendLine("      {");
                    objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                    objCodigo.AppendLine("          DataSet ds = new DataSet();");
                    objCodigo.AppendLine("          ds.Tables.Add(cmd.FindBy_" + objDr.GetName(i) + "(_" + objDr.GetName(i) + "));");
                    objCodigo.AppendLine("          return ds;");
                    objCodigo.AppendLine("      }");
                }
                // MÉTODO FindAll() ========================================================================

                //-------- FIM DA CLASSE
                objCodigo.AppendLine("  }");
                objCodigo.AppendLine();
                objCodigo.AppendLine("#endregion");
          
            objCodigo.AppendLine();
            objCodigo.AppendLine("}");
            return objCodigo;
        }
      
    }
}
