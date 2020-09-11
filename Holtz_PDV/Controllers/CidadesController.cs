using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services; //Activity
using System.Diagnostics;

namespace Holtz_PDV.Controllers
{
    public class CidadesController : Controller
    {
        private readonly CidadeService _cidadeService;
        private readonly EstadoService _estadoService;
        public CidadesController(CidadeService cidadeService, EstadoService estadoService)
        {
            _cidadeService = cidadeService;
            _estadoService = estadoService;
        }
        public async Task<IActionResult> Index()
        {
            var cidades = await _cidadeService.FindAllAsync();
            return View(cidades);
            //List<Estado> estados = await _estadoService.FindAllAsync();
            //CidadeFromViewModel viewModel = new CidadeFromViewModel() { Estados = estados };
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido" });
            }
            var cidade = await _cidadeService.FindByCodAsync(id.Value);
            if (cidade == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não existe" });
            }
            List<Estado> estados = await _estadoService.FindAllAsync();
            CidadeFromViewModel viewModel = new CidadeFromViewModel { Cidade = cidade, Estados = estados };
            return View(estados);
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
