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
    public class RegistroEntradaSaidaConfiguration : EntityTypeConfiguration<RegistroEntradaSaida>
    {
        public RegistroEntradaSaidaConfiguration()
        {
            #region Chave primária
            HasKey(k => k.Id);
            #endregion

            #region Propriedades
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.DataEntrada).IsRequired();
            Property(p => p.DataSaida).IsOptional();
            #endregion

            #region Relacionamentos
            //this.HasRequired(r => r.Usuario_Id).WithMany().HasForeignKey(r => r.Usuario_Id);
            //this.HasRequired(r => r.Carro_Id).WithMany().HasForeignKey(r => r.Carro_Id);
            #endregion
        }
    }
}
