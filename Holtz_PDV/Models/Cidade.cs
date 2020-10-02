using System.Collections.Generic;

namespace Holtz_PDV.Models
{
    public class Cidade
    {
        public Cidade(int cidCod, string cidNom, int estCod)
        {
            CidCod = cidCod;
            CidNom = cidNom;
            EstadoEstCod = estCod;
        }
        public Cidade()
        {
        }
        public int CidCod { get; set; } //Código
        public string CidNom { get; set; } //Nome

        public int? EstadoEstCod { get; set; }  //isso define como pk, e não deixa cadastrar null //EstCod tem q ser igualzinho
        public virtual Estado Estado { get; set; }
        public int? CidIBGE { get; set; } //Código IBGE

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
