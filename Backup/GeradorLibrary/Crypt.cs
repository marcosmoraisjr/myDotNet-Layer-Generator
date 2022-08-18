using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Gerador.Library 
{
    /// <summary>
    /// Enumerator com os tipos de classes para criptografia.
    /// </summary>
    public enum CryptProvider
    {
        /// <summary>
        /// Representa a classe base para implementa��es criptografia dos algoritmos sim�tricos Rijndael.
        /// </summary>
        Rijndael,
        /// <summary>
        /// Representa a classe base para implementa��es do algoritmo RC2.
        /// </summary>
        RC2,
        /// <summary>
        /// Representa a classe base para criptografia de dados padr�es (DES - Data Encryption Standard).
        /// </summary>
        DES,
        /// <summary>
        /// Representa a classe base (TripleDES - Triple Data Encryption Standard).
        /// </summary>
        TripleDES
    }

    /// <summary>
    /// Classe auxiliar com m�todos para criptografia de dados.
    /// </summary>
    public class Crypt
    {
        #region Private members
		private string _key = string.Empty;
        private CryptProvider _cryptProvider;
        private SymmetricAlgorithm _algorithm;
        private void SetIV()
        {
            switch (_cryptProvider)
            {
                case CryptProvider.Rijndael:
                    _algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };
                    break;
                default:
                    _algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };
                    break;
            }
        }
	    #endregion

        #region Properties
        /// <summary>
        /// Chave secreta para o algoritmo sim�trico de criptografia.
        /// </summary>
		public string Key
		{
			get { return _key; }
			set { _key = value; }
		}
        #endregion

        #region Constructors
        /// <summary>
        /// Contrutor padr�o da classe, � setado um tipo de criptografia padr�o.
        /// </summary>
        public Crypt()
        {
            _algorithm = new RijndaelManaged();
            _algorithm.Mode = CipherMode.CBC;
            _cryptProvider = CryptProvider.Rijndael;
        }
        /// <summary>
        /// Construtor com o tipo de criptografia a ser usada.
        /// </summary>
        /// <param name="cryptProvider">Tipo de criptografia.</param>
        public Crypt(CryptProvider cryptProvider)
		{	
			// Seleciona algoritmo sim�trico
			switch(cryptProvider)
			{
				case CryptProvider.Rijndael:
					_algorithm = new RijndaelManaged();
					_cryptProvider = CryptProvider.Rijndael;
					break;
				case CryptProvider.RC2:
					_algorithm = new RC2CryptoServiceProvider();
					_cryptProvider = CryptProvider.RC2;
					break;
				case CryptProvider.DES:
					_algorithm = new DESCryptoServiceProvider();
					_cryptProvider = CryptProvider.DES;
					break;
				case CryptProvider.TripleDES:
					_algorithm = new TripleDESCryptoServiceProvider();
					_cryptProvider = CryptProvider.TripleDES;
					break;
			}
			_algorithm.Mode = CipherMode.CBC;
		}
        #endregion

        #region Public methods
        /// <summary>
        /// Gera a chave de criptografia v�lida dentro do array.
        /// </summary>
        /// <returns>Chave com array de bytes.</returns>
        public virtual byte[] GetKey()
        {
            string salt = string.Empty;

            // Ajuta o tamanho da chave se necess�rio e retorna uma chave v�lida
            if (_algorithm.LegalKeySizes.Length > 0)
            {
                // Tamanho das chaves em bits
                int keySize = _key.Length * 8;
                int minSize = _algorithm.LegalKeySizes[0].MinSize;
                int maxSize = _algorithm.LegalKeySizes[0].MaxSize;
                int skipSize = _algorithm.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    // Busca o valor m�ximo da chave
                    _key = _key.Substring(0, maxSize / 8);
                }
                else if (keySize < maxSize)
                {
                    // Seta um tamanho v�lido
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;
                    if (keySize < validSize)
                    {
                        // Preenche a chave com arterisco para corrigir o tamanho
                        _key = _key.PadRight(validSize / 8, '*');
                    }
                }
            }
            PasswordDeriveBytes key = new PasswordDeriveBytes(_key, ASCIIEncoding.ASCII.GetBytes(salt));
            return key.GetBytes(_key.Length);
        }
        /// <summary>
        /// Encripta o dado solicitado.
        /// </summary>
        /// <param name="plainText">Texto a ser criptografado.</param>
        /// <returns>Texto criptografado.</returns>
        public virtual string Encrypt(string plainText)
        {
            byte[] plainByte = ASCIIEncoding.ASCII.GetBytes(plainText);
            byte[] keyByte = GetKey();

            // Seta a chave privada
            _algorithm.Key = keyByte;
            SetIV();

            // Interface de criptografia / Cria objeto de criptografia
            ICryptoTransform cryptoTransform = _algorithm.CreateEncryptor();

            MemoryStream _memoryStream = new MemoryStream();

            CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Write);

            // Grava os dados criptografados no MemoryStream
            _cryptoStream.Write(plainByte, 0, plainByte.Length);
            _cryptoStream.FlushFinalBlock();

            // Busca o tamanho dos bytes encriptados
            byte[] cryptoByte = _memoryStream.ToArray();

            // Converte para a base 64 string para uso posterior em um xml
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));
        }
        /// <summary>
        /// Desencripta o dado solicitado.
        /// </summary>
        /// <param name="cryptoText">Texto a ser descriptografado.</param>
        /// <returns>Texto descriptografado.</returns>
        public virtual string Decrypt(string cryptoText)
        {
            // Converte a base 64 string em num array de bytes
            byte[] cryptoByte = Convert.FromBase64String(cryptoText);
            byte[] keyByte = GetKey();

            // Seta a chave privada
            _algorithm.Key = keyByte;
            SetIV();

            // Interface de criptografia / Cria objeto de descriptografia
            ICryptoTransform cryptoTransform = _algorithm.CreateDecryptor();
            try
            {
                MemoryStream _memoryStream = new MemoryStream(cryptoByte, 0, cryptoByte.Length);
                CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Read);
                // Busca resultado do CryptoStream
                StreamReader _streamReader = new StreamReader(_cryptoStream);
                return _streamReader.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
