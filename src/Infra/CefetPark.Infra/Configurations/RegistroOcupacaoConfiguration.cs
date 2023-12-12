using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CefetPark.Infra.Configurations
{
    public class RegistroOcupacaoConfiguration : IEntityTypeConfiguration<RegistroOcupacao>
    {
        public void Configure(EntityTypeBuilder<RegistroOcupacao> builder)
        {
            #region Chave primária
            builder.HasKey(k => k.Id);
            #endregion

            #region Propriedades
            builder.Property(x => x.QuantidadeVagasLivres);
            builder.Property(x => x.Data);

            #endregion
            builder.HasOne(x => x.RegistroEntradaSaida).WithMany(y => y.RegistrosOcupacao).HasForeignKey(x => x.RegistroEntradaSaida_Id);
            
        }
    }
}
