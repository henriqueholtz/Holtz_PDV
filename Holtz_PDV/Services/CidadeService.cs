using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models;
using Microsoft.EntityFrameworkCore; //ToListAsync

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
            //return await _context.Cidades.OrderBy(x => x.CidNom).ToListAsync();
            return await _context.Cidades.ToListAsync();
        }
    }
}
