using STEM_backend.App_Start;
using STEM_backend.Repositories.Implements;
using STEM_backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace STEM_backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
            //Dependence Injection
            var container = new UnityContainer();
            container.RegisterType<ISTEMPlanRepository, STEMPlanRepository>(new HierarchicalLifetimeManager());         
            container.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISTEMStatusRepository, STEMStatusRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISTEMReportRepository, STEMReportRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());


            config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
