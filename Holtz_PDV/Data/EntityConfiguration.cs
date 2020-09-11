using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; //EntityTypeBuilder
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holtz_PDV.Data
{
    public class EntityConfiguration<TEntity> where TEntity : class
    {
        //Definir configuração padrões
        public void DefaultConfigs(EntityTypeBuilder<TEntity> builder, string tableName)
        {
            builder.ToTable(tableName);

            //Others examples
            //builder.HasKey(x => x.UId);
            //builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
