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
    public class ClienteEmailsConfiguration : EntityConfiguration<ClienteEmails>, IEntityTypeConfiguration<ClienteEmails>
    {
        public void Configure(EntityTypeBuilder<ClienteEmails> builder)
        {
            DefaultConfigs(builder, tableName: "ClienteEmails");

            builder.HasKey(key => key.CliCod);
            builder.Property(x => x.CliCod)
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedNever(); //não é AutoNumber


            builder.HasKey(key => key.CliEmlCod);
            builder.Property(x => x.CliEmlCod)
                .HasColumnType(Tipo.CODIGO)
                .ValueGeneratedNever(); //não é AutoNumber

            builder.Property(x => x.CliEml)
                .HasColumnType(Tipo.VARCHAR100);

            builder.Property(x => x.CliEmlCon)
                .HasColumnType(Tipo.VARCHAR050);
        }
    }
}
