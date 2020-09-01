using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int CliCod { get; set; } //Código 


        [Display(Name = "Nome/Razão")]
        [Column(TypeName = Tipo.VARCHAR150)]
        public string CliRaz { get; set; } //Nome/Razão Social 


        [Display(Name = "Nome Fantasia")]
        [Column(TypeName = Tipo.VARCHAR150)]
        public string CliNomFan { get; set; } //Nome Fantasia 


        [Display(Name = "Endereço")]
        [Column(TypeName = Tipo.VARCHAR150)]
        public string CliEnd { get; set; } //Endereço

        [Display(Name = "Bairro")]
        [Column(TypeName = Tipo.VARCHAR130)]
        public string CliBai { get; set; } //Bairro


        [Display(Name = "Status")]
        [Column(TypeName = Tipo.STATUS_ATIVO_INATIVO)]
        public Status_AtivoInativo CliSts { get; set; } //Status


        [Display(Name = "CPF/CNPJ")]
        [Column(TypeName = Tipo.CPF_CNPJ)]
        public string CliCpfCnpj { get; set; } //CPF/CNPJ 
    }
}
