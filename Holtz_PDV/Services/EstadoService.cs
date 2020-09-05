using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Services.Exceptions;
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

        public async Task<Estado> FindByCodAsync(int cod)
        {
            return await _context.Estados.FirstOrDefaultAsync(x => x.EstCod == cod);
        }

        public async Task UpdateAsync(Estado obj)
        {
            bool hasAny = await _context.Estados.AnyAsync(x => x.EstCod == obj.EstCod);
            if (!hasAny)
            {
                throw new NotFoundException("Código não existe!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
