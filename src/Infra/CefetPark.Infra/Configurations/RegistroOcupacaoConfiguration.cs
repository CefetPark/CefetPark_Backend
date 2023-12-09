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
            builder.Property(x => x.QuantidadeVagasLivresEntrada);
            builder.Property(x => x.DataEntrada);
            builder.Property(x => x.DataSaida);

            #endregion
            builder.HasOne(x => x.Estacionamento).WithMany(y => y.RegistrosOcupacoes).HasForeignKey(x => x.Estacionamento_Id);
            
        }
    }
}
