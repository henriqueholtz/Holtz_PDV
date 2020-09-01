using System;
using System.Collections.Generic;
using Holtz_PDV.Models.Enums;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models
{
    public class Estado
    {

        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int EstCod { get; set; } //Código


        [Display(Name = "Nome")]
        [Column(TypeName = Tipo.VARCHAR050)]
        public string EstNom { get; set; } //Nome


        [Display(Name = "UF")]
        [Column(TypeName = Tipo.UF)]
        public UF EstUf { get; set; } //UF
    }
}
