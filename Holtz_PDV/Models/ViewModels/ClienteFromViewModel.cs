using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using Holtz_PDV.Models.Enums;
using Holtz_PDV.Services;

namespace Holtz_PDV.Models.ViewModels
{
    public class ClienteFromViewModel
    {
        public ClienteFromViewModel(ICollection<Cidade> cidades = null) //inicia com null
        {
            if (cidades == null)
            {
                Cidades = new List<Cidade>();
            }
            else
            {
                Cidades = cidades;
            }
        }


        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int CliCod { get; set; } //Código 


        [Display(Name = "Nome/Razão")]
        [Column(TypeName = Tipo.VARCHAR150)]
        [Required(ErrorMessage ="Obrigatório informar o Nome/Razão Social!")]
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
        [Required(ErrorMessage ="Obrigatório informar o STATUS!")]
        public Status_AtivoInativo? CliSts { get; set; } = Status_AtivoInativo.ATIVO; //Status // '?' => null = true


        [Display(Name = "CPF/CNPJ")]
        [Column(TypeName = Tipo.CPF_CNPJ)]
        [Required(ErrorMessage = "CPF/CNPJ é Obrigatório!")]
        [MinLength(11, ErrorMessage ="CPF/CNPJ inválido.")] [MaxLength(18, ErrorMessage = "CPF/CNPJ inválido.")] 
        public string CliCpfCnpj { get; set; } = null!; //CPF/CNPJ 


        [Display(Name = "TIPO")]
        [Column(TypeName = Tipo.TIPO_PESSOA)] 
        [Required(ErrorMessage ="Obrigatório informar o Tipo.")]
        public Tipo_Pessoa CliTip { get; set; } //Tipo

        public Cidade Cidade { get; set; } = null!;

        [Display(Name = "Cód. Cidade")]
        [MaxLength(8)] [Required(ErrorMessage ="Você deve selecionar uma cidade.")]
        public int? CidCod { get; set; }  //isso define como pk, e não deixa cadastrar null //CidCod tem q ser igualzinho



        //-----
        public ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}
