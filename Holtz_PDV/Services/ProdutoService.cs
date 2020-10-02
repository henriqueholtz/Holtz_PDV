using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Holtz_PDV.Services.Exceptions;
using Microsoft.EntityFrameworkCore; //ToListAsync

namespace Holtz_PDV.Services
{
    public class ProdutoService
    {
        private readonly Holtz_PDVContext _context;
        public ProdutoService(Holtz_PDVContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produtos.OrderBy(x => x.ProNom).ToListAsync();
        }

        public async Task<Produto> FindByCodAsync(int cod)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.ProCod == cod);
        }

        public async Task InsertAsync(Produto obj)
        { //INSERT
            try
            {
                _context.Produtos.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task UpdateAsync(Produto obj)
        { //UPDATE
            bool hasAny = await _context.Produtos.AnyAsync(x => x.ProCod == obj.ProCod);
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

        public async Task RemoveAsync(int cod)
        { //REMOVE
            try
            {
                var obj = await _context.Produtos.FindAsync(cod);
                _context.Produtos.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) //vem do banco
            {
                throw new IntegrityException("Não é possível excluir este Cliente.");
            }
        }
    }
}
