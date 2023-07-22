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
    public class CarroConfiguration : EntityTypeConfiguration<Carro>
    {
        public CarroConfiguration()
        {
            #region Chave primária
            HasKey(k => k.Id);
            #endregion

            #region Propriedades
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Placa).IsRequired();
            #endregion

            #region Relacionamentos
            HasMany(r => r.RegistrosEntradasSaidas)
                .WithRequired(r => r.Carro)
                .HasForeignKey(r => r.Carro_Id);
            HasMany(r => r.UsuariosCarros)
                .WithRequired(r => r.Carro)
                .HasForeignKey(r => r.Carro_Id);
            #endregion
        }
    }
}
