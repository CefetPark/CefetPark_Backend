using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            #endregion

            #region Índice Único
            builder.HasIndex(c => c.Nome).IsUnique();
            #endregion

            #region Relacionamentos
            builder.HasMany(r => r.Usuarios)
                    .WithOne(r => r.Departamento)
                    .HasForeignKey(r => r.Departamento_Id);
            #endregion
        }
    }
}
