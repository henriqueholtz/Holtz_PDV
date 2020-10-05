using Holtz_PDV.Models.Enums;
using System.Collections;
using System.Collections.Generic;

namespace Holtz_PDV.Models
{
    public class Marca
    {
        public int MarCod { get; set; }

        public string MarNom { get; set; } = null!;

        public Status_AtivoInativo? MarSts { get; set; } = Status_AtivoInativo.ATIVO;

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
