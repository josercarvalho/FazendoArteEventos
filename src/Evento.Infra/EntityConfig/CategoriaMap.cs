using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {       
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Primary Key
            builder.HasKey(t => t.CategoriaId);

            // Properties
            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            // Relacionamento

            // Table & Column Mappings
            builder.ToTable("Categoria");
            builder.Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            builder.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
