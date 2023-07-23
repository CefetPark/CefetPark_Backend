﻿using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CefetPark.Infra.Configurations
{
    public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            #endregion

            #region Relacionamentos
            builder.HasMany(r => r.Modelos)
                    .WithOne(r => r.Marca)
                    .HasForeignKey(r => r.Marca_Id);
            #endregion            
        }
    }
}
