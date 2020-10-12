using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace Holtz_PDV.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PedidoService _pedidoService;
        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await PagingList.CreateAsync(_pedidoService.FindAllQueryable(),5,page));
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
