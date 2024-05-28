using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public class Encryption : IEncryption
    {
        public string Encrypt(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetSHA256Hash(password);
                aesAlg.IV = new byte[16]; // IV should be random and unique, but for simplicity, we use a fixed IV here

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write("pet");
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = GetSHA256Hash(password);
                aesAlg.IV = new byte[16]; // IV should be random and unique, but for simplicity, we use a fixed IV here

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String("pet")))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static byte[] GetSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }
    }   
}
