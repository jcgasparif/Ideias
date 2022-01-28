using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Tatu.Marchesan.Ideias.App.Core.Helpers
{
    public class IdentityHelper
    {
        private const string CookieMiddleware = "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware";
        private const string CookieSchema = "Identity.Application";
        private const string CookieVersion = "v2";
        private const string CookieName = ".AspNetCore.Identity.Application";

        public string UserId { get; }
        public string UserName { get; }
        public List<Claim> UserClaims { get; }

        public IdentityHelper(HttpContext httpContext)
        {
            var opt = httpContext.RequestServices.GetRequiredService<IOptionsMonitor<CookieAuthenticationOptions>>();
            var cookie = opt.CurrentValue.CookieManager.GetRequestCookie(httpContext, CookieName);

            if (string.IsNullOrEmpty(cookie))
            {
                return;
            }

            var dataProtector = opt.CurrentValue.DataProtectionProvider
                .CreateProtector(CookieMiddleware, CookieSchema, CookieVersion);
            var ticket = new TicketDataFormat(dataProtector).Unprotect(cookie);

            UserClaims = ticket.Principal.Claims.ToList();
            UserId = UserClaims[0].Value;
            UserName = UserClaims[1].Value;
        }
    }
}