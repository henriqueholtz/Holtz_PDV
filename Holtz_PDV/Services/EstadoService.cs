using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
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

        public IOrderedQueryable<Estado> FindAllQueryable()
        {
            return _context.Estados.AsNoTracking().OrderBy(x => x.EstCod);
        }

        public async Task<List<Estado>> FindAllAsync()
        {
            return await _context.Estados.ToListAsync();
        }

        public async Task<Estado> FindByCodAsync(int cod)
        {
            return await _context.Estados.FirstOrDefaultAsync(x => x.EstCod == cod);
        }

        public async Task InsertAsync(Estado obj)
        {
            ToUpper(obj);
            _context.Estados.Add(obj);
            await _context.SaveChangesAsync();
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
                ToUpper(obj);
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Estados.FindAsync(id);
                _context.Estados.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) //vem do banco
            {
                throw new IntegrityException("Não é possível deletar um Estado !?");
            }
        }

        private void ToUpper(Estado estado)
        {
            estado.EstNom = (estado.EstNom == null) ? "" : estado.EstNom.ToUpper();
        }
    }
}
