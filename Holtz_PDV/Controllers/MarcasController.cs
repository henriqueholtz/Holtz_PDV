using System;
using System.Collections.Generic;
using System.Linq;
using Holtz_PDV.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Holtz_PDV.Controllers
{
    public class MarcasController : Controller
    {
        private readonly MarcaService _marcaService;
        public MarcasController(MarcaService marcaService)
        {
            _marcaService = marcaService;
        }
        public async Task<IActionResult> Index()
        {
            var marcas = await _marcaService.FindAllAsync();
            return View(marcas);
        }
    }
}
