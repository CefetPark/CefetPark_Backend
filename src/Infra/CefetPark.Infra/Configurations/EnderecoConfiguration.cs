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
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            #region Chave primária
            HasKey(k => k.Id);
            #endregion

            #region Propriedades
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).IsRequired();
            Property(p => p.Numero).IsRequired();
            Property(p => p.Complemento).IsOptional();
            Property(p => p.Bairro).IsRequired();
            Property(p => p.Cep).IsRequired();
            #endregion

            #region Relacionamentos
            //HasOne(r => r.Estacionamento)
            //    .WithMany(r => r.Endereco)
            //    .HasForeignKey(r => r.Endereco);
            #endregion
        }
    }
}
