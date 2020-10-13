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
    public class UsuarioConfiguration : EntityConfiguration<Usuario>, IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            DefaultConfigs(builder, tableName: "Usuario");

            builder.HasKey(key => key.UsuCod);
            builder.Property(x => x.UsuCod)
                .HasColumnType(Tipo.CODIGO)
                .HasDefaultValueSql("NEXT VALUE FOR Seq_UsuCod"); //Use Sequence-SQL


            builder.Property(p => p.UsuNom)
                .HasColumnType(Tipo.VARCHAR050)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(p => p.UsuSen)
                .HasColumnType(Tipo.VARCHAR500)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.UsuSts)
                .HasColumnType(Tipo.STATUS_ATIVO_INATIVO);
        }
    }
}
