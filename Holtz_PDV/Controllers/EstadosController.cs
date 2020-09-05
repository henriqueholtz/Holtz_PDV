using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services;
using Holtz_PDV.Services.Exceptions;
using System.Diagnostics;

namespace Holtz_PDV.Controllers
{
    public class EstadosController : Controller
    {
        private readonly EstadoService _estadoService;
        public EstadosController(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }
        public async Task<IActionResult> Index()
        {
            List<Estado> estados = await _estadoService.FindAllAsync();
            return View(estados);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código não fornecido." });
            }
            Estado estado = await _estadoService.FindByCodAsync(id.Value);
            if (estado == null)
            {
                RedirectToAction(nameof(Error), new { message = "Nenhum Estado com esse Código!" });
            }
            EstadoFromViewModel viewModel = new EstadoFromViewModel { Estado = estado };
            return View(viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EstadoFromViewModel { Estado = estado };
                return View(viewModel); //Volta pra view caso o JavaScript esteja desabilitado (e portanto sem validação)
            }
            if (id != estado.EstCod)
            {
                return RedirectToAction(nameof(Error), new { message = "Os Códigoss não correspondem." });
            }
            try
            {
                await _estadoService.UpdateAsync(estado);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
