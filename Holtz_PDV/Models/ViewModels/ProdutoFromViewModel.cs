using System.Collections.Generic;

namespace Holtz_PDV.Models.ViewModels
{
    public class ProdutoFromViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Marca> Marcas { get; set; }
    }
}
