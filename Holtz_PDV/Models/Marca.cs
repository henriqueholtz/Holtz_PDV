using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using Holtz_PDV.Models.Enums;

namespace Holtz_PDV.Models
{
    public class Marca
    {
        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int MarCod { get; set; }


        [Display(Name = "Nome")]
        [Column(TypeName = Tipo.VARCHAR130)]
        public string MarNom { get; set; } = null!;
    }
}
