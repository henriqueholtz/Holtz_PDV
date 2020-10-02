using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models.ViewModels
{
    public class MarcaFromViewModel
    {
        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int MarCod { get; set; }


        [Display(Name = "Nome")]
        [Column(TypeName = Tipo.VARCHAR130)]
        [StringLength(130, MinimumLength = 3, ErrorMessage = "Nome da Marca deve conter de 3 a 130 caracteres.")]
        public string MarNom { get; set; } = null!;

        [Display(Name = "Status")]
        [Column(TypeName = Tipo.STATUS_ATIVO_INATIVO)]
        public Status_AtivoInativo? MarSts { get; set; } = Status_AtivoInativo.ATIVO;
    }
}
