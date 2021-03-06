using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using Softsige.Ideias.App.Core.Helpers;
using Softsige.Ideias.Domain.Enums;
using Softsige.Ideias.Domain.Interfaces.Service;

namespace Softsige.Ideias.App.Core.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-status")]
    public class ApagaElementoByStatusTagHelper : TagHelper
    {
        private readonly IIdeiasService _ideiaService;

        public ApagaElementoByStatusTagHelper(IIdeiasService ideiaService)
        {
            _ideiaService = ideiaService;
        }

        [HtmlAttributeName("suppress-by-status")]
        public int IdeiaId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var model = AsyncHelper.RunSync(() => _ideiaService.FindById(IdeiaId));
            var temAcesso = model.StatusId == StatusEnum.EmAnalise1.ToInt();

            if (temAcesso)
            {
                return;
            }

            output.SuppressOutput();
        }
    }
}