using Holtz_PDV.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models.ViewModels
{
    public class ProdutoFromViewModel
    {
        public ProdutoFromViewModel(ICollection<Marca> marcas = null, Produto produto = null)
        {
            if (marcas == null)
                Marcas = new List<Marca>();
            else
                Marcas = marcas;

            if (produto != null)
            {
                ProCod = produto.ProCod;
                ProNom = produto.ProNom;
                ProObs = produto.ProObs;
                ProVlrCus = produto.ProVlrCus;
                ProVlrVen = produto.ProVlrVen;
                Marca = produto.Marca;
                MarcaMarCod = produto.MarcaMarCod;
            }
        }


        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int ProCod { get; set; } //Código 

        [Display(Name = "Nome")]
        [Column(TypeName = Tipo.VARCHAR150)]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Nome do Produto deve conter de 3 a 150 caracteres.")]
        public string ProNom { get; set; } = null!; //Nome 


        [Display(Name = "Obs.")]
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

        [Display(Name = "Cód. Marca")]
        [MaxLength(8)]
        [Required(ErrorMessage = "Você deve selecionar uma Marca.")]
        public int? MarcaMarCod { get; set; }  //isso define como pk, e não deixa cadastrar null //CidCod tem q ser igualzinho

        [Display(Name = "Marca")]
        public Marca Marca { get; set; } = null!;



        //-----
        [Display(Name = "Marcas")]
        public ICollection<Marca> Marcas { get; set; } = new List<Marca>();
    }
}
