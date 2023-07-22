﻿using CefetPark.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Infra.Configurations
{
    public class ModeloConfiguration : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfiguration()
        {
            #region Chave primária
            HasKey(k => k.Id);
            #endregion

            #region Propriedades
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).IsRequired();
            #endregion

            #region Relacionamentos
            HasMany(r => r.Carros)
                .WithRequired(r => r.Modelo)
                .HasForeignKey(r => r.Modelo_Id);
            #endregion
        }
    }
}
