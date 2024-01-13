using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            // Primary Key
            builder.HasKey(t => t.EstadoId);

            // Properties
            //builder.Property(t => t.PaisId)
            //    .HasColumnType("int()")
            //    .IsRequired();

            builder.Property(t => t.Sigla)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(t => t.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            // Table & Column Mappings
            builder.ToTable("Estado");
            builder.Property(t => t.EstadoId).HasColumnName("EstadoId");
            builder.Property(t => t.PaisId).HasColumnName("PaisId");
            builder.Property(t => t.Sigla).HasColumnName("Sigla");
            builder.Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
            builder
                .HasMany(t => t.Cidades)
                .WithOne(t => t.Estado)
                .HasForeignKey(d => d.EstadoId)
                .HasPrincipalKey(e => e.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
