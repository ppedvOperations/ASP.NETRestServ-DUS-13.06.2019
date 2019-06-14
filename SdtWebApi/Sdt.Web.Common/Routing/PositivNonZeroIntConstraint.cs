using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace Sdt.Web.Common.Routing
{
    // in webapi.config registrieren

    public class PositivNonZeroIntConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (!values.ContainsKey(parameterName))
            {
                return false;
            }

            var value = values[parameterName];

            bool success = int.TryParse(value.ToString(), out var intValue);

            return success && intValue > 0;
        }
    }
}
