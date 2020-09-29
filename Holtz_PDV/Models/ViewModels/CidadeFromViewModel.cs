using System.Collections.Generic;
using Holtz_PDV.Models.Enums;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models.ViewModels
{
    public class CidadeFromViewModel
    {
        public CidadeFromViewModel(ICollection<Estado> estados = null, Cidade cidade = null)
        {
            if (estados == null)
            {
                Estados = new List<Estado>();
            }
            else
            {
                Estados = estados;
            }
            if (cidade != null)
            {
                CidCod = cidade.CidCod;
                CidNom = cidade.CidNom;
                CidIBGE = cidade.CidIBGE;
                Estado = cidade.Estado;
                //Estado.EstUf = cidade.Estado.EstUf;
                EstCod = cidade.EstadoEstCod;
            }
        }
       

        public ICollection<Estado> Estados{ get; set; }

        [Display(Name = "Código")]
        [MaxLength(8)] [Key]
        public int CidCod { get; set; } //Código


        [Display(Name = "Nome")]
        [Column(TypeName = Tipo.VARCHAR050)]
        [Required(ErrorMessage ="Informe o nome da Cidade.")]
        public string CidNom { get; set; } //Nome

        [Display(Name = "IBGE")]
        [MaxLength(8)]
        public int? CidIBGE { get; set; } //Código IBGE

        public Estado Estado { get; set; } = null!;
        [Display(Name = "Cód. Estado")]
        [MaxLength(8)]
        public int? EstCod { get; set; }  //isso define como pk, e não deixa cadastrar null //EstCod tem q ser igualzinho
    }
}
