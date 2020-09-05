using Holtz_PDV.Models;
using Microsoft.EntityFrameworkCore; //ToListAsync
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Services
{
    public class MarcaService
    {
        private readonly Holtz_PDVContext _context;
        public MarcaService(Holtz_PDVContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> FindAllAsync()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca> FindByCodAsync(int cod)
        {
            return await _context.Marcas.FirstOrDefaultAsync(x => x.MarCod == cod);
        }
    }
}
