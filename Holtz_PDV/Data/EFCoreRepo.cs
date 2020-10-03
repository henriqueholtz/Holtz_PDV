using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Data;
using Microsoft.EntityFrameworkCore;
using Holtz_PDV.Models;

namespace Holtz_PDV.Data
{
    public class EFCoreRepo : IEFCore
    {
        private readonly Holtz_PDVContext _context;
        public EFCoreRepo(Holtz_PDVContext context)
        {
            _context = context;
        }

        public void Add<t>(t entity) where t : class
        {
            _context.Add(entity);
        }
        public void Update<t>(t entity) where t : class
        {
            _context.Update(entity);
        }
        public void Delete<t>(t entity) where t : class
        {
            _context.Remove(entity);
        }

        public void Clear()
        {
            _context.Dispose();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; //waiting while this context saving changes, return after. 
        }

        public void AddRange<t>(ICollection<t> entities) where t : class
        {
            _context.AddRange(entities);
        }
    }
}
