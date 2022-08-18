using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Gerador.Library;
using System.Threading;
using System.Text.RegularExpressions;

namespace Gerador
{
    partial class FormEnviarEmail : Form
    {
        
        public FormEnviarEmail(string _titulo,string _texto, string _codigoverde)
        {
            InitializeComponent();
            
            this.Text = String.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
            this.textBoxCodigoVerde.Text = _codigoverde;
            this.labelTitulo.Text = _titulo;
            this.labelTexto.Text = _texto;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {

                string email = textBoxEmailRemetente.Text.Trim();

                Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (rg.IsMatch(email))
                {
                    Thread thr = new Thread(delegate()
                    {
                        Gerador.Library.Message.Processando("Aguarde", "Enviando email...");
                    });
                    thr.Start();
                    try
                    {
                        Email.EnviarEmail(textBoxEmailRemetente.Text.Trim(), "mmstec@gmail.com", this.Text.Trim(), string.Format("Segue os dados necessários para liberação da aplicação. <hr /><br />CÓDIGO-VERDE: {0} <br />APLICAÇÃO: {1} <br />REMETENTE: {2}", textBoxCodigoVerde.Text.Trim(), Application.ProductName.Trim(), textBoxEmailRemetente.Text.Trim()));
                        thr.Abort();
                        MessageBox.Show("Email enviado com sucesso \n\nde....: " + email.Trim() + "\npara: mmstec@gmail.com. \n\nAguarde contato.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch
                    {
                        thr.Abort();
                        MessageBox.Show("Email não pôde ser enviado.\n\nVerifique suas conexões de rede.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    finally
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show("Email informado não é válido." , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uma situação não prevista ocorreu. \n\nCÓDIGO: " + ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }



    }
}
