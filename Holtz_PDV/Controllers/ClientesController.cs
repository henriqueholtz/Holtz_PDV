﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics; //Activity
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Holtz_PDV.Services.Exceptions;
//using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Holtz_PDV.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly CidadeService _cidadeService;
        private readonly IMapper _mapper;
        public ClientesController(ClienteService clienteService, CidadeService cidadeService,IMapper mapper)
        {
            _clienteService = clienteService;
            _cidadeService = cidadeService;
            _mapper = mapper;
        }

        //GET
        public async Task<IActionResult> Index(int page = 1)
        {
            //ReflectionIT.Mvc.Paging;
            //var model = await PagingList.CreateAsync(_clienteService.FindAllQueryable(), 5, page);
            //return View(model);
            var list = await _clienteService.FindAllAsync();
            return View(PaginatedListH<Cliente>.Create(list, page, 10));

        }


        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, string clientName = "")
        {
            ViewData["GetCustomers"] = clientName;
            var query = from x in await _clienteService.FindAllAsync() select x;
            if (!String.IsNullOrEmpty(clientName))
            {
                query = query.Where(x => x.CliRaz.Contains(clientName.ToUpper()) || x.CliNomFan.Contains(clientName.ToUpper()));
            }
            return View(PaginatedListH<Cliente>.Create(query.ToList(), page, 10));
        }
        public async Task<IActionResult> Create(int page)
        {
            List<Cidade> cidades = await _cidadeService.FindAllAsync();
            return View(_mapper.Map<ClienteFromViewModel>(new ClienteFromViewModel(cidades)));
        }

        public async Task<IActionResult> Edit(int? id, int page)
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
            List<Cidade> cidades = await _cidadeService.FindAllAsync();
            ClienteFromViewModel viewModel = new ClienteFromViewModel(cidades,obj);
            //mapeia do Cliente para o viewModel, e o source : (mapeia do viewModel para o Cliente)
            return View(_mapper.Map<ClienteFromViewModel>(_mapper.Map<ClienteFromViewModel>(viewModel)));
            //return View(_mapper.Map<ClienteFromViewModel>(obj)); assim funciona direto, antes de incluir as cidades
        }

        public async Task<IActionResult> Details(int? id, int page)
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
            return View(_mapper.Map<ClienteFromViewModel>(obj));
        }
        public async Task<IActionResult> Delete(int? id, int page)
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
            return View(_mapper.Map<ClienteFromViewModel>(obj));
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

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public  async Task<IActionResult> Create(Cliente cliente, int page)
        {
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<ClienteFromViewModel>(new ClienteFromViewModel()));
            }
            await _clienteService.InsertAsync(cliente);
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", new { page = page });
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Delete(int id, int page)
        {
            try
            {
                await _clienteService.RemoveAsync(id);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", new { page = page });
            }
            catch (IntegrityException e) // exceção a nível de Serviço
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task <IActionResult> Edit(Cliente cliente, int page)
        { //UPDATE
            if (!ModelState.IsValid)
            {
                TempData["mensagemErro"] = "Não foi possível alterar este cliente.";
                return View(_mapper.Map<ClienteFromViewModel>(new ClienteFromViewModel(null, cliente)));
            }
            try
            {
                await _clienteService.UpdateAsync(cliente);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", new { page = page });
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
    }
}
