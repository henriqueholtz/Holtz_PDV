using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Holtz_PDV.Services
{
    public class CidadeService
    {
        private readonly Holtz_PDVContext _context;
        public CidadeService(Holtz_PDVContext context)
        {
            _context = context;
        }

        public async Task<List<Cidade>> FindAllAsync()
        {
            return await _context.Cidades.OrderBy(x => x.CidNom).ToListAsync();
            //return await _context.Cidades.ToListAsync();
            //return await _context.Cidades.Include(obj => obj.Estado).ToListAsync();
        }

        public async Task<Cidade> FindByCodAsync(int cod)
        {
            return await _context.Cidades.Include(obj => obj.Estado).FirstOrDefaultAsync(x => x.CidCod == cod);
            //return await _context.Cidades.FirstOrDefaultAsync(x => x.CidCod == cod);
        }


        public async Task InsertAsync(Cidade obj)
        { //INSERT
            try
            {
                obj.EstadoEstCod = obj.Estado.EstCod;
                obj.Estado = null; //para o EF não tentar inserir o Estado novamente
                _context.Cidades.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int cod)
        {//REMOVE
            try
            {
                var obj = await _context.Cidades.FindAsync(cod);
                _context.Cidades.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) //vem do banco
            {
                throw new IntegrityException("Não é possível excluir este Cliente.");
            }
        }

        public async Task UpdateAsync(Cidade obj)
        { //UPDATE
            bool hasAny = await _context.Cidades.AnyAsync(x => x.CidCod == obj.CidCod);
            if (!hasAny)
            {
                throw new NotFoundException("Código não existe!");
            }
            try
            {
                //obj.Estado = null;
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
