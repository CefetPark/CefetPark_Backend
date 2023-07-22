using CefetPark.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Infra.Configurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            #region Chave primária
            HasKey(k => k.Id);
            #endregion

            #region Propriedades
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Cpf).IsRequired();
            Property(p => p.Matricula).IsRequired();
            Property(p => p.Nome).IsRequired();
            Property(p => p.TelefonePrincipal).IsRequired();
            Property(p => p.TelefoneSecundario).IsOptional();
            Property(p => p.EmailPrincipal).IsRequired();
            Property(p => p.EmailSecundario).IsOptional();
            Property(p => p.Senha).IsRequired();
            Property(p => p.Bloqueado).IsRequired();
            #endregion

            #region Relacionamentos
            HasMany(r => r.RegistrosEntradasSaidas)
                .WithRequired(r => r.Usuario)
                .HasForeignKey(r => r.Usuario_Id);
            HasMany(r => r.UsuariosCarros)
                .WithRequired(r => r.Usuario)
                .HasForeignKey(r => r.Usuario_Id);
            #endregion
        }
    }
}
