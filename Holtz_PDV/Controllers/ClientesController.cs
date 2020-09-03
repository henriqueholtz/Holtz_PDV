using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics; //Activity
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;

namespace Holtz_PDV.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _clienteService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido" });
            }
            var obj = await _clienteService.FindByCodAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não existe" });
            }
            //List<Cidade> cidades = await _cidadeService.FindAllAsync();
            //ClienteFromViewModel viewModel = new ClienteFromViewModel { Cliente = obj, Cidades = cidades };
            return View(/*viewModel*/);
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }
        public async Task<IActionResult> Delete()
        {
            return View();
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
