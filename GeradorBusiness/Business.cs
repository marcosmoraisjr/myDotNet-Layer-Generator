using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gerador.Library;
using Gerador.Connection;

namespace Gerador.Business
{
    /// <summary>
    /// Classe BLL
    /// Criador: Marcos Morais (mmstec@gmail.com)
    /// Criada em 22/04/2010
    /// </summary>
    public class Business
    {
        /// <summary>
        /// atributos da classe
        /// </summary>
        private String strData = DateTime.Today.ToShortDateString();
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
        public StringBuilder GerarClasseBLL(String _tabela, String _conexao, String _banco, String _namespace)
        {
            string[] _tabelas = new string[1];
            _tabelas[0] = _tabela;
            return GerarClasseBLL(_tabelas, _conexao, _banco, _namespace); 
        }
        /// <summary>
        /// gera classe com as regras do negócio. 
        /// </summary>
        /// <param name="_tabelas"></param>
        /// <param name="_conexao"></param>
        /// <param name="_banco"></param>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        public StringBuilder GerarClasseBLL(String[] _tabelas, String _conexao, String _banco, String _namespace)
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
            objCodigo.AppendLine("using " + _namespace + ".DAL;");
            objCodigo.AppendLine("");
            objCodigo.AppendLine("namespace " + _namespace + ".BLL");
            objCodigo.AppendLine("{");

            objCodigo.AppendLine();
            objCodigo.AppendLine("#region classe " + _namespace.ToUpper());
            objCodigo.AppendLine();
            objCodigo.AppendLine("  /// <summary>");
            objCodigo.AppendLine("  /// BLL(Business Logic Layer)");
            objCodigo.AppendLine("  /// Descrição.: Responsável pelos métodos com as regras de negócio");
            objCodigo.AppendLine("  /// Autor.....: Marcos Morais de Sousa");
            objCodigo.AppendLine("  /// Data......: " + strData);
            objCodigo.AppendLine("  /// Email.....: mmstec@gmail.com");
            objCodigo.AppendLine("  /// </summary>");

            objCodigo.AppendLine("  public class ESPECIAL");
            objCodigo.AppendLine("  {");
            // MÉTODO FindByQuery ===========================================================
            objCodigo.AppendLine();
            objCodigo.AppendLine("      /// <summary>");
            objCodigo.AppendLine("      /// MARCOS:");
            objCodigo.AppendLine("      /// Seleciona todos os registros passados por query e retorna um DataTable..");
            objCodigo.AppendLine("      /// </summary>");
            objCodigo.AppendLine("      /// <param name=\"filtro da consulta</param>");
            objCodigo.AppendLine("      /// <returns>DataTable</returns>");
            objCodigo.AppendLine("      public DataTable FindBy_Query(string _query)");
            objCodigo.AppendLine("      {");
            objCodigo.AppendLine("          DAL.ESPECIAL cmd = new DAL.ESPECIAL();");
            objCodigo.AppendLine("          return cmd.FindBy_Query(_query);");
            objCodigo.AppendLine("      }");
            // MÉTODO FindByQuery ===============================================================
            objCodigo.AppendLine("  }");
            objCodigo.AppendLine("#endregion");

            foreach (string _tabela in _tabelas)
            {
                objCodigo.AppendLine();
                objCodigo.AppendLine("#region classe " + _tabela);
                objCodigo.AppendLine();
                objCodigo.AppendLine("  /// <summary>");
                objCodigo.AppendLine("  /// Business Logic Layer - BLL");
                objCodigo.AppendLine("  /// Descrição.: Responsável pelos métodos com as regras de negócio");
                objCodigo.AppendLine("  /// Autor.....: Marcos Morais de Sousa");
                objCodigo.AppendLine("  /// Data......: " + strData);
                objCodigo.AppendLine("  /// Email.....: mmstec@gmail.com");
                objCodigo.AppendLine("  /// </summary>");
                
                objCodigo.AppendLine("  public class " + _tabela + "");
                objCodigo.AppendLine("  {");
                objCodigo.AppendLine("      //MÉTODOS");

                //PARA ACRESCENTAR NOVOS METODOS, INSIRA ABAIXO DESTA MENSAGEM

                // MÉTODO Void InsertId(registro) =======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Insere os registros do banco e retorna o número de linhas afetadas.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public int InserirID(Entity." + _tabela + " registro)");
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
                objCodigo.AppendLine("      public void Inserir(Entity." + _tabela + " registro)");
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
                objCodigo.AppendLine("      public void Alterar(Entity." + _tabela + " registro, string _filtro)");
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
                objCodigo.AppendLine("      /// Atualiza os registros do banco e retorna os registros afetados.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public void AlterarID(Entity." + _tabela + " registro, string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          cmd.AlterarID(registro,_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO void Update(regitros,_filtro) =========================================

                // MÉTODO void Delete(_filtro) ==================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Apaga os registros do banco.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public void Excluir(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          cmd.Excluir(_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO void Delete(_filtro) =================================================

                // MÉTODO int DeleteId(_filtro) ================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Apaga os registros do banco e retorna o número de linhas afetadas.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public int ExcluirID(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necessários");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.ExcluirID(_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO int DeleteId(_filtro) ================================================

                // LIST INICIO //===============================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Lista os registros da base de dados.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
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
                // LIST FIM //===================================================================

                // MÉTODO FindAll() =================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindAll()");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.FindAll();");
                objCodigo.AppendLine("      }");
                // MÉTODO FindAll() ========================================================================

                // MÉTODO FindAll() ========================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindAll(String _orderby)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.FindAll(_orderby);");
                objCodigo.AppendLine("      }");
                // MÉTODO FindAll() ========================================================================

                // MÉTODO FindAll() ========================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <param=\"_asc|desc\">acendente|descendente</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindAll(String _orderby, String _asc)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.FindAll(_orderby, _asc);");
                objCodigo.AppendLine("      }");
                // MÉTODO FindAll() ========================================================================


                // MÉTODO FindByWhere ======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindBy_Where(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.FindBy_Where(_filtro);");
                objCodigo.AppendLine("      }");
                // MÉTODO FindByWhere ====================================================================

                // MÉTODO FindByWhere com filtro =========================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros com filtro e retorna um DataTable ordenado.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <param name=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindBy_Where(String _filtro, String _orderby)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.FindBy_Where(_filtro, _orderby);");
                objCodigo.AppendLine("      }");
                // MÉTODO FindByWhere com filtro ===========================================================

                // MÉTODO FindByWhere ======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <param name=\"_orderby\">campo de ordenação</param>");
                objCodigo.AppendLine("      /// <param name=\"_direction\">crescente ou decrescente</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindBy_Where(String _filtro, String _orderby, String _direction)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                objCodigo.AppendLine("          return cmd.FindBy_Where(_filtro, _orderby, _direction);");
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
                    objCodigo.AppendLine("      /// Seleciona todos os registros por " + objDr.GetName(i) + " e retorna um DataTable.");
                    objCodigo.AppendLine("      /// </summary>");
                    objCodigo.AppendLine("      /// <param name=\"_" + objDr.GetName(i) + "\">filtro da consulta</param>");
                    objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                    objCodigo.AppendLine("      public DataTable FindBy_" + objDr.GetName(i) + "(" + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " _" + objDr.GetName(i) + ")");
                    objCodigo.AppendLine("      {");
                    objCodigo.AppendLine("          DAL." + _tabela + " cmd = new DAL." + _tabela + "();");
                    objCodigo.AppendLine("          return cmd.FindBy_" + objDr.GetName(i) + "(_" + objDr.GetName(i) + ");");
                    objCodigo.AppendLine("      }");
                }
                // MÉTODO FindAll() ========================================================================

                //-------- FIM DA CLASSE
                objCodigo.AppendLine("  }");
                objCodigo.AppendLine();
                objCodigo.AppendLine("#endregion");
            }
            objCodigo.AppendLine();
            objCodigo.AppendLine("}");
            return objCodigo;

        }
    }

}