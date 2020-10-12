using System;
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models
{
    public class Pedido
    {
        public int PedCod { get; set; }
        public int? PedCliCod { get; set; }

        public DateTime? PedDtaEms { get; set; }
        public DateTime? PedDtaFat { get; set; }
        public Status_Pedido? PedSts { get; set; } //Status
    }
}
