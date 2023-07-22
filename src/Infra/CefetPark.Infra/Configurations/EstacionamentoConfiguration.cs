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
    public class EstacionamentoConfiguration : EntityTypeConfiguration<Estacionamento>
    {
        public EstacionamentoConfiguration()
        {
            #region Chave primária
            HasKey(k => k.Id);
            #endregion

            #region Propriedades
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).IsRequired();
            Property(p => p.QtdVagasTotal).IsRequired();
            Property(p => p.QtdVagasLivres).IsOptional();
            #endregion
        }
    }
}
