using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Mvc;

namespace Holtz_PDV.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _cliente;
        public ClienteController(ClienteService cliente)
        {
            _cliente = cliente;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _cliente.FindAllAsync();
            return View(list);
        }
    }
}
