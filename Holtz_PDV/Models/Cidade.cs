﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holtz_PDV.Models.Enums;
using System.ComponentModel.DataAnnotations; //MaxLenght and Key
using System.ComponentModel.DataAnnotations.Schema; //Column and TypeName

namespace Holtz_PDV.Models
{
    public class Cidade
    {
        public int CidCod { get; set; } //Código
        public string CidNom { get; set; } //Nome

        [ForeignKey("Estado")]
        public int? EstCod { get; set; }  //isso define como pk, e não deixa cadastrar null //EstCod tem q ser igualzinho
        public virtual Estado Estado { get; set; } = null!;
        public int? CidIBGE { get; set; } //Código IBGE
    }
}
