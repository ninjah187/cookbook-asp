using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cookbook;
using Cookbook.Models;
using Cookbook.Security;
using Cookbook.Services;
using Cookbook.Services.EFRepositories;
using Ninject;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IDbContextService>().To<AppDbContext>().InTransientScope();
                kernel.Bind<IProductRepository>().To<EFProductRepository>().InTransientScope();

                //using (var contextService = kernel.Get<IDbContextService>())
                //{
                    var productRepo = kernel.Get<IProductRepository>();

                    if (productRepo.GetByName("całkiem nowy produkt") == null)
                    {
                        productRepo.Add(new Product()
                        {
                            Name = "całkiem nowy produkt"
                        });
                    }

                    foreach (var item in productRepo.YieldAll())
                    {
                        Console.WriteLine(item.Name);
                    }
                //}
            }

            //var hashManager = new PBKDF2HashManager();
            //hashManager.KeyLength = 64;
            //hashManager.SaltLength = 64;
            //var password = "ąćźżźęóńćć";
            //var pair = hashManager.GetKeyAndSalt(password);
            
            //Console.WriteLine(pair.Key.Length + "\n" + pair.Salt.Length);

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
