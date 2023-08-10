using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Placa).IsRequired().HasMaxLength(10);
            #endregion

            #region Índice Único
            builder.HasIndex(c => c.Placa).IsUnique();
            #endregion

            #region Relacionamentos
            builder.HasMany(r => r.RegistrosEntradasSaidas)
                    .WithOne(r => r.Carro)
                    .HasForeignKey(r => r.Carro_Id);
            builder.HasMany(r => r.Usuarios)
                    .WithMany(r => r.Carros);
            #endregion
        }
    }
}
