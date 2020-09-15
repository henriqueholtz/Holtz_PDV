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
            builder.Property(p => p.CidNom)
                .HasColumnType(Tipo.VARCHAR050)
                .ValueGeneratedNever(); //Remove Identity
        }
    }
}
