using Holtz_PDV.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Holtz_PDV.Data;

namespace Holtz_PDV.Models.ModelsConfiguration
{
    public class CidadeConfiguration : EntityConfiguration<Cidade>, IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            DefaultConfigs(builder, tableName: "CIDADE");

            builder.HasKey(key => key.CidCod);
            builder.Property(x => x.CidCod)
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(p => p.CidNom)
                .HasColumnType(Tipo.VARCHAR050)
                .ValueGeneratedNever(); //Remove Identity


            builder.Property(x => x.EstadoEstCod)
                .HasColumnName("EstCod")
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedNever(); //não é AutoNumber

        }
    }
}
