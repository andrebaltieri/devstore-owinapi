using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DevStore.Api.Owin.Security
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        private const string BasicAuthResponseHeader = "WWW-Authenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";


        public override void OnActionExecuting(HttpActionContext context)
        {
            AuthenticationHeaderValue authValue = context.Request.Headers.Authorization;

            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter) && authValue.Scheme == BasicAuthResponseHeaderValue)
            {
                string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(authValue.Parameter)).Split(new[] { ':' });

                if (credentials[0] == "andrebaltieri" && credentials[1] == "password")
                    return;
            }

            context.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            context.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
            return;
        }
    }
}
