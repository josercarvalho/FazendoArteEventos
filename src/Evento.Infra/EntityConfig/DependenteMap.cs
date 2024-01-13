using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            // Primary Key
            builder.HasKey(t => t.DependenteId);

            // Properties
            builder.Property(t => t.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(t => t.Escola)
                .HasColumnType("varchar(50)");

            builder.Property(t => t.PlanoSaude)
                .HasColumnType("varchar(50)");

            builder.Property(t => t.GrupoSanguineo)
                .HasColumnType("varchar(50)");

            builder.Property(t => t.EmergenciaHospital)
                .HasColumnType("varchar(250)");

            builder.Property(t => t.Medico)
                .HasColumnType("varchar(150)");

            builder.Property(t => t.FoneMedico)
                .HasColumnType("varchar(15)");

            builder.Property(t => t.QualMedicamento)
                .HasColumnType("varchar(250)");

            builder.Property(t => t.QualAlimento)
                .HasColumnType("varchar(150)");

            builder.Property(t => t.Observacao)
                .HasColumnType("varchar(350)");

            // Table & Column Mappings
            builder.ToTable("Dependente");
            builder.Property(t => t.DependenteId).HasColumnName("DependenteId");
            builder.Property(t => t.ClienteId).HasColumnName("ClienteId");
            builder.Property(t => t.Nome).HasColumnName("Nome");
            builder.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            builder.Property(t => t.Escola).HasColumnName("Escola");
            builder.Property(t => t.PlanoSaude).HasColumnName("PlanoSaude");
            builder.Property(t => t.GrupoSanguineo).HasColumnName("GrupoSanguineo");
            builder.Property(t => t.EmergenciaHospital).HasColumnName("EmergenciaHospital");
            builder.Property(t => t.Medico).HasColumnName("Medico");
            builder.Property(t => t.FoneMedico).HasColumnName("FoneMedico");
            builder.Property(t => t.RestricaoMedicamento).HasColumnName("RestricaoMedicamento");
            builder.Property(t => t.QualMedicamento).HasColumnName("QualMedicamento");
            builder.Property(t => t.RestricaoAlimentar).HasColumnName("RestricaoAlimentar");
            builder.Property(t => t.QualAlimento).HasColumnName("QualAlimento");
            builder.Property(t => t.PiscinaRestricao).HasColumnName("PiscinaRestricao");
            builder.Property(t => t.Observacao).HasColumnName("Observacao");

            // Relationships
            builder
                .HasOne(x => x.Cliente)
                .WithMany(x => x.Dependentes)
                .HasForeignKey(x => x.ClienteId)
                .HasPrincipalKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
