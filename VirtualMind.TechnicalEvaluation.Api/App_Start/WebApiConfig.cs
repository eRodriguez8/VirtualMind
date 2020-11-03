using Swashbuckle.Application;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace VirtualMind.TechnicalEvaluation.Api.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            EnableCorsAttribute cors = new EnableCorsAttribute(ConfigurationManager.AppSettings["cors"], "*", "GET,POST,PUT,DELETE");
            cors.SupportsCredentials = true;
            config.EnableCors(cors);

            using (var handler = new RedirectHandler(m => m.RequestUri.ToString(), "swagger"))
            {
                config.Routes.MapHttpRoute(
                    name: "swagger_root",
                    routeTemplate: "",
                    defaults: null,
                    constraints: null,
                    handler: handler);
            }

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
        }
    }
}