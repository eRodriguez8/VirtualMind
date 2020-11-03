using System.Web.Http;
using WebActivatorEx;
using VirtualMind.TechnicalEvaluation.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace VirtualMind.TechnicalEvaluation.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "VirtualMind.TechnicalEvaluation.Api");
})
                .EnableSwaggerUi(c =>
                    {
   });
        }
    }
}
