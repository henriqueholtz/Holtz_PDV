using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models.Enums;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models
{
    public class Duplicata
    {
        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int CreCod { get; set; } //Código


        [Display(Name = "Status")]
        [Column(TypeName = Tipo.STATUS_DUPLICATA)]
        public Status_Duplicata? CreSts { get; set; } //Status


        [Display(Name = "Valor")]
        [Column(TypeName = Tipo.MOEDA)]
        public Moeda CreVlr { get; set; } = null!; //Valor


        [Display(Name = "Saldo")]
        [Column(TypeName = Tipo.MOEDA)]
        public Moeda CreSdo { get; set; } = null!; //Valor


        [Display(Name = "Dta Dup.")]
        public DateTime? CreDta { get; set; } //Data Duplicata


        [Display(Name = "Dta Vct.")]
        public DateTime? CreDtaVct { get; set; } //Data Vencimento
    }
}
