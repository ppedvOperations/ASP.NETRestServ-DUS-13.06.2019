using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Sdt.Web.Common.Filters
{
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        private const string BasicAuthResponseHeaderValue = "Basic";
        private const string Realm = "sdt.web.api";

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                return;
            }

            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null) //AuthHeader ist vorhanden
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                    !string.IsNullOrWhiteSpace(authHeader.Parameter))
                {
                    // robert:123456789 base64-> cm9iZXJ0OjEyMzQ1Njc4OQ==
                    var credentials = GetCredentials(authHeader);
                    var userName = credentials[0];
                    var password = credentials[1];

                    if (userName == "robert" && password == "123456789")
                    {
                        var currentPrincipal = new GenericPrincipal(new GenericIdentity(userName), new []{"Admin"});
                        Thread.CurrentPrincipal = currentPrincipal;
                        return;
                    }
                }
            }

            HandleUnauthorizedRequest(actionContext);
        }

        private string[] GetCredentials(AuthenticationHeaderValue authHeader)
        {
            var rawCredentials = authHeader.Parameter;
            return Encoding.UTF8.GetString(Convert.FromBase64String(rawCredentials)).Split(':'); //robert:123456789
        }

        private void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(BasicAuthResponseHeaderValue, Realm));
        }
    }
}
