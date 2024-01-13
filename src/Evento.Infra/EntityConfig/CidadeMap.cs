using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            // Primary Key
            builder.HasKey(t => t.CidadeId);

            // Properties            
            builder.Property(t => t.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            // Table & Column Mappings
            builder.ToTable("Cidade");
            builder.Property(t => t.CidadeId).HasColumnName("CidadeId");
            builder.Property(t => t.EstadoId).HasColumnName("EstadoId");
            builder.Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
            builder
                .HasOne(c => c.Estado)
                .WithMany(c => c.Cidades)
                .HasForeignKey(c => c.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
