using Holtz_PDV.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Holtz_PDV.Data;

namespace Holtz_PDV.Models.ModelsConfiguration
{
    public class ClienteConfiguration : EntityConfiguration<Cliente>, IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            DefaultConfigs(builder, tableName: "CLIENTE");

            builder.HasKey(key => key.CliCod);
            builder.Property(x => x.CliCod)
                .HasDefaultValue(0)
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedOnAdd();
            //.ValueGeneratedNever(); //não é AutoNumber

            builder.Property(x => x.CliRaz)
                .HasColumnType(Tipo.VARCHAR150);

            builder.Property(x => x.CliNomFan)
                .HasColumnType(Tipo.VARCHAR150);

            builder.Property(x => x.CliSts)
                .HasColumnType(Tipo.STATUS_ATIVO_INATIVO);

            builder.Property(x => x.CliRua)
                .HasColumnType(Tipo.VARCHAR100);

            builder.Property(x => x.CliBai)
                .HasColumnType(Tipo.VARCHAR130);

            builder.Property(x => x.CliCpfCnpj)
                .HasColumnType(Tipo.CPF_CNPJ);

            builder.Property(x => x.CliTip)
                .HasColumnType(Tipo.TIPO_PESSOA);

            builder.Property(x => x.CidadeCidCod)
                .HasColumnName("CidCod")
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedNever(); //não é AutoNumber
        }
    }
}
