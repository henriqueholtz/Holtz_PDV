using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models.Enums;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models
{
    public class Cidade
    {
        [Display(Name = "Código")]
        [MaxLength(8)][Key]
        public int CidCod { get; set; } //Código


        [Display(Name = "Nome")]
        [Column(TypeName = Tipo.VARCHAR050)]
        public string CidNom { get; set; } //Nome

        [Display(Name = "IBGE")]
        [MaxLength(8)]
        public int CidIBGE { get; set; } //Código IBGE

        public Estado Estado { get; set; }
        [Display(Name = "Cód. Estado")]
        [MaxLength(8)]
        public int EstCod { get; set; }  //isso define como pk, e não deixa cadastrar null //EstCod tem q ser igualzinho
    }
}
