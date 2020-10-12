using System.Collections.Generic;
using System.Threading.Tasks;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using System.Diagnostics;
using AutoMapper;
using Holtz_PDV.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Holtz_PDV.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly IMapper _mapper;
        private readonly Holtz_PDVContext _context;
        public ProdutosController(ProdutoService produtoService, IMapper mapper,Holtz_PDVContext context)
        {
            _produtoService = produtoService;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {

            return View(await PaginatedList<Produto>.CreateAsync(_context.Produtos, page, 5));


            //var produtos = await _produtoService.FindAllAsync();
            //return View(_mapper.Map<List<ProdutoFromViewModel>>(produtos));
        }

        public async Task<IActionResult> Create()
        {
            ICollection<Marca> marcas = await _produtoService.FindAllMarcasAsync();
            return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel(marcas)));
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
            ICollection<Marca> marcas = await _produtoService.FindAllMarcasAsync();
            return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel(marcas,prod)));
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
            ICollection<Marca> marcas = await _produtoService.FindAllMarcasAsync();
            return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel(marcas, prod)));
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
        public async Task<IActionResult> Edit(Produto obj)
        {//UPDATE
            if(!ModelState.IsValid)
            {
                return View(_mapper.Map<ProdutoFromViewModel>(new ProdutoFromViewModel()));
            }
            try
            {
                await _produtoService.UpdateAsync(obj);
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
                await _produtoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e) // exceção a nível de Serviço
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}
