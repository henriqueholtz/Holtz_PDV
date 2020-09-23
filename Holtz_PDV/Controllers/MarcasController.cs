using System;
using System.Collections.Generic;
using System.Linq;
using Holtz_PDV.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Holtz_PDV.Models.ViewModels;
using System.Diagnostics;

namespace Holtz_PDV.Controllers
{
    public class MarcasController : Controller
    {
        private readonly MarcaService _marcaService;
        private readonly IMapper _mapper;
        public MarcasController(MarcaService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var marcas = await _marcaService.FindAllAsync();
            return View(_mapper.Map<List<MarcaFromViewModel>>(marcas));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código não fornecido" });
            }
            var obj = await _marcaService.FindByCodAsync(id.Value);
            if (obj == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código não existe" });
            }
            return View(_mapper.Map<MarcaFromViewModel>(obj));
        }
        public IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new ErrorViewModel()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
