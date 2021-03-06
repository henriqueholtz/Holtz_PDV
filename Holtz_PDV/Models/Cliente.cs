﻿using Holtz_PDV.Models.Enums;
using System.Collections.Generic;

namespace Holtz_PDV.Models
{
    public class Cliente
    {
        public int CliCod { get; set; } //Código 
        public string CliRaz { get; set; } = null!; //Nome/Razão Social 
        public string CliNomFan { get; set; } = null!; //Nome Fantasia 
        public string CliBai { get; set; } = null!; //Bairro
        public string CliRua { get; set; } = null!; //Rua
        public Status_AtivoInativo? CliSts { get; set; } = Status_AtivoInativo.ATIVO; //Status // '?' => null = true
        public string CliCpfCnpj { get; set; } = null!; //CPF/CNPJ 
        public int? CidadeCidCod { get; set; }  //isso define como fk, e não deixa cadastrar null //CidCod tem q ser igualzinho
        public virtual Cidade Cidade { get; set; }
        public Tipo_Pessoa CliTip { get; set; } //Tipo

        
        public virtual ICollection<ClienteEmails> ClienteEmails { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}
