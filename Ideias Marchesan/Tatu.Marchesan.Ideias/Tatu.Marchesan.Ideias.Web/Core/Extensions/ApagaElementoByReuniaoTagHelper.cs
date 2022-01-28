using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using Tatu.Marchesan.Ideias.App.Core.Helpers;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;

namespace Tatu.Marchesan.Ideias.App.Core.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-reuniao")]
    public class ApagaElementoByReuniaoTagHelper : TagHelper
    {
        private readonly IIdeiasService _ideiasService;

        public ApagaElementoByReuniaoTagHelper(IIdeiasService ideiasService)
        {
            _ideiasService = ideiasService;
        }

        [HtmlAttributeName("suppress-by-reuniao")]
        public int IdeiaId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temReuniao = false;
            var ideiasModel = AsyncHelper.RunSync(() => _ideiasService.GetIdeiasAnexoById(IdeiaId));

            if (ideiasModel.Reuniao != null && ideiasModel.Reuniao.Count > 0)
            {
                temReuniao = true;
            }

            if (temReuniao)
            {
                output.SuppressOutput();
            }
        }
    }
}