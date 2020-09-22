using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models
{
    public class Marca
    {
        public int MarCod { get; set; }

        public string MarNom { get; set; } = null!;

        public Status_AtivoInativo? MarSts { get; set; } = Status_AtivoInativo.ATIVO;
    }
}
