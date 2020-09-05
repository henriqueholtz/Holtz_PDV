using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
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
    }
}
