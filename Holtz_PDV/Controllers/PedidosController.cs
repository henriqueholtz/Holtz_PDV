using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Holtz_PDV.Services.Exceptions;

namespace Holtz_PDV.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        private readonly IMapper _mapper;
        public PedidosController(PedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            //var model = await PagingList.CreateAsync(_pedidoService.FindAllQueryable(), 5, page);//ReflectionIT.Mvc.Paging;
            //var model = _pedidoService.FindAllQueryable().ToPagedList(page, 5); //X.PagedList
            //return View(model);

            var list = await _pedidoService.FindAllAsync();
            return View(PaginatedListH<Pedido>.Create(list, page, 5));
            
        }

        public IActionResult Create(int page)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id, int page)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            Pedido ped = await _pedidoService.FindByCodAsync(id.Value);
            if (ped == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não localizado" });
            }
            return View(_mapper.Map<PedidoFromViewModel>(ped));
        }
        public async Task<IActionResult> Details(int? id, int page)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            Pedido ped = await _pedidoService.FindByCodAsync(id.Value);
            if (ped == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não localizado" });
            }
            return View(_mapper.Map<PedidoFromViewModel>(ped));
        }
        public async Task<IActionResult> Delete(int? id, int page)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Código não fornecido!" });
            }
            Pedido ped = await _pedidoService.FindByCodAsync(id.Value);
            if (ped == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Pedido não localizado" });
            }
            return View(_mapper.Map<PedidoFromViewModel>(ped));
        }


        public IActionResult Error(string message, int page)
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
        public async Task<IActionResult> Edit(Pedido pedido, int page)
        {
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<PedidoFromViewModel>(new PedidoFromViewModel()));
            }
            try
            {
                await _pedidoService.UpdateAsync(pedido);
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

        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar/Previnir ataques CSRF
        public async Task<IActionResult> Delete(int id, int page)
        {
            try
            {
                await _pedidoService.RemoveAsync(id);
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
        public async Task<IActionResult> Create(Pedido pedido)
        {//INSERT
            if (!ModelState.IsValid)
            {
                return View(_mapper.Map<PedidoFromViewModel>(new PedidoFromViewModel()));
            }
            await _pedidoService.InsertAsync(pedido);
            return RedirectToAction(nameof(Index));
        }

    }
}
