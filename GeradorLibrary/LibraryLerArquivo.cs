using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Gerador.Library
{
     /// <summary>
    /// Classe LerArquivo
    /// Criador: Marcos Morais (mmstec@gmail.com)
    /// Criada em 22/04/2010
    /// </summary>
    public class LibraryLerArquivo
    {

        private string arquivo;
        private string mensagem;
        private string resultado;
        public String LerLinhaArquivo2(String _caminho)
        {
            List<string> mensagemLinha = new List<string>();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "xxxxxxxxxo";
                openFileDialog.InitialDirectory = @""+_caminho+""; //Se ja quiser em abrir em um diretorio especifico
                openFileDialog.Filter = "Todos os arquivos (*.*)|*.*|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    arquivo = openFileDialog.FileName;
            }
            
            if (String.IsNullOrEmpty(arquivo))
            {
                MessageBox.Show("Arquivo Inválido", "Salvar Como", MessageBoxButtons.OK);
            }
            else
            {
                using (StreamReader texto = new StreamReader(arquivo))
                {
                    while ((mensagem = texto.ReadLine()) != null)
                    {
                        mensagemLinha.Add(mensagem);
                    }
                }
                int registro = mensagemLinha.Count; //total de linhas do arquivo.
                for (int i = 0; i < mensagemLinha.Count; i++)
                {
                    TextBox textbox1 = new TextBox();
                    textbox1.Text += mensagemLinha[i];
                    File.WriteAllText(arquivo, mensagemLinha[i] + "1");
                    resultado = textbox1.Text;
                }
            }
            return resultado;
        }

        public String LerLinhaArquivo(String _caminho)
        {
            String sResultado = "";
            if (File.Exists(_caminho))
            {

                String sLine = "";

                ArrayList arrText = new ArrayList();
                StreamReader objReader = new StreamReader(_caminho);

                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();

                foreach (string sOutput in arrText)
                {
                    //Console.WriteLine(sOutput);
                    sResultado = sOutput;
                }
            }
            return sResultado;
        }

    }
}
