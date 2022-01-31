using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using Softsige.Ideias.App.Core.Helpers;
using Softsige.Ideias.Domain.Interfaces.Service;

namespace Softsige.Ideias.App.Core.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-reuniao-ata")]
    public class ApagaElementoByReuniaoAtaTagHelper : TagHelper
    {
        private readonly IIdeiasService _ideiasService;

        public ApagaElementoByReuniaoAtaTagHelper(IIdeiasService ideiasService)
        {
            _ideiasService = ideiasService;
        }

        [HtmlAttributeName("suppress-by-reuniao-ata")]
        public int IdeiaId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var temAta = false;
            var ideiasModel = AsyncHelper.RunSync(() => _ideiasService.GetIdeiasAnexoById(IdeiaId));

            if (ideiasModel.Anexos != null)
            {
                foreach (var item in ideiasModel.Anexos)
                {
                    if (item.EventoTipoId == 2)
                    {
                        temAta = true;
                    }
                }
            }

            if (temAta)
            {
                output.SuppressOutput();
            }
        }
    }
}