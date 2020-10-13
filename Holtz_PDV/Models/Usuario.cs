using Holtz_PDV.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Models
{
    public class Usuario
    {
        public int UsuCod { get; set; }
        public string UsuNom { get; set; }
        public string  UsuSen { get; set; }
        public Status_AtivoInativo? UsuSts { get; set; }
    }
}
