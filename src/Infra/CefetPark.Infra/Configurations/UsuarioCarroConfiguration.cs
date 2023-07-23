using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class UsuarioCarroConfiguration : IEntityTypeConfiguration<UsuarioCarro>
    {
        public void Configure(EntityTypeBuilder<UsuarioCarro> builder)
        {
            #region Chave primária
            builder.HasKey(k => new { k.Usuario_Id, k.Carro_Id });
            #endregion

            #region Relacionamentos
            builder.HasOne(r => r.Usuario)
                    .WithMany(r => r.UsuariosCarros)
                    .HasForeignKey(r => r.Usuario_Id);
            builder.HasOne(r => r.Carro)
                    .WithMany(r => r.UsuariosCarros)
                    .HasForeignKey(r => r.Carro_Id);
            #endregion
        }
    }
}
