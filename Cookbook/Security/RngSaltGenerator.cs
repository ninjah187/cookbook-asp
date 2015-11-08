using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Cookbook.Security
{
    public class RngSaltGenerator : ISaltGenerator, IDisposable
    {
        private readonly RNGCryptoServiceProvider _rngProvider;

        public RngSaltGenerator()
        {
            _rngProvider = new RNGCryptoServiceProvider();
        }

        public void Dispose()
        {
            if (_rngProvider != null)
            {
                _rngProvider.Dispose();
            }
        }

        public string GetSaltUTF8(int saltLength)
        {
            var text = GetSalt(saltLength);

            return Encoding.UTF8.GetString(text);
        }

        public byte[] GetSalt(int saltLength)
        {
            var bytes = new byte[saltLength];
            _rngProvider.GetNonZeroBytes(bytes);

            return bytes;
        }
    }
}