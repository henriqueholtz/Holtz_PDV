using Holtz_PDV.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName
using System.Linq;

namespace Holtz_PDV.Models.ViewModels
{
    public class EstadoFromViewModel
    {

        public EstadoFromViewModel()
        {
            Array values = Enum.GetValues(typeof(UF));
            List<UF> items = values.OfType<UF>().ToList();
            UFs = items;
        }

        [Display(Name = "Código")] [Key]
        [Range(1, 8, ErrorMessage = "Código Inválido.")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EstCod { get; set; } //Código


        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Necessário informar o nome do Estado!")]
        [Column(TypeName = Tipo.VARCHAR050)]
        [Range(1, 50, ErrorMessage = "Nome deve conter no máximo 50 caracteres")]
        public string EstNom { get; set; } //Nome


        [Display(Name = "UF")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Necessário informar a UF do Estado!")]
        [Column(TypeName = Tipo.UF)]
        [Range(2, 2, ErrorMessage = "UF deve conter 2 caracteres.")]
        public UF EstUf { get; set; } //UF

        public List<UF> UFs { get; }
    }
}
