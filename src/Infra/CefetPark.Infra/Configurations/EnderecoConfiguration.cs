using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Numero).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Complemento).HasMaxLength(50);
            builder.Property(p => p.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Cep).IsRequired().HasMaxLength(8).IsFixedLength();
            #endregion
        }
    }
}
