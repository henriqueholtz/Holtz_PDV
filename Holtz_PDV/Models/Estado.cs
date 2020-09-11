using System;
using System.Collections.Generic;
using Holtz_PDV.Models.Enums;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models
{
    public class Estado
    {
        public int EstCod { get; set; } //Código
        public string EstNom { get; set; } //Nome
        public UF EstUf { get; set; } //UF
    }
}
