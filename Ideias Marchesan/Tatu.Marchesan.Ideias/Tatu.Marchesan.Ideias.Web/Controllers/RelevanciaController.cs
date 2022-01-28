using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;

namespace Tatu.Marchesan.Ideias.App.Controllers
{
    public class RelevanciaController : BaseController
    {
        private readonly IRelevanciaService _relevanciaService;

        public RelevanciaController(IHttpContextAccessor contextAccessor, IRelevanciaService relevanciaService)
            : base(contextAccessor)
        {
            _relevanciaService = relevanciaService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _relevanciaService.FindAll();

            return View(result.OrderByDescending(x => x.Descricao));
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(RelevanciasModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _relevanciaService.Add(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _relevanciaService.FindById(id);

            return View(result);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _relevanciaService.FindById(id);

            if (result != null)
            {
                await _relevanciaService.Delete(result);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Usuario não encontrado.");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _relevanciaService.FindById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RelevanciasModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _relevanciaService.Update(model);

            return RedirectToAction("Index");
        }
    }
}