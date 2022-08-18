using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Gerador.Conexao;
using Gerador.Library;

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
        public string strData = null;
        public string s = null;
        public string tb = null;
        public StringBuilder objCodigo = null;
        public Conexao.Conexao objBanco = null;
        public SqlDataReader objDr = null;
        private Library.Library objLib = null;


        // CONSTRUTOR
        public Entity()
        {
            strData = DateTime.Today.ToShortDateString();
            s  = "  ";
            tb = "      ";
        }

        // METODOS
        public StringBuilder GeraCodigoTAB(string[] _tabelas, string _conexao, string _banco, string _namespace)
        {
            try
            {

                objCodigo = new StringBuilder();
                objCodigo.AppendLine("using System;");
                objCodigo.AppendLine("using System.Collections.Generic;");
                objCodigo.AppendLine("using System.Linq;");
                objCodigo.AppendLine("using System.Text;");
                objCodigo.AppendLine();
                objCodigo.AppendLine("namespace " + _namespace + ".Entity");
                objCodigo.AppendLine("{");

                foreach (string strTabela in _tabelas)
                {
                    // Abre conexão com o banco
                    objBanco = new Conexao.Conexao(_conexao);
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

    }
}
