﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Models
{
    public class Holtz_PDVContext : DbContext
    {
        public Holtz_PDVContext(DbContextOptions<Holtz_PDVContext> options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
