using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;

namespace Tatu.Marchesan.Ideias.App.Core.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "suppress-by-claim-value")]
    public class ApagaElementoTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApagaElementoTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("suppress-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("suppress-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarClaimsUsuario(
                _contextAccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (CustomAuthorization.ValidarModerador(_contextAccessor.HttpContext) ||
                CustomAuthorization.ValidarAdministrador(_contextAccessor.HttpContext))
            {
                temAcesso = true;
            }

            if (temAcesso)
            {
                return;
            }

            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("*", Attributes = "suppress-by-action")]
    public class ApagaElementoByActionTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApagaElementoByActionTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("suppress-by-action")]
        private string ActionName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var action = _contextAccessor.HttpContext.GetRouteData().Values["action"].ToString();

            if (ActionName.Contains(action!))
            {
                return;
            }

            output.SuppressOutput();
        }
    }
}