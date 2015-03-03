[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVCAppTemplate.Web.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MVCAppTemplate.Web.NinjectConfig), "Stop")]

namespace MVCAppTemplate.Web
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using MVCAppTemplate.Contracts.Database;
    using MVCAppTemplate.Database;
    using MVCAppTemplate.Database.UnitOfWork;
    using MVCAppTemplate.Services.Base;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    
    public static class NinjectConfig
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
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

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind<IDataProvider>().To<DataProvider>().InRequestScope();

            ////.WithConstructorArgument("context", c => new ApplicationDbContext());

            kernel.Bind(k => k.FromAssemblyContaining<IBaseServices>()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InRequestScope()));
        }        
    }
}
