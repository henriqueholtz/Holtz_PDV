using Holtz_PDV.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
