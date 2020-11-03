﻿using VirtualMind.TechnicalEvaluation.Api.App_Start;
using VirtualMind.TechnicalEvaluation.Api.Helpers;
using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Corp.Cencosud.Supermercados.Auditoria.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configuration.Filters.Add(new ValidateModelAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new LogException());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", ConfigurationManager.AppSettings["cors"]);
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type,Accept,Authorization");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}