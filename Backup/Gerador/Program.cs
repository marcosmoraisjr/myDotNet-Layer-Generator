using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerador;
using System.IO;
using System.Text;
using System.Collections;
using Gerador.Entity;
using Gerador.Library;

namespace Gerador
{
    static class Program
    {
        /**
        string win = System.Environment.GetEnvironmentVariable("OS");
        string processor = System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
        string arquitet = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
        label4.Text = win;
        label5.Text = processor;
        label6.Text = arquitet;
        **/

        static String nomedoaplicativo = Application.ProductName ;
        static String versaodoaplicativo = Application.ProductVersion;
        static String messageboxtitulo = nomedoaplicativo + " " + versaodoaplicativo;
        static String encryptedText = string.Empty;
        static String decryptedText = string.Empty;
        static String codigoverde = string.Empty;
        static String nomedoarquivo = @"c:\windows\mmsteclicencadeuso" + nomedoaplicativo + ".ini";
        static String nomedoarquivoflag = @"c:\windows\flag.ini";
        static String dataHoje = DateTime.Now.ToShortDateString();
        static TimeSpan diff;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form2010());

            //Marcos: criptografa o nome da aplica��o que ser� usado como chave para gerar o c�digo que permite o uso do aplicativo
            //para aumentar a seguran�a, pode usar o id do processador em vez do nome do aplicativo.
            Library.Crypt _cryptcodigoverde = new Library.Crypt(CryptProvider.Rijndael);
            _cryptcodigoverde.Key = "81023484";
            codigoverde = _cryptcodigoverde.Encrypt(nomedoaplicativo.Trim());

            if (!File.Exists(nomedoarquivoflag))
            {
                StreamWriter valor = new StreamWriter(nomedoarquivoflag, false, Encoding.ASCII);
                valor.Write(dataHoje);
                valor.Close();
            }

            if (File.Exists(nomedoarquivoflag))
            {
                try
                {
                    LerArquivo objflag = new LerArquivo();
                    if (Convert.ToDateTime(objflag.LerLinhaArquivo(nomedoarquivoflag)) > Convert.ToDateTime(dataHoje))
                    {
                        MessageBox.Show("Acesso negado! \n\nVerifique a data do seu sistema.", messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (File.Exists(nomedoarquivo))
                        {
                            LerArquivo obj = new LerArquivo();
                            Library.Crypt _crypt = new Library.Crypt(CryptProvider.Rijndael);
                            //traduz o c�digo criptografado contido em um arquivo texto para verifica��o se o aplicativo corrente tem permiss�o de execu��o
                            _crypt.Key = nomedoaplicativo;
                            decryptedText = _crypt.Decrypt(obj.LerLinhaArquivo(nomedoarquivo));

                            if (Convert.ToDateTime(decryptedText) < Convert.ToDateTime(dataHoje))
                            {
                                MessageBox.Show("Acesso negado! \n\nEntre em contato com o desenvolvedor (email:mmstec@gmail.com) e informe o C�digo Verde: \n\nC�DIGO VERDE: " + codigoverde.ToString(), messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                diff = Convert.ToDateTime(decryptedText) - Convert.ToDateTime(dataHoje);
                                if (Convert.ToInt32(diff.Days) <= 5)
                                {
                                    MessageBox.Show("O software vai expirar em " + decryptedText.ToString() + ".\n\nEntre em contato com o desenvolvedor (email:mmstec@gmail.com) e informe o C�digo Verde. \n\nC�DIGO VERDE: " + codigoverde.ToString(), messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                Application.Run(new Form2010());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Voc� n�o tem permiss�o de executar o sistema! \n\nEntre em contato com o desenvolvedor (email:mmstec@gmail.com) e informe o C�digo Verde: \n\nC�DIGO VERDE: " + codigoverde.ToString(), messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Uma situa��o n�o prevista ocorreu. \n\nC�DIGO: " + ex.ToString(), messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    StreamWriter valor = new StreamWriter(nomedoarquivoflag, false, Encoding.ASCII);
                    valor.Write(dataHoje);
                    valor.Close();
                }
                
            }
        }
    }

    
}

