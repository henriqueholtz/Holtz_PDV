using System.Collections.Generic;

namespace Holtz_PDV.Models
{
    public interface IPaginatedListH<T> : IPaginatedListH, IEnumerable<T>
    {
    }
}
