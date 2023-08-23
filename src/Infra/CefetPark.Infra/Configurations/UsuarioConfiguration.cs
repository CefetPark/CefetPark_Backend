using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Infra.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Cpf).IsRequired().HasMaxLength(11).IsFixedLength();
            builder.Property(p => p.Matricula).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.TelefonePrincipal).IsRequired().HasMaxLength(15);
            builder.Property(p => p.TelefoneSecundario).HasMaxLength(15);
            builder.Property(p => p.EmailPrincipal).IsRequired().HasMaxLength(50);
            builder.Property(p => p.EmailSecundario).HasMaxLength(50);
            #endregion

            #region Índice Único
            builder.HasIndex(c => c.Cpf).IsUnique();
            builder.HasIndex(c => c.Matricula).IsUnique();
            #endregion

            #region Relacionamentos
            builder.HasMany(r => r.RegistrosEntradasSaidas)
                    .WithOne(r => r.Usuario)
                    .HasForeignKey(r => r.Usuario_Id);
            #endregion
        }
    }
}
