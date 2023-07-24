﻿using CefetPark.Domain.Entidades;
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
