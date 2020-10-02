using Holtz_PDV.Models;
using Holtz_PDV.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Services
{
    public class ClienteService
    {
        private readonly Holtz_PDVContext _context;
        public ClienteService(Holtz_PDVContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _context.Clientes.OrderBy(x => x.CliRaz).ToListAsync();
        }

        public async Task<Cliente> FindByCodAsync(int cod)
        {
            return await _context.Clientes.Include(obj => obj.Cidade).FirstOrDefaultAsync(x => x.CliCod == cod);
        }

        public async Task InsertAsync(Cliente obj)
        { //INSERT
            try
            {
                obj.CidadeCidCod = obj.Cidade.CidCod;
                obj.Cidade = null; // para o EFCore não tentar inserir a cidade NOVAMENTE... 
                _context.Clientes.Add(obj);
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
                var obj = await _context.Clientes.FindAsync(cod);
                _context.Clientes.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) //vem do banco
            {
                throw new IntegrityException("Não é possível excluir este Cliente.");
            }
        }

        public async Task UpdateAsync(Cliente obj)
        { //UPDATE
            bool hasAny = await _context.Clientes.AnyAsync(x => x.CliCod == obj.CliCod);
            if (!hasAny)
            {
                throw new NotFoundException("Código não existe!");
            }
            try
            {
                //obj.Cidade = null; // para o EFCore não tentar atualizar a cidade tambem... 
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
