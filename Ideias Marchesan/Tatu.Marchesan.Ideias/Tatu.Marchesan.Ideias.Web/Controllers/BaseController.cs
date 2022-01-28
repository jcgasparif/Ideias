using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Tatu.Marchesan.Ideias.App.Core.Helpers;

namespace Tatu.Marchesan.Ideias.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string UserId { get; }
        protected string UserName { get; }
        protected List<Claim> UserClaims { get; }

        protected BaseController(IHttpContextAccessor contextAccessor)
        {
            var identity = new IdentityHelper(contextAccessor.HttpContext);
            UserId = identity.UserId;
            UserName = identity.UserName;
            UserClaims = identity.UserClaims;
        }
    }
}