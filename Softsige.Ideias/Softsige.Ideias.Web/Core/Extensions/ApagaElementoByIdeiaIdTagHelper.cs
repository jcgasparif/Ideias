using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Softsige.Ideias.App.Core.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-userid")]
    public class ApagaElementoByUserIdTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ApagaElementoByUserIdTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("suppress-by-userid")]
        public string IdentityUserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temAcesso = CustomAuthorization.ValidarUsuarioCriador(
                _contextAccessor.HttpContext, IdentityUserId);

            if (temAcesso)
            {
                return;
            }

            output.SuppressOutput();
        }
    }
}