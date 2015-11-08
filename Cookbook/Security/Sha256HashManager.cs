using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Cookbook.Security
{
    public class Sha256HashManager : IHashManager, IDisposable
    {
        private readonly SHA256Managed _sha256Managed;

        public Sha256HashManager()
        {
            _sha256Managed = new SHA256Managed();
        }

        public void Dispose()
        {
            if (_sha256Managed != null)
            {
                _sha256Managed.Dispose();
            }
        }

        public string GetHash(string text)
        {
            return GetHash(text, Encoding.UTF8);
        }

        public string GetHash(string text, Encoding encoding)
        {
            var bytes = encoding.GetBytes(text);

            var hashBytes = _sha256Managed.ComputeHash(bytes);

            return encoding.GetString(hashBytes);
        }

        public bool AreTheSame(string text1, string text2)
        {
            var hash1 = GetHash(text1);
            var hash2 = GetHash(text2);

            if (hash1 == hash2)
            {
                return true;
            }
            return false;
        }
    }
}