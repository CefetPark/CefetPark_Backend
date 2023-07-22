using CefetPark.Domain.Entidades;
using CefetPark.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CefetPark.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<RegistroEntradaSaida> RegistrosEntradasSaidas { get; set; }
        public DbSet<TipoLogradouro> TiposLogradouros { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioCarro> UsuariosCarros { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    this.ObterDataCriacao(entry);
                }
                if (entry.State == EntityState.Modified)
                {
                    this.ObterDataAtualizacao(entry);
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        private void ObterDataCriacao(EntityEntry entry)
        {
            if (entry.Entity.GetType().GetProperty("DataCriacao") != null)
            {
                entry.Property("DataCriacao").CurrentValue = DateTime.Now;
            }
        }
        private void ObterDataAtualizacao(EntityEntry entry)
        {
            if (entry.Entity.GetType().GetProperty("DataAtualizacao") != null)
            {
                entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
            }
            if (entry.Entity.GetType().GetProperty("DataCriacao") != null)
            {
                entry.Property("DataCriacao").IsModified = false;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //remover a pluralização padrão do Etity Framework que é em inglês
            //modelBuilder(Remove<PluralizingTableNameConvention>());

            ///*Desabilitar o delete em cascata em relacionamentos 1:N evitando
            // ter registros filhos     sem registros pai*/
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            ////Basicamente a mesma configuração, porém em relacionamenos N:N
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.ApplyConfiguration(new CorConfiguration());

            ///*Toda propriedade do tipo string na entidade POCO
            // seja configurado como VARCHAR no SQL Server*/
            //modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            ///*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (150) no banco de dados */
            //modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(150));
            //new CorConfiguration().CorConfiguration(modelBuilder.Entity<Cor>());
            //modelBuilder.Configurations.Add(new CarroConfiguration());
            //CorConfiguration corConfiguration = new CorConfiguration();
            //modelBuilder.ApplyConfiguration<CorConfiguration>(corConfiguration);
        }
    }
}
