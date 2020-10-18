using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.Enums;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services;
using Holtz_PDV.Services.Exceptions;
using System.Diagnostics;
using AutoMapper;

namespace Holtz_PDV.Controllers
{
    public class EstadosController : Controller
    {
        private readonly EstadoService _estadoService;
        private readonly IMapper _mapper;
        public EstadosController(EstadoService estadoService, IMapper mapper)
        {
            _estadoService = estadoService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            //return View(await PaginatedList<Estado>.CreateAsync(_estadoService.FindAllQueryable(), page, 5));
            var list = await _estadoService.FindAllAsync();
            return View(PaginatedListH<Estado>.Create(list, page, 5));
            //List<Estado> estados = await _estadoService.FindAllAsync();
            //return View(_mapper.Map<List<EstadoFromViewModel>>(estados));
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, string stateName = "")
        {
            ViewData["GetEstados"] = stateName;
            var query = from x in await _estadoService.FindAllAsync() select x;
            if (!String.IsNullOrEmpty(stateName))
            {
                query = query.Where(x => x.EstNom.Contains(stateName.ToUpper()));
            }
            return View(PaginatedListH<Estado>.Create(query.ToList(), page, 5));
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            Estado estado = await _estadoService.FindByCodAsync(id.Value);
            //Estado estado = await _estadoService.FindByCodAsync(id.Value);
            if (estado == null)
            {
                RedirectToAction(nameof(Error), new { message = "Nenhum Estado com este código" });
            }
            //return View(estado);
            return View(_mapper.Map<EstadoFromViewModel>(estado));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código não fornecido." });
            }
            Estado estado = await _estadoService.FindByCodAsync(id.Value);
            //var viewModel = _mapper.Map<EstadoFromViewModel>(await _estadoService.FindByCodAsync(id.Value));
            if (estado == null)
            {
                RedirectToAction(nameof(Error), new { message = "Nenhum Estado com esse Código!" });
            }
            //return View(viewModel);
            //return View(_mapper.Map<EstadoFromViewModel>(await _estadoService.FindByCodAsync(id.Value)));
            return View(_mapper.Map<EstadoFromViewModel>(estado));
            //return View(estado);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                RedirectToAction(nameof(Error), new { message = "Código não fornecido." });
            }
            Estado estado = await _estadoService.FindByCodAsync(id.Value);
            //Estado estado = await _estadoService.FindByCodAsync(id.Value);
            if (estado == null)
            {
                RedirectToAction(nameof(Error), new { message = "Nenhum Estado com esse Código!" });
            }
            //return View(estado);
            return View(_mapper.Map<EstadoFromViewModel>(estado));
        }

        public IActionResult Create()
        {
            //EstadoFromViewModel viewModel = new EstadoFromViewModel();// { UFs = items };
            return View(_mapper.Map<EstadoFromViewModel>(new EstadoFromViewModel()));
        }


        //POST's
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _estadoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e) // exceção a nível de Serviço
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Estado estado)
        {
            if (!ModelState.IsValid)
            {
                var estados = await _estadoService.FindAllAsync();
                return View(estados);
            }
            if (id != estado.EstCod)
            {
                return RedirectToAction(nameof(Error), new { message = "Os Códigoss não correspondem." });
            }

            try
            {
                await _estadoService.UpdateAsync(estado);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (InvalidOperationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }



        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Create(Estado estado)
        {
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<EstadoFromViewModel>(new EstadoFromViewModel()));
            }
            await _estadoService.InsertAsync(estado);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
