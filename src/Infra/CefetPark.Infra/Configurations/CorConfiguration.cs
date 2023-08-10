using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class CorConfiguration : IEntityTypeConfiguration<Cor>
    {
        public void Configure(EntityTypeBuilder<Cor> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            #endregion

            #region Índice Único
            builder.HasIndex(c => c.Nome).IsUnique();
            #endregion

            #region Relacionamentos
            builder.HasMany(r => r.Carros)
                    .WithOne(r => r.Cor)
                    .HasForeignKey(r => r.Cor_Id);
            #endregion
        }
    }    
}
