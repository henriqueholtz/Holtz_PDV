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
    public class MarcaConfiguration : EntityConfiguration<Marca>, IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            DefaultConfigs(builder, tableName: "MARCA");

            builder.HasKey(key => key.MarCod);
            builder.Property(x => x.MarCod)
                .HasColumnType(Tipo.CODIGO)
                .HasDefaultValueSql("NEXT VALUE FOR Seq_MarCod"); //Use Sequence-SQL
                //.ValueGeneratedOnAdd();
                //.ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.MarNom)
                .HasColumnType(Tipo.VARCHAR130)
                .ValueGeneratedNever(); //não é AutoNumber

            builder.Property(x => x.MarSts)
                .HasColumnType(Tipo.STATUS_ATIVO_INATIVO)
                .ValueGeneratedNever(); //não é AutoNumber

            //builder.Property(x => x.MarCod)
            //    .HasColumnType(Tipo.CODIGO)
            //    .ValueGeneratedNever(); //não é AutoNumber
        }
    }
}
