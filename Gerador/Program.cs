using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerador;
using System.IO;
using System.Text;
using System.Collections;
using Gerador.Entity;
using Gerador.Library;
using System.Reflection;
using System.Security.Principal;

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
        #region paramentros
        static string linha = new string('=', 47);
        static String nomedoaplicativo = Application.ProductName ;
        static String versaodoaplicativo = Application.ProductVersion;
        static String messageboxtitulo = nomedoaplicativo + " " + versaodoaplicativo;
        static String chaveText = Library.LibraryID.RecuperaIDProcessador();
        static String encryptedText = string.Empty;
        static String decryptedText = string.Empty;
        static String codigoverde = string.Empty;
        //static String nomedoarquivo = @"C:\windows\mmsteclicencadeuso" + nomedoaplicativo + ".ini";
        static String nomedoarquivo = @"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\mmsteclicencadeuso" + nomedoaplicativo + ".ini";
        static String nomedoarquivoflag = @"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\flag.ini";// ARQUIVO IMPORTANTE. QQ COISA APAGAR ESSE ARQUIVO
        static String dataHoje = DateTime.Now.ToShortDateString();
        static String validade = string.Empty;
        static TimeSpan diff;
        #endregion


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form2010());

            // cria um objeto da classe Random
            Random rnd = new Random();
            // gera um número aleatório na faixa
            // 10 até 20
            int numero = rnd.Next(10, 21);
            //Marcos: criptografa o nome da aplicação que será usado como chave para gerar o código que permite o uso do aplicativo
            //para aumentar a segurança, pode usar o id do processador em vez do nome do aplicativo.
            Library.LibraryCrypt _cryptcodigoverde = new Library.LibraryCrypt(CryptProvider.Rijndael);
            _cryptcodigoverde.Key = "81023484";
            //codigoverde = _cryptcodigoverde.Encrypt(nomedoaplicativo.Trim());
            codigoverde = _cryptcodigoverde.Encrypt(chaveText);

            #region verifica existência arquivo flag. Se não existe: cria
            if (!File.Exists(nomedoarquivoflag))
            {
                try
                {
                    StreamWriter valor = new StreamWriter(nomedoarquivoflag, false, Encoding.ASCII);
                    valor.Write(dataHoje);
                    valor.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cód:0.0 Uma situação indesejada ocorreu. \n" + linha + "\nCÓDIGO:\n" + ex.ToString() + "\n" + linha + "\n", messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                try
                {
                    LibraryLerArquivo objflag = new LibraryLerArquivo();
                    if (Convert.ToDateTime(objflag.LerLinhaArquivo(nomedoarquivoflag)) > Convert.ToDateTime(dataHoje))
                    {
                        MessageBox.Show("Cód:1.0 Acesso negado! \n\nVerifique a data do seu sistema.", messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        #region verifica existencia do arquivo criptografado de validade
                        if (File.Exists(nomedoarquivo))
                        {
                            try
                            {
                                LibraryLerArquivo obj = new LibraryLerArquivo();
                                Library.LibraryCrypt _crypt = new Library.LibraryCrypt(CryptProvider.Rijndael);
                                //traduz o código criptografado contido em um arquivo texto para verificação se o aplicativo corrente tem permissão de execução
                                _crypt.Key = chaveText; ///////IMPORTANTE 
                                decryptedText = _crypt.Decrypt(obj.LerLinhaArquivo(nomedoarquivo)).Trim();

                                /*
                                DateTimePicker dta1 = new DateTimePicker();
                                DateTimePicker dta2 = new DateTimePicker();
                                dta1.Text = String.Format("{0:dd/MM/yyyy}", decryptedText.Substring(0, 10));
                                dta2.Text = String.Format("{0:dd/MM/yyyy}", decryptedText.Substring(10, 10));
                                */

                                string data1 = decryptedText.Substring(0, 10);
                                string data2 = decryptedText.Substring(10, 10);
                                validade = string.Format("Prazo de validade: {0} a {1}.           ", data1.ToString(), data2.ToString());

                                if (Convert.ToDateTime(data1) > Convert.ToDateTime(dataHoje) || Convert.ToDateTime(data2) < Convert.ToDateTime(dataHoje))
                                {
                                    string txtmensagem = validade +"  É necessário enviar o CÓDIGO-VERDE ao desenvolvedor (marcosmorais@mmstec.com).";
                                    //MessageBox.Show("Acesso negado! \n\nEntre em contato com o desenvolvedor (email:mmstec@gmail.com) e informe o Código Verde: \n\nCÓDIGO VERDE: " + codigoverde.ToString(), messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    Application.Run(new FormEnviarEmail("Cód.1 Acesso negado! ", txtmensagem, codigoverde.Trim()));
                                }
                                else
                                {
                                    /*
                                    diff = Convert.ToDateTime(data2) - Convert.ToDateTime(dataHoje);
                                    if (Convert.ToInt32(diff.Days) <= 5)
                                    {
                                        MessageBox.Show("O software vai expirar em " + decryptedText.ToString() + ".\n\nEntre em contato com o desenvolvedor (email:mmstec@gmail.com) e informe o Código Verde. \n\nCÓDIGO VERDE: " + codigoverde.ToString(), messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }*/

                                    /*try
                                    {
                                        //Code
                                        WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                                        WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
                                        //To check if user is administrator use IsInRole method
                                        MessageBox.Show("Is Adminisitrator = " + windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator)+"\n"+teste);
                                    }
                                    catch { }
                                     */
                                    Application.Run(new FormPrincipal(validade));
                                }
                            }
                            catch
                            {
                                string txtmensagem = validade +"  É necessário enviar o CÓDIGO-VERDE ao desenvolvedor (marcosmorais@mmstec.com).";
                                Application.Run(new FormEnviarEmail("Cód.2 Acesso negado! ",txtmensagem.Trim(), codigoverde.Trim()));
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Você não tem permissão de executar o sistema! \n\nEntre em contato com o desenvolvedor (email:mmstec@gmail.com) e informe o Código Verde: \n\nCÓDIGO VERDE: " + codigoverde.ToString(), messageboxtitulo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //Application.Run(new FormEnviarEmail(codigoverde.ToString()));
                            string txtmensagem = validade + "  Seu sistema não esta autorizado. É necessário enviar o CÓDIGO-VERDE ao desenvolvedor (marcosmorais@mmstec.com).";
                            Application.Run(new FormEnviarEmail("Cód.3 Acesso restrito! ", txtmensagem.Trim(), codigoverde.Trim()));
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cód:1.1 Uma situação não prevista ocorreu. \n" + linha + "\nCÓDIGO:\n" + ex.ToString() + "\n" + linha + "\n", messageboxtitulo + " (" + validade + ")", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    StreamWriter valor = new StreamWriter(nomedoarquivoflag, false, Encoding.ASCII);
                    valor.Write(dataHoje);
                    valor.Close();
                    if (File.Exists(nomedoarquivoflag))
                        File.Delete(nomedoarquivoflag);
                }
            }
            #endregion
        }
    }

    
}

