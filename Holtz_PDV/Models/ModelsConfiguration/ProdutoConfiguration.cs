using Holtz_PDV.Data;
using Holtz_PDV.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Holtz_PDV.Models.ModelsConfiguration
{
    public class ProdutoConfiguration : EntityConfiguration<Produto>, IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            DefaultConfigs(builder, tableName: "Produto");

            builder.HasKey(key => key.ProCod);
            builder.Property(x => x.ProCod)
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.ProNom)
                .HasColumnType(Tipo.VARCHAR150)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.ProObs)
                .HasColumnType(Tipo.VARCHAR1000)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.ProSts)
                .HasColumnType(Tipo.STATUS_ATIVO_INATIVO)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.ProVlrCus)
                .HasColumnType(Tipo.MOEDA)
                .ValueGeneratedNever(); //Remove Identity

            builder.Property(x => x.ProVlrVen)
                .HasColumnType(Tipo.MOEDA)
                .ValueGeneratedNever(); //Remove Identity

            //builder.Property(x => x.ProNom)
            //    .HasColumnType(Tipo.VARCHAR150)
            //    .ValueGeneratedNever(); //Remove Identity
        }
    }
}
