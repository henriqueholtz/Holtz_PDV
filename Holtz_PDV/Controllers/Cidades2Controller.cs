using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services; //Activity
using System.Diagnostics;
using AutoMapper;
using Holtz_PDV.Services.Exceptions;
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cidades2Controller : ControllerBase
    {
        private readonly CidadeService _cidadeService;
        private readonly EstadoService _estadoService;
        private readonly IMapper _mapper;
        public Cidades2Controller(CidadeService cidadeService, EstadoService estadoService, IMapper mapper)
        {
            _cidadeService = cidadeService;
            _estadoService = estadoService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete ()
        {
            return Ok();
        }
    }
}
