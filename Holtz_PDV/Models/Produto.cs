using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models
{
    public class Produto
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
        public Status_AtivoInativo? ProSts { get; set; } //Status
    }
}
