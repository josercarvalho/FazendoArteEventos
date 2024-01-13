using Evento.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evento.Infra.EntityConfig
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            // Primary Key
            builder.HasKey(t => t.ClienteId);

            // Properties
            builder.Property(t => t.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(t => t.CPF)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(t => t.DataNascimento)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(t => t.Profissao)
                .HasMaxLength(50);

            builder.Property(t => t.Telefone)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(t => t.Celular)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(t => t.Email)
                .HasColumnType("varchar(150)");

            builder.Property(t => t.Escolaridade)
                .HasColumnType("varchar(50)");

            builder.Property(t => t.Logradouro)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(t => t.Bairro)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(t => t.CEP)
                .HasColumnType("varchar(10)")
                .IsRequired();                      

            builder.Property(t => t.Complemento)
                .HasColumnType("varchar(250)");

            builder.Property(t => t.Referencia)
                .HasColumnType("varchar(150)");

            // Table & Column Mappings
            builder.ToTable("Cliente");
            builder.Property(t => t.ClienteId).HasColumnName("ClienteId");
            builder.Property(t => t.Nome).HasColumnName("Nome");
            builder.Property(t => t.CPF).HasColumnName("CPF");
            builder.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            builder.Property(t => t.Sexo).HasColumnName("Sexo");
            builder.Property(t => t.Profissao).HasColumnName("Profissao");
            builder.Property(t => t.Telefone).HasColumnName("Telefone");
            builder.Property(t => t.Celular).HasColumnName("Celular");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.Escolaridade).HasColumnName("Escolaridade");
            builder.Property(t => t.Filhos).HasColumnName("Filhos");
            builder.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            builder.Property(t => t.Logradouro).HasColumnName("Logradouro");
            builder.Property(t => t.Bairro).HasColumnName("Bairro");
            builder.Property(t => t.CEP).HasColumnName("CEP");
            builder.Property(t => t.CidadeId).HasColumnName("CidadeId");
            builder.Property(t => t.EstadoId).HasColumnName("EstadoId");
            builder.Property(t => t.Complemento).HasColumnName("Complemento");
            builder.Property(t => t.Referencia).HasColumnName("Referencia");

            // Relationships
            builder
                .HasMany(x => x.Dependentes)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId)
                .HasPrincipalKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(x => x.Cidade)
            //    .WithMany(x => x.Clientes)
            //    .HasForeignKey(x => x.CidadeId)
            //    .HasPrincipalKey(e => e.CidadeId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasOne(x => x.Estado)
            //    .WithMany(x => x.Clientes)
            //    .HasForeignKey(x => x.EstadoId)
            //    .HasPrincipalKey(e => e.EstadoId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
