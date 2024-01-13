using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class EventoMap : IEntityTypeConfiguration<Eventos>
    {
        public void Configure(EntityTypeBuilder<Eventos> builder)
        {
            // Primary Key            
            builder.HasKey(c => c.EventoId);

            // Properties
            builder.Property(t => t.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(t => t.Local)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(t => t.Responsavel)
               .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(t => t.FoneResponsavel)
               .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(t => t.DataIni)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(t => t.DataFim)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(t => t.Horarios)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t=>t.ValorSocio)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.ValorNaoSocio)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.FaixaEtaria)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnType("varchar(250)");

            // Table & Column Mappings
            builder.ToTable("Eventos");
            builder.Property(t => t.EventoId).HasColumnName("EventoId");
            builder.Property(t => t.Nome).HasColumnName("Nome");
            builder.Property(t => t.Local).HasColumnName("Local");
            builder.Property(t => t.Responsavel).HasColumnName("Responsavel");
            builder.Property(t => t.FoneResponsavel).HasColumnName("FoneResponsavel");
            builder.Property(t => t.DataIni).HasColumnName("DataIni");
            builder.Property(t => t.DataFim).HasColumnName("DataFim");
            builder.Property(t => t.Horarios).HasColumnName("Horarios");
            builder.Property(t => t.ValorSocio).HasColumnName("ValorSocio");
            builder.Property(t => t.ValorNaoSocio).HasColumnName("ValorNaoSocio");
            builder.Property(t => t.FaixaEtaria).HasColumnName("FaixaEtaria");
            builder.Property(t => t.Descricao).HasColumnName("Descricao");
            builder.Property(t => t.Ativo).HasColumnName("Ativo");

            // Relationships
            //builder.HasOne(x => x.Categorias);

        }
    }
}
