using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class IdeiasController : BaseController
    {
        private readonly IIdeiasService _ideiasService;
        private readonly IAnexosService _anexosService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public IdeiasController(
            IHttpContextAccessor contextAccessor,
            IIdeiasService ideiasService,
            IAnexosService anexosService,
            UserManager<AppUser> userManager,
            IMapper mapper) : base(contextAccessor)
        {
            _ideiasService = ideiasService;
            _anexosService = anexosService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = _mapper.Map<IEnumerable<IdeiasFiltroViewModel>>(await GetIdeiasList());

            return View(result.OrderByDescending(x => x.DataInclusao));
        }

        [ClaimsAuthorize("Ideias", "Create")]
        public async Task<IActionResult> Create()
        {
            var descricao = $"Nova ideia {_ideiasService.GetNumIdeiasEmCriacao() + 1}";
            var model = _mapper.Map<IdeiasModel>(new IdeiasViewModel
            {
                DataInclusao = DateTime.Now,
                AspNetUsersId = base.UserId,
                Argumentos = string.Empty,
                Descricao = descricao,
                StatusId = StatusEnum.IdeiaCriada,
                NovaIdeiaEmCriacao = true
            });

            var rowsAffected = await _ideiasService.Add(model);

            if (rowsAffected <= 0)
            {
                return RedirectToAction("Index");
            }

            var ideiasResult = await _ideiasService.FindAll();
            var result = ideiasResult.OrderByDescending(x => x.Id).FirstOrDefault(x =>
                x.AspNetUsersId == base.UserId &&
                x.NovaIdeiaEmCriacao &&
                x.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase)
            );

            return result != null ?
                RedirectToAction("Edit", new { id = result.Id }) :
                RedirectToAction("Index");
        }

        [ClaimsAuthorize("Ideias", "Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            this.LoadDropdownLists();
            var model = await _ideiasService.GetIdeiasAnexoById(id);
            var result = _mapper.Map<IdeiasViewModel>(model);

            return View(result);
        }

        [ClaimsAuthorize("Ideias", "Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(IdeiasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                this.LoadDropdownLists();
                var ideiaModel = await _ideiasService.GetIdeiasAnexoById(model.Id);
                model.Anexos = ideiaModel.Anexos;

                return View(model);
            }

            model.NovaIdeiaEmCriacao = false;
            var ideiasModel = _mapper.Map<IdeiasModel>(model);

            await _ideiasService.Update(ideiasModel);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Ideias", "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _ideiasService.GetIdeiasAnexoById(id);

            foreach (var item in model.Anexos)
            {
                await _anexosService.Delete(item.Id);
            }

            await _ideiasService.Delete(id);

            return RedirectToAction("Index");
        }

        [ClaimsAuthorize("Ideias", "Details")]
        public async Task<IActionResult> Details(int id)
        {
            ViewData["Details"] = true;

            var modelReuniao = await _ideiasService.GetIdeiasReuniaoByIdeiaId(id);
            var resultReuniao = _mapper.Map<ReuniaoViewModel>(modelReuniao);

            var reuniaoParticipantes = new List<ReuniaoParticipantesViewModel>();

            if (resultReuniao != null)
            {
                foreach (var item in resultReuniao.ReuniaoParticipantes)
                {
                    item.UsuarioNome = await GetUserNameByUserIdAsync(item.UsuarioId);
                    reuniaoParticipantes.Add(item);
                }

                resultReuniao.ReuniaoParticipantes = reuniaoParticipantes;
            }

            ViewData["Reuniao"] = resultReuniao;

            this.LoadDropdownLists();
            var model = await _ideiasService.GetIdeiasAnexoById(id);
            var result = _mapper.Map<IdeiasViewModel>(model);

            return View(result);
        }

        private async Task<string> GetUserNameByUserIdAsync(string usuarioId)
        {
            var user = await _userManager.FindByIdAsync(usuarioId);

            return user.UserName;
        }

        [ClaimsAuthorize("Ideias", "Create")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AdicionarAnexo(AnexosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                this.LoadDropdownLists();
                return PartialView("_AdicionarAnexos", model);
            }

            model.IdeiaId = model.Id;
            model.Id = 0;
            var imgPrefix = Guid.NewGuid() + "_";
            var uploadResult = await AnexoHelper.UploadFile(model.AnexoIFormFile, imgPrefix);

            if (!uploadResult.Item1)
            {
                ModelState.AddModelError(string.Empty, uploadResult.Item2);
                return PartialView("_AdicionarAnexos", model);
            }

            model.Path = $"{imgPrefix}{model.AnexoIFormFile.FileName}";
            var anexosModel = _mapper.Map<AnexosModel>(model);

            await _anexosService.Add(anexosModel);

            var url = Url.Action("GetAnexosList", "Ideias", new { id = model.IdeiaId });

            return Json(new { success = true, url });
        }

        [ClaimsAuthorize("Ideias", "Delete")]
        public async Task<IActionResult> ExcluirAnexo(int id, int ideiaId, string filename)
        {
            if (!AnexoHelper.DeleteFile(filename))
            {
                return Json(new { success = false });
            }

            await _anexosService.Delete(id);

            var url = Url.Action("GetAnexosList", "Ideias", new { id = ideiaId });

            return Json(new { success = true, url });
        }

        public async Task<IActionResult> DownloadAnexo(string filename)
        {
            if (filename == null)
            {
                return null;
            }

            var path = Path.Combine(AnexoHelper.AnexosPath, filename);
            var memory = new MemoryStream();

            await using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return File(memory, AnexoHelper.GetContentType(path), Path.GetFileName(path));
        }

        public async Task<IActionResult> GetAnexosList(int id)
        {
            var model = await _ideiasService.GetIdeiasAnexoById(id);
            var result = _mapper.Map<IdeiasViewModel>(model);

            return PartialView("_ListaAnexos", result);
        }

        public async Task<IActionResult> GetIdeiasList(string dataInicio, string dataFim, string descricao)
        {
            var result = await GetIdeiasList();

            result = result.Where(x => x.AspNetUsersId == base.UserId);

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

            return PartialView("_ListaIdeias", result);
        }

        public async Task<IActionResult> EnviarIdeiaParaAnalise(int id)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }

            var model = await _ideiasService.FindById(id);

            if (model != null)
            {
                model.StatusId = AvaliacaoEnum.PrimeiraAvaliacao.ToInt();
                await _ideiasService.Update(model);
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore = false)]
        private async Task<IEnumerable<IdeiasFiltroViewModel>> GetIdeiasList()
        {
            var model = await _ideiasService.GetAllIdeiasFiltro();

            if (User.IsInRole("Admin") || User.IsInRole("Moderador"))
            {
                model = await _ideiasService.GetAllIdeiasFiltro();
            }
            else
            {
                model = model.Where(x => x.AspNetUsersId == base.UserId);
            }

            return _mapper.Map<IEnumerable<IdeiasFiltroViewModel>>(model);
        }

        private void LoadDropdownLists()
        {
            ViewData["Status"] = CommonHelper.SelectList(_ideiasService.GetStatusList());
        }
    }
}