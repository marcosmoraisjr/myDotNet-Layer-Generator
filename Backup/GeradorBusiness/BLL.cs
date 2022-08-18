using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gerador.Conexao;
using Gerador.Library;


namespace Gerador.Business
{
    /// <summary>
    /// Classe BLL
    /// Criador: Marcos Morais (mmstec@gmail.com)
    /// Criada em 22/04/2010
    /// </summary>
    public class BLL
    {
        /// <summary>
        /// atributos da classe
        /// </summary>
        public string strData = null;
        public string[] arrTabelas = null;
        public string s = null;
        public string tb = null;
        public StringBuilder objCodigo = null;
        public Conexao.Conexao objBanco = null;

        public SqlDataReader objDr = null;
        private Library.Library objLib = null;
        private int nunrec = 0;

        /// <summary>
        /// contrutor da classe
        /// </summary>
        public BLL()
        {
            strData = DateTime.Today.ToShortDateString();
            s = " ";
            tb = "      ";
        }

        /// <summary>
        /// gera classe com as regras do neg�cio. 
        /// </summary>
        /// <param name="_tabelas"></param>
        /// <param name="_conexao"></param>
        /// <param name="_banco"></param>
        /// <param name="_namespace"></param>
        /// <returns></returns>
        public StringBuilder GerarClasseBLL(string[] _tabelas, string _conexao, string _banco, string _namespace)
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

            foreach (string strTabela in _tabelas)
            {
                objCodigo.AppendLine();
                objCodigo.AppendLine("#region classe " + strTabela);
                objCodigo.AppendLine();
                objCodigo.AppendLine("  /// <summary>");
                objCodigo.AppendLine("  /// Business Logic Layer - BLL");
                objCodigo.AppendLine("  /// Descri��o.: Respons�vel pelos m�todos com as regras de neg�cio");
                objCodigo.AppendLine("  /// Autor.....: Marcos Morais de Sousa");
                objCodigo.AppendLine("  /// Data......: " + strData);
                objCodigo.AppendLine("  /// Email.....: mmstec@gmail.com");
                objCodigo.AppendLine("  /// </summary>");
                
                objCodigo.AppendLine("  public class " + strTabela + "");
                objCodigo.AppendLine("  {");
                objCodigo.AppendLine("      //M�TODOS");

                //PARA ACRESCENTAR NOVOS METODOS, INSIRA ABAIXO DESTA MENSAGEM

                // M�TODO Void InsertId(registro) =======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Insere os registros do banco e retorna o n�mero de linhas afetadas.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public int InserirID(Entity." + strTabela + " registro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necess�rios");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.InserirID(registro);");
                objCodigo.AppendLine("      }");
                // M�TODO Void InsertId(registro) ========================================================================

                // M�TODO Void Insert(registro) ========================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Insere os registros do banco");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public void Inserir(Entity." + strTabela + " registro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necess�rios");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          cmd.Inserir(registro);");
                objCodigo.AppendLine("      }");
                // M�TODO Void Insert(registro) ==================================================

                // M�TODO void Update(regitros,_filtro) ==========================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Atualiza os registros do banco.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public void Alterar(Entity." + strTabela + " registro, string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necess�rios");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          cmd.Alterar(registro,_filtro);");
                objCodigo.AppendLine("      }");
                // M�TODO void Update(regitros,_filtro) =========================================

                // M�TODO void Delete(_filtro) ==================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Apaga os registros do banco.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public void Delete(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necess�rios");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          cmd.Excluir(_filtro);");
                objCodigo.AppendLine("      }");
                // M�TODO void Delete(_filtro) =================================================

                // M�TODO int DeleteId(_filtro) ================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Apaga os registros do banco e retorna o n�mero de linhas afetadas.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public int ExcluirID(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necess�rios");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.ExcluirID(_filtro);");
                objCodigo.AppendLine("      }");
                // M�TODO int DeleteId(_filtro) ================================================

                // LIST INICIO //===============================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Lista os registros da base de dados.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>Void</returns>");
                objCodigo.AppendLine("      public List<Entity." + strTabela + " > Listar()");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("        try");
                objCodigo.AppendLine("        {");
                objCodigo.AppendLine("          //aqui entra os tratamentos necess�rios");
                objCodigo.AppendLine("          DAL." + strTabela + " obj = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return obj.Listar();");
                objCodigo.AppendLine("        }");
                objCodigo.AppendLine("        catch");
                objCodigo.AppendLine("        {");
                objCodigo.AppendLine("          return null;");
                objCodigo.AppendLine("        }");
                objCodigo.AppendLine("      }");
                // LIST FIM //===================================================================

                // M�TODO FindByQuery ===========================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros passados por query e retorna um DataTable..");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"filtro da consulta</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindByQuery(string _query)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.FindByQuery(_query);");
                objCodigo.AppendLine("      }");
                // M�TODO FindByQuery ===============================================================

                // M�TODO FindAll() =================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindAll()");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.FindAll();");
                objCodigo.AppendLine("      }");
                // M�TODO FindAll() ========================================================================

                // M�TODO FindAll() ========================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordena��o</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindAll(String _orderby)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.FindAll(_orderby);");
                objCodigo.AppendLine("      }");
                // M�TODO FindAll() ========================================================================

                // M�TODO FindAll() ========================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param=\"_orderby\">campo de ordena��o</param>");
                objCodigo.AppendLine("      /// <param=\"_asc|desc\">acendente|descendente</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindAll(String _orderby, String _asc)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.FindAll(_orderby, _asc);");
                objCodigo.AppendLine("      }");
                // M�TODO FindAll() ========================================================================


                // M�TODO FindByWhere ======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindByWhere(string _filtro)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.FindByWhere(_filtro);");
                objCodigo.AppendLine("      }");
                // M�TODO FindByWhere ====================================================================

                // M�TODO FindByWhere com filtro =========================================================
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
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.FindByWhere(_filtro, _orderby);");
                objCodigo.AppendLine("      }");
                // M�TODO FindByWhere com filtro ===========================================================

                // M�TODO FindByWhere ======================================================================
                objCodigo.AppendLine();
                objCodigo.AppendLine("      /// <summary>");
                objCodigo.AppendLine("      /// MARCOS:");
                objCodigo.AppendLine("      /// Seleciona todos os registros e retorna um DataTable.");
                objCodigo.AppendLine("      /// </summary>");
                objCodigo.AppendLine("      /// <param name=\"_filtro (\"id_campo = 1 AND campo1 = 'texto' OR campo2 LIKE 'r%'\")\">filtro da consulta</param>");
                objCodigo.AppendLine("      /// <param name=\"_orderby\">campo de ordena��o</param>");
                objCodigo.AppendLine("      /// <param name=\"_direction\">crescente ou decrescente</param>");
                objCodigo.AppendLine("      /// <returns>DataTable</returns>");
                objCodigo.AppendLine("      public DataTable FindByWhere(String _filtro, String _orderby, String _direction)");
                objCodigo.AppendLine("      {");
                objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                objCodigo.AppendLine("          return cmd.FindByWhere(_filtro, _orderby, _direction);");
                objCodigo.AppendLine("      }");
                // M�TODO FindByWhere =======================================================================
                
                // M�TODO FindAllBy por campo ===============================================================
                objBanco = new Conexao.Conexao(_conexao);
                objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                objLib = new Library.Library();
                nunrec = objDr.FieldCount;
                for (int i = 0; i < nunrec - 1; i++)
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
                    objCodigo.AppendLine("          DAL." + strTabela + " cmd = new DAL." + strTabela + "();");
                    objCodigo.AppendLine("          return cmd.FindBy_" + objDr.GetName(i) + "(_" + objDr.GetName(i) + ");");
                    objCodigo.AppendLine("      }");
                }
                // M�TODO FindAll() ========================================================================

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