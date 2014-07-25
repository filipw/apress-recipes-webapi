using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http.Routing;

namespace Apress.Recipes.WebApi
{
    public class EmailRouteConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                var stringValue = value as string;
                if (stringValue == null) return false;

                try
                {
                    var email = new MailAddress(stringValue);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }

            return false;
        }
    }
}