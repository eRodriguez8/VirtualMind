[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VirtualMind.TechnicalEvaluation.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VirtualMind.TechnicalEvaluation.Api.App_Start.NinjectWebCommon), "Stop")]

namespace VirtualMind.TechnicalEvaluation.Api.App_Start
{
    using System;
    using System.Web;
    using Ninject.Web.WebApi;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using VirtualMind.TechnicalEvaluation.Biz;
    using Ninject.Web.Common.WebHost;
    using VirtualMind.TechnicalEvaluation.Dal.Interface;
    using VirtualMind.TechnicalEvaluation.Dal.UnitOfWorks;
    using VirtualMind.TechnicalEvaluation.Biz.Interface;

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
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
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
            kernel.Bind<ICurrencyBiz>().To<CurrencyBiz>();
            kernel.Bind<IUOW_VirtualMindDb>().To<UOW_VirtualMindDb>().InRequestScope();
        }        
    }
}