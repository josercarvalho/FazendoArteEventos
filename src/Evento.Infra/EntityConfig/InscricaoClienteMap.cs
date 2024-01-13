using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class InscricaoClienteMap : IEntityTypeConfiguration<InscricaoCliente>
    {
        public void Configure(EntityTypeBuilder<InscricaoCliente> builder)
        {

            // Primary Key
            builder
                .HasKey(x => x.Id);

            // Relationships
            builder
                .HasOne(x => x.Dependente)
                .WithMany(x => x.InscricaoClientes)
                .HasForeignKey(x => x.CriancaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Inscricao)
                .WithMany(x => x.InscricoesClientes)
                .HasForeignKey(x => x.InscricaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
