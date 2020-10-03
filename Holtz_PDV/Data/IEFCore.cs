using System.Collections.Generic;
using System.Threading.Tasks;

namespace Holtz_PDV.Data
{
    public interface IEFCore
    {
        void Add<t>(t entity) where t : class;
        void AddRange<t>(ICollection<t> entities) where t : class;
        void Update<t>(t entity) where t : class;
        void Delete<t>(t entity) where t : class;
        void Clear();
        Task<bool> SaveChangeAsync();
        void SaveChange();
    }
}
