using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class InscricaoEventoMap : IEntityTypeConfiguration<InscricaoEvento>
    {
        public void Configure(EntityTypeBuilder<InscricaoEvento> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(x => x.Eventos)
                .WithMany(x => x.InscricaoEvento)
                .HasForeignKey(x => x.EventoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Inscricao)
                .WithMany(x => x.InscricoesEventos)
                .HasForeignKey(x => x.IncricaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
