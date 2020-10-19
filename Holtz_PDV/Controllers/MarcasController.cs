using System;
using System.Collections.Generic;
using System.Linq;
using Holtz_PDV.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Holtz_PDV.Models.ViewModels;
using System.Diagnostics;
using Holtz_PDV.Models;
using Holtz_PDV.Services.Exceptions;
using ReflectionIT.Mvc.Paging;

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
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await PagingList.CreateAsync(_marcaService.FindAllQueryable(), 5, page));
            
            //antes da paginação:
            //var marcas = await _marcaService.FindAllAsync();
            //return View(_mapper.Map<List<MarcaFromViewModel>>(marcas));
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, string brandName = "")
        {
            ViewData["brandName"] = brandName;
            var query = from x in _marcaService.FindAllQueryable() select x;
            if (!String.IsNullOrEmpty(brandName))
            {
                query = query.Where(x => x.MarNom.Contains(brandName.ToUpper()));
            }
            var queryOrder = query.OrderBy(order => order.MarCod);
            return View(await PagingList.CreateAsync(queryOrder, 5, page));
        }

        public IActionResult Create()
        {
            return View(_mapper.Map<MarcaFromViewModel>(new MarcaFromViewModel()));
        }

        public async Task<IActionResult> Delete(int? id)
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

        public async Task<IActionResult> Details(int? id)
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


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Create(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<MarcaFromViewModel>(new MarcaFromViewModel()));
            }
            await _marcaService.InsertAsync(marca);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Edit(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<MarcaFromViewModel>(new MarcaFromViewModel()));
            }
            try
            {
                await _marcaService.UpdateAsync(marca);
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _marcaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e) // exceção a nível de Serviço
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}
