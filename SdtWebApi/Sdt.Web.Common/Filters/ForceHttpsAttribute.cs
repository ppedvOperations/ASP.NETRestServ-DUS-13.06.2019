using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Sdt.Web.Common.Filters
{
    public class ForceHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var request = actionContext.Request;

            if (request.RequestUri.Scheme != Uri.UriSchemeHttps) //wenn kein https
            {
                const string https = "Https ist erforderlich";

                if (request.Method.Method == "GET")
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                    {
                        ReasonPhrase = https
                    };

                    var httpsNewUri = new UriBuilder(request.RequestUri)
                    {
                        Scheme = Uri.UriSchemeHttps,
                        Port = 44331 //Wirkbetrieb 443
                    };

                    actionContext.Response.Headers.Location = httpsNewUri.Uri;
                }
                else
                {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.NotFound);
                    actionContext.Response.Content = new StringContent(https);
                }
            }
        }
    }
}
