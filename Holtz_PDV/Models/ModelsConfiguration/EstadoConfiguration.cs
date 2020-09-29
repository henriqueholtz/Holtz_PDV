using Microsoft.EntityFrameworkCore;
using Holtz_PDV.Models.Enums;
using Holtz_PDV.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holtz_PDV.Models.ModelsConfiguration
{
    public class EstadoConfiguration : EntityConfiguration<Estado>, IEntityTypeConfiguration<Estado>
    {
        public void Configure (EntityTypeBuilder<Estado> builder)
        {
            DefaultConfigs(builder, tableName: "ESTADO");

            builder.HasKey(key => key.EstCod);
            builder.Property(x => x.EstCod)
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedOnAdd();
                //.ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.EstNom)
                .HasColumnType(Tipo.VARCHAR050)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.EstUf)
                .HasColumnType(Tipo.UF)
                .ValueGeneratedNever(); //Remove Identity
        }
    }
}
