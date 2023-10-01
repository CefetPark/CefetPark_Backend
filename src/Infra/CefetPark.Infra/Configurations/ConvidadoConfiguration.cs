

using CefetPark.Domain.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CefetPark.Infra.Configurations
{
    public class ConvidadoConfiguration : IEntityTypeConfiguration<Convidado>
    {
        public void Configure(EntityTypeBuilder<Convidado> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(r => r.Carros).WithMany(c => c.Convidados);
            builder.HasMany(x => x.RegistroEntradaSaidas).WithOne(c => c.Convidado).HasForeignKey(x => x.Convidado_Id);
        }
    }
}
