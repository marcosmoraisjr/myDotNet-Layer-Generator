using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gerador.Library;
using Gerador.Connection;

namespace Gerador.Entity
{
    /// <summary>
    /// Classe Entity
    /// Criador: Marcos Morais (mmstec@gmail.com)
    /// Criada em 22/04/2010
    /// </summary>
    public class Entity
    {
        // ATRIBUTOS 
        private String strData = DateTime.Today.ToShortDateString();
        private String s = null;
        private String tb = null;
        private StringBuilder objCodigo = null;
        private SqlDataReader objDr = null;
        private Gerador.Library.Library objLib = null;
        private Gerador.Connection.Connection objBanco = null;
        
        // METODOS
        public StringBuilder GeraCodigoTAB(String[] _tabelas, String _conexao, String _banco, String _namespace)
        {
            try
            {

                objCodigo = new StringBuilder();
                objCodigo.AppendLine("using System; ");
                objCodigo.AppendLine("using System.Collections.Generic;");
                objCodigo.AppendLine("using System.Linq;");
                objCodigo.AppendLine("using System.Text;");
                objCodigo.AppendLine();
                objCodigo.AppendLine("namespace " + _namespace + ".Entity");
                objCodigo.AppendLine("{");

                foreach (string strTabela in _tabelas)
                {
                    // Abre conexão com o banco
                    objBanco = new Connection.Connection(_conexao);
                    // Cria o objeto da classe Library
                    objLib = new Library.Library();
                    objCodigo.AppendLine();
                    objCodigo.AppendLine("  /// <summary>");
                    objCodigo.AppendLine("  /// Data Access Layer - DAL<entidades>");
                    objCodigo.AppendLine("  /// Descrição.: Responsável pelas entidades");
                    objCodigo.AppendLine("  /// Autor.....: Marcos Morais de Sousa");
                    objCodigo.AppendLine("  /// Data......: " + strData);
                    objCodigo.AppendLine("  /// Email.....: mmstec@gmail.com");
                    objCodigo.AppendLine("  /// </summary>");

                    objCodigo.AppendLine(tb + "public class " + strTabela + "");
                    objCodigo.AppendLine(tb + "{");
                    objCodigo.AppendLine(tb + tb + "// ATRIBUTOS");

                    // Faz a leitura de todas as colunas da tabela
                    objDr = objBanco.QueryConsulta("SELECT * FROM " + strTabela);
                    // Conta o número de colunas
                    int nunrec = objDr.FieldCount;

                    for (int i = 0; i < nunrec; i++)
                    {
                        // declara os atributos da classe
                        objCodigo.AppendLine(tb + tb + "private " + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " _" + objDr.GetName(i) + ";");
                    }

                    objCodigo.AppendLine();
                    objCodigo.AppendLine(tb + tb + "// PROPIEDADES");

                    for (int i = 0; i < nunrec; i++)
                    {
                        // declara as propriedades da classe
                        objCodigo.AppendLine(tb + tb + "public " + objLib.DefineTipo(objDr.GetDataTypeName(i).ToString()) + " " + objDr.GetName(i));
                        objCodigo.AppendLine(tb + tb + "{");
                        objCodigo.AppendLine(tb + tb + tb + "get { return _" + objDr.GetName(i) + "; }");
                        objCodigo.AppendLine(tb + tb + tb + "set { _" + objDr.GetName(i) + " = value; }");
                        objCodigo.AppendLine(tb + tb + "}");

                    }
                    objCodigo.AppendLine(tb + "}");
                    // fecha conexão
                    objBanco.CloseConn();
                    objLib = null;
                }
                objCodigo.AppendLine("}");
                return objCodigo;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StringBuilder GeraCodigoTAB(String _tabela, String _conexao, String _banco, String _namespace)
        {
            string[] _tabelas = new string[1];
            _tabelas[0] = _tabela;
            return GeraCodigoTAB(_tabelas, _conexao, _banco, _namespace);
        }
    }
}
