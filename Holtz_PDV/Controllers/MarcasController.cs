using System;
using System.Collections.Generic;
using System.Linq;
using Holtz_PDV.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Holtz_PDV.Models.ViewModels;

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
    }
}
