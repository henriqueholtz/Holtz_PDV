using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using System.Diagnostics;
using AutoMapper;

namespace Holtz_PDV.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly IMapper _mapper;
        public ProdutosController(ProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.FindAllAsync();
            return View(_mapper.Map<List<ProdutoFromViewModel>>(produtos));
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            Produto prod = await _produtoService.FindByCodAsync(id.Value);
            if (prod == null )
            {
                return RedirectToAction(nameof(Error), new { message = "Não existe Produto com este código." });
            }
            return View(_mapper.Map<ProdutoFromViewModel>(prod));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            Produto prod = await _produtoService.FindByCodAsync(id.Value);
            if (prod == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Não existe Produto com este código." });
            }
            return View(_mapper.Map<ProdutoFromViewModel>(prod));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            Produto prod = await _produtoService.FindByCodAsync(id.Value);
            if (prod == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Não existe Produto com este código." });
            }
            return View(_mapper.Map<ProdutoFromViewModel>(prod));
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
