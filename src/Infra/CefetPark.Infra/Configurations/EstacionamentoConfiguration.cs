using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class EstacionamentoConfiguration : IEntityTypeConfiguration<Estacionamento>
    {
        public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Property(p => p.QtdVagasTotal).IsRequired();
            builder.Property(p => p.QtdVagasLivres).IsRequired();
            #endregion

            #region Índice Único
            builder.HasIndex(c => c.Nome).IsUnique();
            #endregion

            #region Relacionamentos
            builder.HasOne(r => r.Endereco)
                    .WithOne(r => r.Estacionamento)
                    .HasForeignKey<Estacionamento>(r => r.Endereco_Id);
            builder.HasMany(r => r.RegistrosEntradasSaidas)
                    .WithOne(r => r.Estacionamento)
                    .HasForeignKey(r => r.Estacionamento_Id);
            #endregion
        }
    }
}
