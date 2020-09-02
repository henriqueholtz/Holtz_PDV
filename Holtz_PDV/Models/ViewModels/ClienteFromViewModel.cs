using System.Collections.Generic;

namespace Holtz_PDV.Models.ViewModels
{
    public class ClienteFromViewModel
    {
        public Cliente Cliente { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
    }
}
