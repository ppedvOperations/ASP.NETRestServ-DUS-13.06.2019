using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sdt.Web.Common.Routing;

namespace Sdt.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //Config
            var jf = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            jf.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jf.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            //Custom Constaints
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("positivNonZero", typeof(PositivNonZeroIntConstraint));

            // Web API routes
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "AutorApi",
            //    routeTemplate: "api/autors",
            //    defaults: new { controller = "autor" }
            //);
        }
    }
}
