using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class TipoLogradouroConfiguration : IEntityTypeConfiguration<TipoLogradouro>
    {
        public void Configure(EntityTypeBuilder<TipoLogradouro> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(20);
            #endregion

            #region Relacionamentos
            builder.HasMany(r => r.Enderecos)
                    .WithOne(r => r.TipoLogradouro)
                    .HasForeignKey(r => r.TipoLogradouro_Id);
            #endregion
        }
    }
}
