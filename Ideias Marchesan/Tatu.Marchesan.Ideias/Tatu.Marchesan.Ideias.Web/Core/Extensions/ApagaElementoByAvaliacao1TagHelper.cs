using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using Tatu.Marchesan.Ideias.App.Core.Helpers;
using Tatu.Marchesan.Ideias.App.Models;
using Tatu.Marchesan.Ideias.Domain.Enums;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;

namespace Tatu.Marchesan.Ideias.App.Core.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-avaliacao1")]
    public class ApagaElementoByAvaliacao1TagHelper : TagHelper
    {
        private readonly IComiteService _comiteService;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public ApagaElementoByAvaliacao1TagHelper(IComiteService comiteService,
                                                  IActionContextAccessor actionContextAccessor,
                                                  UserManager<AppUser> userManager)
        {
            _comiteService = comiteService;
            _actionContextAccessor = actionContextAccessor;
            _userManager = userManager;
        }

        [HtmlAttributeName("suppress-by-avaliacao1")]
        public int IdeiaId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            var user = _actionContextAccessor.ActionContext.HttpContext.User;
            var uid = _userManager.GetUserId(user);
            var comiteIdeiasResult = AsyncHelper.RunSync(() => _comiteService.GetComiteIdeias());
            var comiteIdeiasResultList = comiteIdeiasResult.ToList();
            var model = comiteIdeiasResultList.FirstOrDefault(x => x.IdeiaId == IdeiaId);

            if (model == null)
            {
                return;
            }

            if (model.Ideia.StatusId == StatusEnum.EmAnalise1.ToInt())
            {
                if (model.Ideia.Analises == null)
                {
                    return;
                }

                var analises = comiteIdeiasResultList
                    .Where(p => p.AspNetUsersId == uid && p.IdeiaId == IdeiaId && p.SequenciaAnalise == 1);

                if (!analises.Any())
                {
                    return;
                }
            }

            output.SuppressOutput();
        }
    }
}