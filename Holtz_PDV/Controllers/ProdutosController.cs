using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;

namespace Holtz_PDV.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.FindAllAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }

        public IActionResult Error(string message)
        {
            return View();
        }
    }
}
