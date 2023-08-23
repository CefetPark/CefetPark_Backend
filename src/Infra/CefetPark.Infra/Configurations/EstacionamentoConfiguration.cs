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
    public class EstacionamentoConfiguration : IEntityTypeConfiguration<Estacionamento>
    {
        public void Configure(EntityTypeBuilder<Estacionamento> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Property(p => p.QtdVagasTotal).IsRequired();
            builder.Property(p => p.QtdVagasLivres).IsRequired();
            #endregion

            #region Índice Único
            builder.HasIndex(c => c.Nome).IsUnique();
            #endregion

            #region Relacionamentos
            builder.HasOne(r => r.Endereco)
                    .WithOne(r => r.Estacionamento)
                    .HasForeignKey<Estacionamento>(r => r.Endereco_Id);
            builder.HasMany(r => r.RegistrosEntradasSaidas)
                    .WithOne(r => r.Estacionamento)
                    .HasForeignKey(r => r.Estacionamento_Id);
            #endregion
        }
    }
}
