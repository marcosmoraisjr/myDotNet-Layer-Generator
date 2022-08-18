using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Gerador.Library
{
    /// <summary>
    /// Enumerator com os tipos de classes para criação de Hash.
    /// </summary>
    public enum HashProvider
    {
        /// <summary>
        /// Computa um hash SHA1 hash para os dados.
        /// </summary>
        SHA1,
        /// <summary>
        /// Computa um hash SHA256 hash para os dados.
        /// </summary>
        SHA256,
        /// <summary>
        /// Computa um hash SHA384 hash para os dados.
        /// </summary>
        SHA384,
        /// <summary>
        /// Computa um hash SHA512 hash para os dados.
        /// </summary>
        SHA512,
        /// <summary>
        /// Representa a classe abstrata para implementações dos algoritmos para criação de hash usando MD5.
        /// </summary>
        MD5
    }
    /// <summary>
    /// Classe auxiliar com métodos para crição de hash dos dados inseridos.
    /// </summary>
    public class LibraryHash
    {
        #region Private members
        private HashAlgorithm _algorithm;
        #endregion

        #region Constructors
        /// <summary>
        /// Contrutor padrão da classe, é setado um tipo de hash padrão.
        /// </summary>
        public LibraryHash()
        {
            _algorithm = new SHA1Managed();
        }
        /// <summary>
        /// Construtor com o tipo de hash a ser usado.
        /// </summary>
        /// <param name="hashProvider">Tipo de Hash.</param>
        public LibraryHash(HashProvider hashProvider)
        {
            switch (hashProvider)
            {
                case HashProvider.MD5:
                    _algorithm = new MD5CryptoServiceProvider();
                    break;
                case HashProvider.SHA1:
                    _algorithm = new SHA1Managed();
                    break;
                case HashProvider.SHA256:
                    _algorithm = new SHA256Managed();
                    break;
                case HashProvider.SHA384:
                    _algorithm = new SHA384Managed();
                    break;
                case HashProvider.SHA512:
                    _algorithm = new SHA512Managed();
                    break;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Monta hash para algum dado texto.
        /// </summary>
        /// <param name="plainText">Texto a ser criado o hash.</param>
        /// <returns>Hash do texto inserido.</returns>
        public string GetHash(string plainText)
        {
            byte[] cryptoByte = _algorithm.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.Length);
        }
        /// <summary>
        /// Cria hash para algum tipo de stream.
        /// </summary>
        /// <param name="fileStream">Stream a ser criado o hash.</param>
        /// <returns>Hash do stream inserido.</returns>
        public string GetHash(FileStream fileStream)
        {
            byte[] cryptoByte;

            cryptoByte = _algorithm.ComputeHash(fileStream);
            fileStream.Close();

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.Length);
        }
        #endregion
    }
}
