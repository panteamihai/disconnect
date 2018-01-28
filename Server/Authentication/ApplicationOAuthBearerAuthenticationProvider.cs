using Microsoft.Owin.Security.OAuth;
using System;
using System.Threading.Tasks;

namespace Server
{
    public class ApplicationOAuthBearerAuthenticationProvider: OAuthBearerAuthenticationProvider
    {
        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            // try to find bearer token in a cookie (by default OAuthBearerAuthenticationHandler only checks Authorization header)
            var tokenCookie = context.OwinContext.Request.Cookies["BearerToken"];
            if (!string.IsNullOrEmpty(tokenCookie))
                context.Token = tokenCookie;

            return Task.FromResult<object>(null);
        }

    }
}
