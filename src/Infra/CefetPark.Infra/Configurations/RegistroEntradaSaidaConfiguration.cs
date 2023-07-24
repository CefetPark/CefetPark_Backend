using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CefetPark.Infra.Configurations
{
    public class RegistroEntradaSaidaConfiguration : IEntityTypeConfiguration<RegistroEntradaSaida>
    {
        public void Configure(EntityTypeBuilder<RegistroEntradaSaida> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(p => p.DataEntrada).IsRequired();
            builder.Property(p => p.DataSaida);
            #endregion
        }
    }
}
