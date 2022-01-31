using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softsige.Ideias.App.Core.Extensions;
using Softsige.Ideias.App.Core.Helpers;
using Softsige.Ideias.App.Models;
using Softsige.Ideias.App.ViewModels;
using Softsige.Ideias.Domain.Entities.Models;
using Softsige.Ideias.Domain.Enums;
using Softsige.Ideias.Domain.Interfaces.Service;

namespace Softsige.Ideias.App.Controllers
{
    [Authorize]
    public class ComiteController : BaseController
    {
        private readonly IComiteService _comiteService;
        private readonly IIdeiasService _ideiasService;
        private readonly IAnexosService _anexosService;
        private readonly IRelevanciaService _relevanciaService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;


        public ComiteController(
            IHttpContextAccessor contextAccessor,
            IComiteService comiteService,
            IIdeiasService ideiasService,
            IAnexosService anexosService,
            IRelevanciaService relevanciaService,
            IMapper mapper, UserManager<AppUser> userManager) : base(contextAccessor)
        {
            _comiteService = comiteService;
            _ideiasService = ideiasService;
            _anexosService = anexosService;
            _relevanciaService = relevanciaService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = await GetComiteIdeiasList();

            return View(result.OrderByDescending(x => x.DataInclusao));
        }      

         [ClaimsAuthorize("Comite", "Create")]
        public async Task<IActionResult> Create(int id)
        {

            await LoadDropdownLists();
            ViewData["Details"] = true;

            var result = new ComiteViewModel
            {
                Ideia = _mapper.Map<IdeiasViewModel>(await _ideiasService.GetIdeiasAnexoById(id))
            };

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ComiteViewModel model)
        {
            ViewData["Details"] = true;

            if (!ModelState.IsValid)
            {
                await LoadDropdownLists();
                var ideiasModel = await _ideiasService.GetIdeiasAnexoById(model.Id);
                var result = _mapper.Map<ComiteViewModel>(ideiasModel);

                return View(result);
            }

            model.AspNetUsersId = base.UserId;
            model.DataAnalise = DateTime.Now;
            model.IdeiaId = model.Id;
            model.Id = 0;

            var comiteModel = _mapper.Map<ComiteModel>(model);
            await _comiteService.Add(comiteModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            await LoadDropdownLists();
            ViewBag.DetalhesIdeia = _mapper.Map<IdeiasViewModel>(await _ideiasService.GetIdeiasAnexoById(id));

            var comiteResult = await _comiteService.GetComiteIdeias();
            var analiseModel = comiteResult.Where(x => x.IdeiaId == id);
            var result = new List<ComiteViewModel>();

            if (comiteResult.Count(x => x.Ideia.StatusId == StatusEnum.EmAnalise1.ToInt() && x.IdeiaId == id && x.SequenciaAnalise == 1) > 0)
            {
                analiseModel = comiteResult
                    .Where(x => x.Ideia.StatusId == StatusEnum.EmAnalise1.ToInt() && x.IdeiaId == id && x.AspNetUsersId == base.UserId);
            }
            else if (comiteResult.Count(x => x.Ideia.StatusId == StatusEnum.EmAnalise2.ToInt() && x.IdeiaId == id) > 0)
            {
                analiseModel = comiteResult
                    .Where(x => x.Ideia.StatusId == StatusEnum.EmAnalise2.ToInt() && x.IdeiaId == id && x.SequenciaAnalise == 1);
            }
            else if (comiteResult.Count(x => x.Ideia.StatusId > StatusEnum.EmAnalise2.ToInt() && x.IdeiaId == id) > 0)
            {
                analiseModel = comiteResult
                    .Where(x => x.IdeiaId == id);
            }

            if (User.IsInRole("Admin") || User.IsInRole("Moderador"))
            {
                analiseModel = comiteResult.Where(x => x.IdeiaId == id);
            }

            foreach (var item in _mapper.Map<IList<ComiteViewModel>>(analiseModel))
            {
                var model = item;
                model.UserName = await GetUserNameByUserIDAsync(item.AspNetUsersId);
                result.Add(model);
            }

            return View(result.OrderByDescending(x => x.DataAnalise));
        }

        private async Task<string> GetUserNameByUserIDAsync(string usuarioId)
        {
            var user = await _userManager.FindByIdAsync(usuarioId);
            return user.UserName;
        }

        public async Task<IActionResult> GetComiteIdeiasList(string dataInicio, string dataFim, string descricao)
        {
            var result = await GetComiteIdeiasList();

            DateTime.TryParse(dataInicio, out var dtInicio);
            DateTime.TryParse(dataFim, out var dtFim);

            if (dtInicio > DateTime.MinValue && dtFim == DateTime.MinValue)
            {
                result = result
                    .Where(x => x.DataInclusao.Date >= dtInicio.Date).ToList();
            }
            else if (dtInicio > DateTime.MinValue && dtFim > DateTime.MinValue)
            {
                result = result
                    .Where(x => x.DataInclusao.Date >= dtInicio.Date)
                    .Where(x => x.DataInclusao.Date <= dtFim.Date).ToList();
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                result = result
                    .Where(x => x.Descricao.Contains(descricao, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return PartialView("_ListaComite", result.OrderByDescending(x => x.DataInclusao));
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        private async Task<IEnumerable<ComiteFiltroViewModel>> GetComiteIdeiasList()
        {
            var model = await _ideiasService.GetAllIdeiasFiltro();

            var result = _mapper.Map<IEnumerable<ComiteFiltroViewModel>>(model.Where(x => x.StatusId >= 2));

            return result;
        }

        public async Task<IActionResult> HabilitarSegundaAvaliacao(int id)
        {
            var result = await _ideiasService.HabilitarSegundaAvaliacao(id);

            return result == 1 ? RedirectToAction("Index") : null;
        }

        public async Task<IActionResult> CriarReuniao(string ideiaId, string data)
        {
            DateTime.TryParse(data, out var dataReuniao);
            int.TryParse(ideiaId, out var id);

            var result = await _comiteService.CriaReuniaoComite(id, dataReuniao);

            return Json(new { success = result == 1 });
        }

        public async Task<IActionResult> Avaliacoes(int id)
        {
            var avaliacoesList = await _comiteService.GetListaAvaliacoes(id);
            var result = _mapper.Map<List<AvaliacoesViewModel>>(avaliacoesList);

            return View(result);
        }

        public async Task<IActionResult> AprovaReprovaIdeia(string ideiaId, string bitAprova)
        {
            int.TryParse(ideiaId, out var id);
            bool.TryParse(bitAprova, out var apr);

            var model = await _ideiasService.FindById(id);
            model.StatusId = apr ? StatusEnum.AprovadaEmComite.ToInt() : StatusEnum.IdeiaNaoAprovada.ToInt();

            await _ideiasService.Update(model);

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AdicionarAnexo(AnexosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_AdicionarAtaReuniao", model);
            }

            model.Id = 0;
            var imgPrefix = Guid.NewGuid() + "_";
            var uploadResult = await AnexoHelper.UploadFile(model.AnexoIFormFile, imgPrefix);

            if (!uploadResult.Item1)
            {
                ModelState.AddModelError(string.Empty, uploadResult.Item2);
                return PartialView("_AdicionarAtaReuniao", model);
            }

            model.Path = $"{imgPrefix}{model.AnexoIFormFile.FileName}";
            var anexosModel = _mapper.Map<AnexosModel>(model);

            await _anexosService.Add(anexosModel);

            return Json(new { success = true });
        }

        private async Task<int> LoadDropdownLists()
        {
            var relevanciaList = await _comiteService.GetRelevanciaList();

            ViewData["Relevancia"] = CommonHelper.SelectList(relevanciaList, "Id", "Descricao");

            return 0;
        }
    }
}