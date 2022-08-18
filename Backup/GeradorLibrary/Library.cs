using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Gerador.Library
{
    /// <summary>
    /// Classe Library
    /// Criador: Marcos Morais (mmstec@gmail.com)
    /// Criada em 22/04/2010
    /// </summary>
    public class Library
    {
        private string strParam = null;
        private string strTipo = null;

        /// <summary>
        /// Define qual o tipo a variável do banco de dados vai ter
        /// </summary>
        /// <param name="_coluna">string</param>
        /// <param name="_tipo">string</param>
        /// <returns></returns>
        public string UpdateParam(string _coluna, string _tipo)
        {
            // Define qual o tipo da coluna setar o tipo do atributo
            switch (_tipo)
            {
                case "bigint":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "binary":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "bit":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "char":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "datetime":
                    strParam = " " + _coluna + " = CONVERT(DATETIME, '" + "\" + _" + _coluna + " + \"', 103) ";
                    break;
                case "decimal":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "float":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "image":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "int":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "money":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "nchar":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "ntext":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "numeric":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "nvarchar":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "real":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "smalldatetime":
                    strParam = " " + _coluna + " = CONVERT(DATETIME, '" + "\" + _" + _coluna + " + \"', 103) ";
                    break;
                case "smallint":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "smallmoney":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "text":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "tinyint":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "varbinary":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "varchar":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                default:
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
            }
            return strParam;
        }

        /// <summary>
        /// Define qual o tipo a variável do banco de dados vai ter
        /// </summary>
        /// <param name="_coluna">string</param>
        /// <param name="_tipo">string</param>
        /// <returns></returns>
        public string SelectParam(string _coluna, string _tipo)
        {
            // Define qual o tipo da coluna setar o tipo do atributo
            switch (_tipo)
            {
                case "bigint":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "binary":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "bit":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "char":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "datetime":
                    strParam = " " + _coluna + " = CONVERT(DATETIME, '" + "\" + _" + _coluna + " + \"', 103) ";
                    break;
                case "decimal":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "float":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "image":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "int":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "money":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "nchar":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "ntext":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "numeric":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "nvarchar":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "real":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "smalldatetime":
                    strParam = " " + _coluna + " = CONVERT(DATETIME, '" + "\" + _" + _coluna + " + \"', 103) ";
                    break;
                case "smallint":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "smallmoney":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "text":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                case "tinyint":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "varbinary":
                    strParam = " " + _coluna + " = " + "  \" + _" + _coluna + " + \" ";
                    break;
                case "varchar":
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
                default:
                    strParam = " " + _coluna + " = " + " '\" + _" + _coluna + " + \"' ";
                    break;
            }
            return strParam;
        }

        /// <summary>
        /// Define qual o tipo a variável do banco de dados vai ter
        /// </summary>
        /// <param name="_coluna">string</param>
        /// <param name="_tipo">string</param>
        /// <returns></returns>
        public string InsertParam(string _coluna, string _tipo)
        {
            // Define qual o tipo da coluna setar o tipo do atributo
            switch (_tipo)
            {
                case "bigint":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "binary":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "bit":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "char":
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
                case "datetime":
                    strParam = " CONVERT(DATETIME, '" + "\" + _" + _coluna + " + \"', 103) ";
                    break;
                case "decimal":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "float":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "image":
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
                case "int":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "money":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "nchar":
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
                case "ntext":
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
                case "numeric":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "nvarchar":
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
                case "real":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "smalldatetime":
                    strParam = "  CONVERT(DATETIME, '" + "\" + _" + _coluna + " + \"', 103) ";
                    break;
                case "smallint":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "smallmoney":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "text":
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
                case "tinyint":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "varbinary":
                    strParam =  "\" + _" + _coluna + " + \" ";
                    break;
                case "varchar":
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
                default:
                    strParam =  " '\" + _" + _coluna + " + \"' ";
                    break;
            }
            return strParam;
        }

        /// <summary>
        /// Define qual o tipo a variável do banco de dados vai ter
        /// </summary>
        /// <param name="_tipo"></param>
        /// <returns></returns>
        public string DefineTipo(string _tipo)
        {
            // Define qual o tipo da coluna setar o tipo do atributo
            switch (_tipo)
            {
                case "bigint":
                    strTipo = "Int64";
                    break;
                case "binary":
                    strTipo = "Byte";
                    break;
                case "bit":
                    strTipo = "byte";
                    break;
                case "char":
                    strTipo = "char";
                    break;
                case "datetime":
                    strTipo = "DateTime";
                    break;
                case "decimal":
                    strTipo = "decimal";
                    break;
                case "float":
                    strTipo = "float";
                    break;
                case "image":
                    strTipo = "Byte";
                    break;
                case "int":
                    strTipo = "int";
                    break;
                case "money":
                    strTipo = "Decimal";
                    break;
                case "nchar":
                    strTipo = "string";
                    break;
                case "ntext":
                    strTipo = "StringBuilder";
                    break;
                case "numeric":
                    strTipo = "Int64";
                    break;
                case "nvarchar":
                    strTipo = "string";
                    break;
                case "real":
                    strTipo = "float";
                    break;
                case "smalldatetime":
                    strTipo = "DateTime";
                    break;
                case "smallint":
                    strTipo = "Int32";
                    break;
                case "smallmoney":
                    strTipo = "Decimal";
                    break;
                case "text":
                    strTipo = "StringBuilder";
                    break;
                case "tinyint":
                    strTipo = "Int16";
                    break;
                case "varbinary":
                    strTipo = "byte";
                    break;
                case "varchar":
                    strTipo = "string";
                    break;
                default:
                    strTipo = "string";
                    break;
            }
            return strTipo;
        }
    }

}
