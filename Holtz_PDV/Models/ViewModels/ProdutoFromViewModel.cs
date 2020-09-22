﻿using Holtz_PDV.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models.ViewModels
{
    public class ProdutoFromViewModel
    {
        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int ProCod { get; set; } //Código 

        [Display(Name = "Nome")]
        [Column(TypeName = Tipo.VARCHAR150)]
        public string ProNom { get; set; } = null!; //Nome 


        [Column(TypeName = Tipo.VARCHAR1000)]
        public string ProObs { get; set; } = null!;


        [Display(Name = "Status")]
        [Column(TypeName = Tipo.STATUS_ATIVO_INATIVO)]
        public Status_AtivoInativo? ProSts { get; set; } = Status_AtivoInativo.ATIVO; //Status


        [Display(Name = "Valor Venda")]
        [Column(TypeName = Tipo.MOEDA)]
        [DisplayFormat(DataFormatString = "{0:F2}")] //Duas casas decimais
        public double ProVlrVen { get; set; }


        [Display(Name = "Valor Custo")]
        [Column(TypeName = Tipo.MOEDA)]
        [DisplayFormat(DataFormatString = "{0:F2}")] //Duas casas decimais
        public double ProVlrCus { get; set; }
    }
}
