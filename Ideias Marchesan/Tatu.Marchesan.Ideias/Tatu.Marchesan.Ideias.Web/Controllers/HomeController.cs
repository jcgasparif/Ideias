using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.App.Models;
using Tatu.Marchesan.Ideias.App.ViewModels;
using Tatu.Marchesan.Ideias.Domain.Enums;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;

namespace Tatu.Marchesan.Ideias.App.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IIdeiasService _ideiasService;
        private readonly IComiteService _comiteService;
        private readonly IMapper _mapper;

        public HomeController(
            IHttpContextAccessor contextAccessor,
            IIdeiasService ideiasService,
            IComiteService comiteService,
            IMapper mapper
            ) : base(contextAccessor)
        {
            _ideiasService = ideiasService;
            _comiteService = comiteService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var ideiasResult = await GetIdeiasList();
            var comiteResult = await GetComiteList();
            var comiteListaAprovado = new List<ComiteViewModel>();

            if (User.IsInRole("Admin") || User.IsInRole("Moderador"))
            {
                ViewData["IdeiasResult"] = ideiasResult
                    .Where(x => (int)x.StatusId > 1)
                    .OrderByDescending(x => x.DataInclusao)
                    .Take(5)
                    .ToList();

                foreach (var item in comiteResult.Where(x => x.Ideia.StatusId == StatusEnum.AprovadaEmComite))
                {
                    if (comiteListaAprovado.Exists(x => x.IdeiaId == item.IdeiaId))
                    {
                        continue;
                    }

                    comiteListaAprovado.Add(item);
                }

                ViewData["ComiteResult"] = comiteListaAprovado.Take(5).ToList();
            }
            else
            {
                ViewData["IdeiasResult"] = ideiasResult
                    .Where(x => (int)x.StatusId > 1 && x.AspNetUsersId == base.UserId)
                    .OrderByDescending(x => x.DataInclusao)
                    .Take(5)
                    .ToList();

                foreach (var item in comiteResult
                    .Where(x => x.Ideia.StatusId == StatusEnum.AprovadaEmComite && x.AspNetUsersId == base.UserId))
                {
                    if (comiteListaAprovado.Exists(x => x.IdeiaId == item.IdeiaId))
                    {
                        continue;
                    }

                    comiteListaAprovado.Add(item);
                }

                ViewData["ComiteResult"] = comiteListaAprovado.Take(5).ToList();
            }

            return View();
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        private async Task<IEnumerable<IdeiasViewModel>> GetIdeiasList()
        {
            var result = await _ideiasService.FindAll();

            return _mapper.Map<IEnumerable<IdeiasViewModel>>(result);
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        private async Task<IEnumerable<ComiteViewModel>> GetComiteList()
        {
            var result = await _comiteService.GetComiteIdeias();

            return _mapper.Map<IEnumerable<ComiteViewModel>>(result);
        }

        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == StatusCodes.Status403Forbidden)
            {                
                return View(@"~/Views/Error/403.cshtml", new ErrorCustom { ErrorCode = statusCode });
            }
            else if (statusCode == StatusCodes.Status404NotFound)
            {
             
                return View(@"~/Views/Error/404.cshtml", new ErrorCustom { ErrorCode = statusCode });
            }
            else
            {
                return View(@"~/Views/Error/Error.cshtml", new ErrorCustom { ErrorCode = statusCode });
                // redireciona pra pagina padrao de erro
            }

            
        }
    }
}