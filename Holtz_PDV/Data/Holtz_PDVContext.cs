using Microsoft.EntityFrameworkCore;
using Holtz_PDV.Models.ModelsConfiguration;
using System.Linq;
using Holtz_PDV.Models.ViewModels;

namespace Holtz_PDV.Models
{
    public class Holtz_PDVContext : DbContext
    {
        public Holtz_PDVContext(DbContextOptions<Holtz_PDVContext> options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<ClienteEmails> ClienteEmails { get; set; }
        //public Usuario Login { get; }
        //Context não tem acesso a lista de usuarios diretamente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentApi -> ApplyConfiguration
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());
            modelBuilder.ApplyConfiguration(new CidadeConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfiguration(new ClienteEmailsConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new MarcaConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            //modelBuilder.ApplyConfiguration(new UsuarioConfiguration());


            //Disable DeleteBehavior.Cascade
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;  //Para não deletar e atualizar em cascata !!?
            }

            //Sequencies => Default SQL: Start = 1,  Increment = 1
            modelBuilder.HasSequence<int>("Seq_ProCod");
            modelBuilder.HasSequence<int>("Seq_MarCod"); 
            modelBuilder.HasSequence<int>("Seq_PedCod");
            modelBuilder.HasSequence<int>("Seq_UsuCod");
            modelBuilder.HasSequence<int>("Seq_CliEmlCod");
        }
    }
}
