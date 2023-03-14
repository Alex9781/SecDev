using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace LR1
{
    internal class SecurityManager
    {
        private readonly string _accountsFileName;
        private readonly byte[] _keyBytes;
        private readonly byte[] _ivBytes;

        private bool _passwordValid;

        private List<Account>? _accounts;

        /// <summary>
        /// Creates a new instance of Security Manager
        /// </summary>
        /// <param name="password">Master password</param>
        public SecurityManager(string password)
        {
            _accountsFileName = "./accounts.bin";         

            _keyBytes = HashString_SHA256(password);

            _ivBytes = new byte[_keyBytes.Length / 2];
            Array.Copy(_keyBytes, _ivBytes, _keyBytes.Length / 2);
        }

        /// <summary>
        /// Checks if file with accounts exists
        /// </summary>
        /// <returns>Return true if file exists and not empty</returns>
        public bool FileExist()
        {
            if (!new FileInfo(_accountsFileName).Exists) return false;
            return new FileInfo(_accountsFileName).Length != 0;
        }

        /// <summary>
        /// Checks if provided master password can decrypt encrypted file with accounts
        /// </summary>
        /// <returns>Returns true if master password can decrypt file</returns>
        public bool PasswordValid()
        {
            try
            {
                ReadAccountsFile();
                _passwordValid = true;
            }
            catch (Exception)
            {
                _passwordValid = false;
            }
            return _passwordValid;
        }

        /// <summary>
        /// Returns List of Accounts
        /// </summary>
        /// <returns>List of Accounts</returns>
        /// <exception cref="Exception">Causes exception if password invalid or accounts does not exist</exception>
        public List<Account> GetAccounts()
        {
            if (_accounts == null) throw new Exception();
            if (!PasswordValid()) throw new Exception();
            return _accounts;
        }

        /// <summary>
        /// Sets Accounts to write to file
        /// </summary>
        /// <param name="accounts">List of Accounts</param>
        public void SetAccounts(List<Account> accounts)
        {
            _accounts = accounts;
        }

        /// <summary>
        /// Saves Accounts to file and encrypts it
        /// </summary>
        /// <exception cref="Exception">Causes exception if Accounts does not exist</exception>
        public void WriteAccountsToFile()
        {
            if (_accounts == null) throw new Exception();

            string json = JsonSerializer.Serialize<List<Account>>(_accounts);

            byte[] buffer = EncryptStringToBytes_Aes(json, _keyBytes, _ivBytes);

            File.Delete(_accountsFileName);

            FileStream file =  File.Open(_accountsFileName, FileMode.OpenOrCreate);
            file.Write(buffer, 0, buffer.Length);
            file.Close();
        }

        /// <summary>
        /// Saves Accounts to file and encrypts it
        /// </summary>
        /// <param name="accounts">List of Accounts</param>
        public void WriteAccountsToFile(List<Account> accounts)
        {
            _accounts = accounts;
            WriteAccountsToFile();
        }

        /// <summary>
        /// Creates new List of Accounts with test data and saves it to file
        /// </summary>
        public void CreateNewAccountsFile()
        {
            _accounts = new List<Account>
            {
                new Account("https://qwe.qwe", EncryptString("qwe"), EncryptString("qwe")),
                new Account("https://ewq.ewq", EncryptString("ewq"), EncryptString("ewq")),
                new Account("https://asd.asd", EncryptString("asd"), EncryptString("asd"))
            };

            WriteAccountsToFile();
        }

        /// <summary>
        /// Encrypts string
        /// </summary>
        /// <param name="plainText">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        public string EncryptString(string plainText)
        {
            return Convert.ToHexString(EncryptStringToBytes_Aes(plainText, _keyBytes, _ivBytes));
        }

        /// <summary>
        /// Decrypts string
        /// </summary>
        /// <param name="cipherText">String to decrypt</param>
        /// <returns>Decrypted string</returns>
        public string DecryptString(string cipherText)
        {
            return DecryptStringFromBytes_Aes(Convert.FromHexString(cipherText), _keyBytes, _ivBytes);
        }

        private void ReadAccountsFile()
        {
            FileStream file = File.Open(_accountsFileName, FileMode.OpenOrCreate);
            long fileLen = file.Length;
            byte[] data = new byte[fileLen];
            file.Read(data, 0, (int)fileLen);
            file.Close();

            string json = DecryptStringFromBytes_Aes(data, _keyBytes, _ivBytes);
            try
            {
                _accounts = JsonSerializer.Deserialize<List<Account>>(json);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private static byte[] HashString_SHA256(string plainText)
        {
            return SHA256.HashData(Encoding.UTF8.GetBytes(plainText));
        }

        private static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
