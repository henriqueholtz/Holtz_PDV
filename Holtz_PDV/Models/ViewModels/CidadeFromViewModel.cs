using System.Collections.Generic;

namespace Holtz_PDV.Models.ViewModels
{
    public class CidadeFromViewModel
    {
        public Cidade Cidade { get; set; }
        public ICollection<Estado> Estados { get; set; }
    }
}
