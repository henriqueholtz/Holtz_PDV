using AutoMapper;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

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

        //public IOrderedQueryable<Pedido> FindAllQueryableView()
        //{
            //da exceção no cast para IOrderedQueryable => ReflectionIT.Mvc.Paging;
            //var list = _context.Pedidos.AsNoTracking().OrderBy(order => order.PedCod);
            //var listReturn = _mapper.Map<IOrderedQueryable<PedidoFromViewModel>>(list);
            //return listReturn;

            
        //}
        
        public IPagedList<Pedido> FindALLPaged(int page = 1)
        {
            //using X.PagedList;
            //tentar fazer igual o  FindAllQueryableView() - converter para PedidoFromViewModel
            return _context.Pedidos.ToPagedList(page, 5);
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
