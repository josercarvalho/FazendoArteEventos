using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class InscricaoMap : IEntityTypeConfiguration<Inscricao>
    {
        void IEntityTypeConfiguration<Inscricao>.Configure(EntityTypeBuilder<Inscricao> builder)
        {
            // Primary Key
            builder
                .HasKey(c => c.InscricaoId);

            // Properties
            builder.Property(t => t.Matricula)
                .HasMaxLength(50);

            builder.Property(t => t.Periodo)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.ToTable("Inscricao");
            builder.Property(t => t.InscricaoId).HasColumnName("InscricaoId");
            builder.Property(t => t.EventoId).HasColumnName("EventoId");
            builder.Property(t => t.ClienteId).HasColumnName("ClienteId");
            //builder.Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            builder.Property(t => t.FicouSabendo).HasColumnName("FicouSabendo");
            builder.Property(t => t.Socio).HasColumnName("Socio");
            builder.Property(t => t.Matricula).HasColumnName("Matricula");
            builder.Property(t => t.Valor).HasColumnName("Valor");
            builder.Property(t => t.Periodo).HasColumnName("Periodo");
            builder.Property(t => t.ValorPago).HasColumnName("ValorPago");
            builder.Property(t => t.Status).HasColumnName("Status");

            // Relationships
            //builder
            //    .HasMany(t => t.Categoria)
            //    .WithMany(t => t.Inscricaos)
            //    .HasForeignKey(d => d.CategoriaId);

            //builder
            //    .HasOne(t => t.Eventos)
            //    .WithMany(t => t.InscricaoEvento)
            //    .HasForeignKey(d => d.ClienteId);

            builder
                .HasOne(t => t.Clientes)
                .WithMany(t => t.Inscricoes)
                .HasForeignKey(d => d.ClienteId)
                .HasPrincipalKey(d=>d.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
