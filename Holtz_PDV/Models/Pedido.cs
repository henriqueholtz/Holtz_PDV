using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models
{
    public class Pedido
    {
        [Display(Name = "Código")]
        [MaxLength(8)] [Key] 
        public int PedCod { get; set; }


        [Display(Name = "Código Cliente")]
        [MaxLength(8)] 
        public int PedCliCod { get; set; }


        [Display(Name = "Data Pedido")]
        public DateTime PedDta { get; set; }


        [Display(Name = "Status")]
        [Column(TypeName = Tipo.STATUS_PEDIDO)]
        public Status_Duplicata PedSts { get; set; } //Status
    }
}
