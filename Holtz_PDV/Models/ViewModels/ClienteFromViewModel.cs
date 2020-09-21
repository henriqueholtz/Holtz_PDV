using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models.ViewModels
{
    public class ClienteFromViewModel
    {
        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int CliCod { get; set; } //Código 


        [Display(Name = "Nome/Razão")]
        [Column(TypeName = Tipo.VARCHAR150)]
        public string CliRaz { get; set; } = null!; //Nome/Razão Social 


        [Display(Name = "Nome Fantasia")]
        [Column(TypeName = Tipo.VARCHAR150)]
        public string CliNomFan { get; set; } = null!; //Nome Fantasia 


        [Display(Name = "Bairro")]
        [Column(TypeName = Tipo.VARCHAR130)]
        public string CliBai { get; set; } = null!; //Bairro


        [Display(Name = "Rua")]
        [Column(TypeName = Tipo.VARCHAR100)]
        public string CliRua { get; set; } = null!; //Rua


        [Display(Name = "Status")]
        [Column(TypeName = Tipo.STATUS_ATIVO_INATIVO)]
        public Status_AtivoInativo? CliSts { get; set; } = Status_AtivoInativo.ATIVO; //Status // '?' => null = true


        [Display(Name = "CPF/CNPJ")]
        [Column(TypeName = Tipo.CPF_CNPJ)]
        public string CliCpfCnpj { get; set; } = null!; //CPF/CNPJ 

        public Cidade Cidade { get; set; } = null!;

        [Display(Name = "Cód. Cidade")]
        [MaxLength(8)]
        public int? CidCod { get; set; }  //isso define como pk, e não deixa cadastrar null //CidCod tem q ser igualzinho



        //-----
        public ICollection<Cidade> Cidades { get; set; }
    }
}
