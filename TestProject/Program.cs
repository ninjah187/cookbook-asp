using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Security;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashManager = new PBKDF2HashManager();
            hashManager.KeyLength = 64;
            hashManager.SaltLength = 64;
            var password = "ąćźżźęóńćć";
            var pair = hashManager.GetKeyAndSalt(password);
            
            Console.WriteLine(pair.Key.Length + "\n" + pair.Salt.Length);

            //Console.WriteLine(pair.Key + "\n" + pair.Salt);

            //if (hashManager.Authenticate(password, pair))
            //{
            //    Console.WriteLine("OK");
            //}
            ////////////////////////////////////////////////

            //const int saltLength = 20;

            //using (var provider = new RNGCryptoServiceProvider())
            //{
            //    var output = new byte[saltLength];
            //    provider.GetNonZeroBytes(output);

            //    var text = System.Text.Encoding.Default.GetString(output).ToString();

            //    Console.WriteLine(text);
            //}

            Console.ReadKey();
        }
    }
}
