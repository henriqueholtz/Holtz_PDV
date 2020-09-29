using Holtz_PDV.Models.Enums;
using System.Collections.Generic;

namespace Holtz_PDV.Models
{
    public class Estado
    {
        public int EstCod { get; set; } //Código
        public string EstNom { get; set; } //Nome
        public UF EstUf { get; set; } //UF

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
