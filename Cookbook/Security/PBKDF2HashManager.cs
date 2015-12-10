using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Cookbook.Security
{
    public struct PBKDF2KeySaltPair : IKeySaltPair
    {
        public PBKDF2KeySaltPair(string key, string salt)
            : this()
        {
            Key = key;
            Salt = salt;
        }

        // Base64 encoded strings
        public string Key { get; set; }
        public string Salt { get; set; }
    }

    public class PBKDF2HashManager : IKeySaltManager
    {
        public int KeyLength { get; set; }
        public int SaltLength { get; set; }

        public PBKDF2HashManager()
        {
            KeyLength = 20;
            SaltLength = 20;
        }

        public IKeySaltPair GetKeyAndSalt(string input)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(input, SaltLength)) // SaltLength - size
            {
                byte[] salt = deriveBytes.Salt;
                byte[] key = deriveBytes.GetBytes(KeyLength); // KeyLength - key

                string encodedSalt = Convert.ToBase64String(salt);
                string encodedKey = Convert.ToBase64String(key);

                return new PBKDF2KeySaltPair(encodedKey, encodedSalt);
            }
        }

        // key and salt encoded as Base64 strings
        public bool Authenticate(string password, string encodedKey, string encodedSalt)
        {
            byte[] salt = Convert.FromBase64String(encodedSalt);
            byte[] key = Convert.FromBase64String(encodedKey);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
            {
                byte[] testKey = deriveBytes.GetBytes(key.Length);

                if (testKey.SequenceEqual(key))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Authenticate(string password, IKeySaltPair keySaltPair)
        {
            return Authenticate(password, keySaltPair.Key, keySaltPair.Salt);
        }
    }
}