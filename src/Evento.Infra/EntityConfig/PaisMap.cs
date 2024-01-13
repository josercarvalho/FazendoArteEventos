using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        void IEntityTypeConfiguration<Pais>.Configure(EntityTypeBuilder<Pais> builder)
        {
            // Primary Key
            builder
                .HasKey(x => x.PaisId);

            // Properties
            builder
                .Property(x => x.Sigla)
                .HasColumnType("varchar(2)")
                .IsRequired();

                builder
                .Property(x => x.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            // Table & Column Mappings
            builder.ToTable("Pais");
            builder.Property(t => t.PaisId).HasColumnName("PaisId");
            builder.Property(t => t.Sigla).HasColumnName("Sigla");
            builder.Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
            //builder
            //    .HasMany(x => x.Estados)
            //    .WithOne(x => x.Pais)
            //    .HasForeignKey(x => x.EstadoId)
            //    .HasPrincipalKey(x => x.PaisId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
