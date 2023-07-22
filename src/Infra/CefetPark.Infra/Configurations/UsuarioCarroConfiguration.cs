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
    public class UsuarioCarroConfiguration : EntityTypeConfiguration<UsuarioCarro>
    {
        public UsuarioCarroConfiguration()
        {
            #region Chave primária
            HasKey(k => new { k.Usuario_Id, k.Carro_Id });
            #endregion

            #region Relacionamentos
            HasRequired(r => r.Usuario)
                .WithMany(r => r.UsuariosCarros)
                .HasForeignKey(r => r.Usuario_Id);
            HasRequired(r => r.Carro)
                .WithMany(r => r.UsuariosCarros)
                .HasForeignKey(r => r.Carro_Id);
            #endregion
        }
    }
}
