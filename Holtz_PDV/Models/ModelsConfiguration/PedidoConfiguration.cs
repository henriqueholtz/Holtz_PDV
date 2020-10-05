using Holtz_PDV.Data;
using Holtz_PDV.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Models.ModelsConfiguration
{
    public class PedidoConfiguration : EntityConfiguration<Pedido>, IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            DefaultConfigs(builder, tableName: "Pedido");

            builder.HasKey(key => key.PedCod);
            builder.Property(x => x.PedCod)
                .HasColumnType(Tipo.CODIGO)
                .HasDefaultValueSql("NEXT VALUE FOR Seq_PedCod"); //Use Sequence-SQL

            builder.Property(x => x.PedCliCod)
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.PedDtaEms)
                .HasColumnType(Tipo.DATETIME)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.PedDtaFat)
                .HasColumnType(Tipo.DATETIME)
                .ValueGeneratedNever(); //Remove Identity
        }
    }
}
