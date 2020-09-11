using Holtz_PDV.Models.Enums;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models.ViewModels
{
    public class EstadoFromViewModel
    {

        [Display(Name = "Código")] [Key]
        [Range(1, 8, ErrorMessage = "Código Inválido.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EstCod { get; set; } //Código


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Necessário informar o nome do Estado!")]
        [Column(TypeName = Tipo.VARCHAR050)]
        public string EstNom { get; set; } //Nome


        [Display(Name = "UF")]
        [Required(ErrorMessage = "Necessário informar a UF do Estado!")]
        [Column(TypeName = Tipo.UF)]
        public UF EstUf { get; set; } //UF
    }
}
