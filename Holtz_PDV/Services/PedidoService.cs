using AutoMapper;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Services
{
    public class PedidoService
    {
        private readonly Holtz_PDVContext _context;
        private readonly IMapper _mapper;

        public PedidoService(Holtz_PDVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IOrderedQueryable<Pedido> FindAllQueryable()
        {
            return _context.Pedidos.Include(inc => inc.ClientePed).AsNoTracking().OrderBy(order => order.PedCod);
        }
        public async Task<Pedido> FindByCodAsync(int cod)
        {
            return await _context.Pedidos.Include(inc => inc.ClientePed).FirstOrDefaultAsync(x => x.PedCod == cod);
        }

        public async Task<ICollection<Pedido>> FindAllAsync()
        {
            return await _context.Pedidos.Include(inc => inc.ClientePed).OrderBy(order => order.PedCod).ToListAsync();
        }
    }
}
