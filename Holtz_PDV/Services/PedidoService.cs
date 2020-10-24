using AutoMapper;
using Holtz_PDV.Models;
using Holtz_PDV.Models.ViewModels;
using Holtz_PDV.Services.Exceptions;
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

        public async Task<List<Pedido>> FindAllAsync()
        {
            return await _context.Pedidos.Include(inc => inc.ClientePed).OrderBy(order => order.PedCod).ToListAsync();
        }

        public async Task UpdateAsync(Pedido obj)
        {
            bool hasAny = await _context.Pedidos.AnyAsync(x => x.PedCod == obj.PedCod);
            if (!hasAny)
            {
                throw new NotFoundException("Código não existe!");
            }
            try
            {
                //ToUpper(obj);
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) //exceção do banco de dados
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task InsertAsync(Pedido obj)
        {
            try
            {
                //ToUpper(obj);
                _context.Pedidos.Add(obj);
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
                var obj = await _context.Pedidos.FindAsync(cod);
                _context.Pedidos.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) //vem do banco
            {
                throw new IntegrityException("Não é possível excluir este Cliente.");
            }
        }
    }
}
