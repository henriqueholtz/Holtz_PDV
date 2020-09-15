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


        public async Task<IActionResult> Index()
        {
            List<Estado> estados = await _estadoService.FindAllAsync();
            //return View(estados);
            return View(_mapper.Map<List<EstadoFromViewModel>>(estados));
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
