using Holtz_PDV.Models;
using Holtz_PDV.Services.Exceptions;
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

        public async Task InsertAsync(Marca marca)
        {
            try
            {
                _context.Marcas.Add(marca);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task UpdateAsync(Marca marca)
        {
            bool hasAny = await _context.Marcas.AnyAsync(x => x.MarCod == marca.MarCod);
            if (!hasAny)
            {
                throw new NotFoundException("Código não existe!");
            }
            try
            {
                _context.Update(marca);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int cod)
        {
            try
            {
                var obj = await _context.Marcas.FindAsync(cod);
                _context.Marcas.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) //vem do banco
            {
                throw new IntegrityException("Não é possível excluir esta Marca.");
            }
        }
        public async Task AddRangeAsync(ICollection<Marca> marcas)
        {
            _context.Marcas.AddRange(marcas);
            await _context.SaveChangesAsync();
        }
    }
}
