using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models
{
    public class Produto
    {
        public int ProCod { get; set; } //Código 

        public string ProNom { get; set; } = null!; //Nome 

        public string ProObs { get; set; } = null!;

        public Status_AtivoInativo? ProSts { get; set; } = Status_AtivoInativo.ATIVO; //Status

        public double ProVlrVen { get; set; }

        public double ProVlrCus { get; set; }
        public int? MarcaMarCod { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
