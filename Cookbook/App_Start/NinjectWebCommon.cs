using System.Diagnostics;
using System.Runtime.InteropServices;
using Cookbook.Models;
using Cookbook.Security;
using Cookbook.Services;
using Cookbook.Services.EFRepositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Cookbook.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Cookbook.App_Start.NinjectWebCommon), "Stop")]

namespace Cookbook.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContextService>()
                .To<AppDbContext>()
                .InRequestScope();
            
            kernel.Bind<IProductRepository>()
                .To<EFProductRepository>()
                .InRequestScope();

            kernel.Bind<IUserRepository>()
                .To<EFUserRepository>()
                .InRequestScope();

            kernel.Bind<IKeySaltManager>()
                .To<PBKDF2HashManager>()
                .InRequestScope();

            //kernel.Bind<IUserService>()
            //    .To<UserService>()
            //    .WithPropertyValue("WebContext", ctx => HttpContext.Current);

            kernel.Bind<IUserService>()
                .To<UserService>()
                .InRequestScope()
                .WithPropertyValue("SessionState", ctx => HttpContext.Current.Session);
        }        
    }
}
