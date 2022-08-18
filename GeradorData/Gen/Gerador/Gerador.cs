using System;
using System.Collections.Generic;
using System.Text;

namespace Gerador
{
    public class Gerador
    {
        // atributos
        public string[] arrTabelas = null;
        public int intQnttabelas = 0;
        public string strData = null;
        public string n1 = null;
        public string s = null;
        public string tb = null;
        public StringBuilder codigo = null;

        // construtor
        public Gerador()
        {
            strData = DateTime.Today.ToShortDateString();
            n1 = "\n";
            s = " ";
            tb = "      ";

        }


        // metodos

        public StringBuilder GeraCodigoDO(string tabela)
        {

            codigo = new StringBuilder();

            codigo.Append("using System;" + n1);
            codigo.Append("using System.Collections.Generic;" + n1);
            codigo.Append("using System.Text;" + n1);
            codigo.Append("using System.Data;" + n1);
            codigo.Append("using System.Data.OleDb;" + n1);

            return codigo;



        }
    }
}
