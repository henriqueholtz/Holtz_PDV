﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services; //Activity
using System.Diagnostics;
using AutoMapper;

namespace Holtz_PDV.Controllers
{
    public class CidadesController : Controller
    {
        private readonly CidadeService _cidadeService;
        private readonly EstadoService _estadoService;
        private readonly IMapper _mapper;
        public CidadesController(CidadeService cidadeService, EstadoService estadoService, IMapper mapper)
        {
            _cidadeService = cidadeService;
            _estadoService = estadoService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Cidade> cidades = await _cidadeService.FindAllAsync();
            return View(_mapper.Map<List<CidadeFromViewModel>>(cidades));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido" });
            }
            Cidade cidade = await _cidadeService.FindByCodAsync(id.Value);
            if (cidade == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não existe" });
            }
            List<Estado> estados = await _estadoService.FindAllAsync();
            CidadeFromViewModel viewModel = new CidadeFromViewModel { Estados = await _estadoService.FindAllAsync() };
            ViewData["Estados"] = estados.ToList();
            return View(_mapper.Map<CidadeFromViewModel>(cidade));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            var obj = await _cidadeService.FindByCodAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não existe!" });
            }
            return View(_mapper.Map<CidadeFromViewModel>(obj));
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            var obj = await _cidadeService.FindByCodAsync(id.Value);
            if (obj == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código  não localizado!" });
            }
            return View(_mapper.Map<CidadeFromViewModel>(obj));
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
