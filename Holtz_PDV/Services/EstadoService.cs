using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Microsoft.EntityFrameworkCore; //ToListAsync

namespace Holtz_PDV.Services
{
    public class EstadoService
    {
        private readonly Holtz_PDVContext _context;
        public EstadoService(Holtz_PDVContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> FindAllAsync()
        {
            return await _context.Estados.ToListAsync();
        }
    }
}
