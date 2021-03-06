﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using System.Diagnostics;
using AutoMapper;
using Holtz_PDV.Services.Exceptions;
using System;

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
        public async Task<IActionResult> Index(int page = 1)
        {
            var list = await _produtoService.FindAllAsync();
            return View(PaginatedListH<Produto>.Create(list,page,5));
            //var model = await PagingList.CreateAsync(_produtoService.FindAllQueryable(), 5, page);
            //return View(model);

            //var produtos = await _produtoService.FindAllAsync();
            //return View(_mapper.Map<List<ProdutoFromViewModel>>(produtos));
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, string productName = "")
        {
            ViewData["GetProducts"] = productName;
            var query = from x in await _produtoService.FindAllAsync() select x;
            if (!String.IsNullOrEmpty(productName))
            {
                query = query.Where(x => x.ProNom.Contains(productName.ToUpper()));
            }
            return View(PaginatedListH<Produto>.Create(query.ToList(), page, 5));
        }

        public async Task<IActionResult> Create()
        {
            ICollection<Marca> marcas = await _produtoService.FindAllMarcasAsync();
            return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel(marcas)));
        }

        public async Task<IActionResult> Edit(int? id, int page) 
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
            ICollection<Marca> marcas = await _produtoService.FindAllMarcasAsync();
            return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel(marcas,prod)));
        }

        public async Task<IActionResult> Details(int? id, int page)
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
            ICollection<Marca> marcas = await _produtoService.FindAllMarcasAsync();
            return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel(marcas, prod)));
        }
        public async Task<IActionResult> Delete(int? id, int page)
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


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Create(Produto produto)
        {//INSERT
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel()));
            }
            await _produtoService.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Edit(Produto obj, int page)
        {//UPDATE
            if(!ModelState.IsValid)
            {
                return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel()));
            }
            try
            {
                await _produtoService.UpdateAsync(obj);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", new { page = page});
            }
            catch (NotFoundException e) //ou trocar as duas exceptions pelo applicationException (pai de todas)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Delete(int id, int page)
        {
            try
            {
                await _produtoService.RemoveAsync(id);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", new { page = page });
            }
            catch (IntegrityException e) // exceção a nível de Serviço
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}
