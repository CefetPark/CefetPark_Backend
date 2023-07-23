using CefetPark.Domain.Entidades;
using CefetPark.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


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
            // Configuração para desabilitar a pluralização
            modelBuilder.Entity<Carro>().ToTable("Carro"); 
            modelBuilder.Entity<Cor>().ToTable("Cor"); 
            modelBuilder.Entity<Departamento>().ToTable("Departamento"); 
            modelBuilder.Entity<Endereco>().ToTable("Endereco"); 
            modelBuilder.Entity<Estacionamento>().ToTable("Estacionamento"); 
            modelBuilder.Entity<Marca>().ToTable("Marca"); 
            modelBuilder.Entity<Modelo>().ToTable("Modelo"); 
            modelBuilder.Entity<RegistroEntradaSaida>().ToTable("RegistroEntradaSaida"); 
            modelBuilder.Entity<TipoLogradouro>().ToTable("TipoLogradouro"); 
            modelBuilder.Entity<TipoUsuario>().ToTable("TipoUsuario"); 
            modelBuilder.Entity<Usuario>().ToTable("Usuario"); 
            modelBuilder.Entity<UsuarioCarro>().ToTable("UsuarioCarro");

            // Configuração para remover as convenções de cascata de exclusão
            /* ao excluir um registro pai, o Entity Framework Core não excluirá automaticamente
             * os registros filhos relacionados.Em vez disso, você precisará gerenciar manualmente
             * a exclusão de registros dependentes.*/
            // Para relações um-para-muitos (OneToMany)
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // Para relações muitos-para-muitos (ManyToMany)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var navigation in entity.GetNavigations())
                {
                    navigation.ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

            //modelBuilder.Entity<Carro>();
            //modelBuilder.Entity<Cor>();
            //modelBuilder.Entity<Departamento>();
            //modelBuilder.Entity<Endereco>();
            //modelBuilder.Entity<Estacionamento>();
            //modelBuilder.Entity<Marca>();
            //modelBuilder.Entity<Modelo>();
            //modelBuilder.Entity<RegistroEntradaSaida>();
            //modelBuilder.Entity<TipoLogradouro>();
            //modelBuilder.Entity<TipoUsuario>();
            //modelBuilder.Entity<Usuario>();
            //modelBuilder.Entity<UsuarioCarro>();

            modelBuilder.ApplyConfiguration(new CarroConfiguration());
            modelBuilder.ApplyConfiguration(new CorConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentoConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new EstacionamentoConfiguration());
            modelBuilder.ApplyConfiguration(new MarcaConfiguration());
            modelBuilder.ApplyConfiguration(new ModeloConfiguration());
            modelBuilder.ApplyConfiguration(new RegistroEntradaSaidaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoLogradouroConfiguration());
            modelBuilder.ApplyConfiguration(new TipoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioCarroConfiguration());
        }
    }
}
