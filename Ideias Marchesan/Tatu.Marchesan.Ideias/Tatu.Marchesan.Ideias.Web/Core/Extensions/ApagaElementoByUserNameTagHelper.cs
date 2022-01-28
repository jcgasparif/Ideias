using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using Tatu.Marchesan.Ideias.App.Core.Helpers;
using Tatu.Marchesan.Ideias.Domain.Enums;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;

namespace Tatu.Marchesan.Ideias.App.Core.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-ideiaId")]
    public class ApagaElementoByIdeiaIdTagHelper : TagHelper
    {
        private readonly IIdeiasRepository _ideiasRepository;

        public ApagaElementoByIdeiaIdTagHelper(IIdeiasRepository ideiasRepository)
        {
            _ideiasRepository = ideiasRepository;
        }

        [HtmlAttributeName("suppress-by-ideiaId")]
        public int IdeiaId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var model = AsyncHelper.RunSync(() => _ideiasRepository.FindById(IdeiaId));
            var temAcesso = model.StatusId == StatusEnum.IdeiaCriada.ToInt();

            if (temAcesso)
            {
                return;
            }

            output.SuppressOutput();
        }
    }
}