using Holtz_PDV.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Services
{
    public class PedidoService
    {
        private readonly Holtz_PDVContext _context;

        public PedidoService(Holtz_PDVContext context)
        {
            _context = context;
        }

        public IOrderedQueryable<Pedido> FindAllQueryable()
        {
            return _context.Pedidos.AsNoTracking().OrderBy(order => order.PedCod);
        }
        public async Task<Pedido> FindByCodAsync(int cod)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(x => x.PedCod == cod);
        }

        public async Task<ICollection<Pedido>> FindAllAsync()
        {
            return await _context.Pedidos.OrderBy(order => order.PedCod).ToListAsync();
        }
    }
}
