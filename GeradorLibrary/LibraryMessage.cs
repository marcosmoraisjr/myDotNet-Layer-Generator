using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Gerador.Library
{
    public class Message
    {
        private Message()
        {
        }

        /// <summary>
        /// Autor: Marcos
        /// Interação com o usuário, principalemente em processos demorados
        /// </summary> 
        /// <param name="texto">Aviso</param>
        /// <returns>Aviso</returns>
        public static void Processando(string _strTitulo, string _strTexto)
        {
            /*
            try
            {
                FormProcessando frm = new FormProcessando();
                frm._titulo = _strTitulo;
                frm._texto = _strTexto;
                frm.ControlBox = false;
                frm.ShowDialog();
            }
            catch (ThreadAbortException abortException)
            {
                MessageBox.Show((string)abortException.ExceptionState);
            }
            finally { }
            */
        }
    }

        
}
