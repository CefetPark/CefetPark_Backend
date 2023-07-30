using CefetPark.Domain.Entidades;
using CefetPark.Domain.Interfaces.Models;
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
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        private readonly IUser _user;
        public DataContext(DbContextOptions<DataContext> options, IUser user) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _user = user;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    this.ObterDataCriacao(entry);
                    this.ObterCriadoPor(entry);
                }
                if (entry.State == EntityState.Modified)
                {
                    this.ObterAtualizadoPor(entry);
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
        private void ObterCriadoPor(EntityEntry entry)
        {
            var propriedade = "CriadoPor";
            if (entry.Entity.GetType().GetProperty(propriedade) != null)
            {
                entry.Property(propriedade).CurrentValue = _user.ObterUsuarioId();
            }
        }
        private void ObterAtualizadoPor(EntityEntry entry)
        {
            var propriedade = "AtualizadoPor";
            if (entry.Entity.GetType().GetProperty(propriedade) != null)
            {
                entry.Property(propriedade).CurrentValue = _user.ObterUsuarioId();
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
