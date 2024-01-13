﻿// <auto-generated />
using System;
using Evento.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Evento.Infra.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20190917015423_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Evento.Domain.Entity.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoriaId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasMaxLength(150);

                    b.Property<int?>("EventosEventoId");

                    b.Property<int>("IdadeFin");

                    b.Property<int>("IdadeIni");

                    b.HasKey("CategoriaId");

                    b.HasIndex("EventosEventoId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Cidade", b =>
                {
                    b.Property<int>("CidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CidadeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadoId")
                        .HasColumnName("EstadoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("CidadeId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClienteId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("Bairro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnName("Celular")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("CidadeId")
                        .HasColumnName("CidadeId");

                    b.Property<string>("Complemento")
                        .HasColumnName("Complemento")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DataCadastro");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Escolaridade")
                        .IsRequired()
                        .HasColumnName("Escolaridade")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EstadoId")
                        .HasColumnName("EstadoId");

                    b.Property<int>("Filhos")
                        .HasColumnName("Filhos");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("Logradouro")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Profissao")
                        .HasColumnName("Profissao")
                        .HasMaxLength(50);

                    b.Property<string>("Referencia")
                        .HasColumnName("Referencia")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Sexo")
                        .HasColumnName("Sexo");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("Telefone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Dependente", b =>
                {
                    b.Property<int>("DependenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DependenteId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AutorizaPasseio");

                    b.Property<int>("ClienteId")
                        .HasColumnName("ClienteId");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("EmergenciaHospital")
                        .HasColumnName("EmergenciaHospital")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Escola")
                        .HasColumnName("Escola")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FoneMedico")
                        .HasColumnName("FoneMedico")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("GrupoSanguineo")
                        .HasColumnName("GrupoSanguineo")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Idade");

                    b.Property<string>("Medico")
                        .HasColumnName("Medico")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Observacao")
                        .HasColumnName("Observacao")
                        .HasColumnType("varchar(350)");

                    b.Property<int>("Parente");

                    b.Property<bool?>("PiscinaRestricao")
                        .HasColumnName("PiscinaRestricao");

                    b.Property<string>("PlanoSaude")
                        .HasColumnName("PlanoSaude")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("QualAlimento")
                        .HasColumnName("QualAlimento")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("QualMedicamento")
                        .HasColumnName("QualMedicamento")
                        .HasColumnType("varchar(250)");

                    b.Property<bool?>("RestricaoAlimentar")
                        .HasColumnName("RestricaoAlimentar");

                    b.Property<bool?>("RestricaoMedicamento")
                        .HasColumnName("RestricaoMedicamento");

                    b.HasKey("DependenteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Dependente");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EstadoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PaisId")
                        .HasColumnName("PaisId");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("Sigla")
                        .HasColumnType("varchar(150)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Eventos", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EventoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("DataFim")
                        .HasColumnName("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataIni")
                        .HasColumnName("DataIni")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnName("Descricao")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("FaixaEtaria")
                        .IsRequired()
                        .HasColumnName("FaixaEtaria")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FoneResponsavel")
                        .IsRequired()
                        .HasColumnName("FoneResponsavel")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Horarios")
                        .IsRequired()
                        .HasColumnName("Horarios")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnName("Local")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Responsavel")
                        .IsRequired()
                        .HasColumnName("Responsavel")
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("ValorNaoSocio")
                        .HasColumnName("ValorNaoSocio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorSocio")
                        .HasColumnName("ValorSocio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Inscricao", b =>
                {
                    b.Property<int>("InscricaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InscricaoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnName("ClienteId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<int>("EventoId")
                        .HasColumnName("EventoId");

                    b.Property<string>("FicouSabendo")
                        .HasColumnName("FicouSabendo");

                    b.Property<string>("Matricula")
                        .HasColumnName("Matricula")
                        .HasMaxLength(50);

                    b.Property<int>("Periodo")
                        .HasColumnName("Periodo")
                        .HasMaxLength(50);

                    b.Property<bool>("Socio")
                        .HasColumnName("Socio");

                    b.Property<bool>("Status")
                        .HasColumnName("Status");

                    b.Property<decimal>("Valor")
                        .HasColumnName("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("ValorPago")
                        .HasColumnName("ValorPago")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("InscricaoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EventoId");

                    b.ToTable("Inscricao");
                });

            modelBuilder.Entity("Evento.Domain.Entity.InscricaoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CriancaId");

                    b.Property<int>("InscricaoId");

                    b.HasKey("Id");

                    b.HasIndex("CriancaId");

                    b.HasIndex("InscricaoId");

                    b.ToTable("InscricaoClientes");
                });

            modelBuilder.Entity("Evento.Domain.Entity.InscricaoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventoId");

                    b.Property<int>("IncricaoId");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("IncricaoId");

                    b.ToTable("InscricaoEvento");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PaisId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("Sigla")
                        .HasColumnType("varchar(2)");

                    b.HasKey("PaisId");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Categoria", b =>
                {
                    b.HasOne("Evento.Domain.Entity.Eventos")
                        .WithMany("Categorias")
                        .HasForeignKey("EventosEventoId");
                });

            modelBuilder.Entity("Evento.Domain.Entity.Cidade", b =>
                {
                    b.HasOne("Evento.Domain.Entity.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Evento.Domain.Entity.Dependente", b =>
                {
                    b.HasOne("Evento.Domain.Entity.Cliente", "Cliente")
                        .WithMany("Dependentes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Evento.Domain.Entity.Inscricao", b =>
                {
                    b.HasOne("Evento.Domain.Entity.Cliente", "Clientes")
                        .WithMany("Inscricoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Evento.Domain.Entity.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Evento.Domain.Entity.InscricaoCliente", b =>
                {
                    b.HasOne("Evento.Domain.Entity.Dependente", "Dependente")
                        .WithMany("InscricaoClientes")
                        .HasForeignKey("CriancaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Evento.Domain.Entity.Inscricao", "Inscricao")
                        .WithMany("InscricoesClientes")
                        .HasForeignKey("InscricaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Evento.Domain.Entity.InscricaoEvento", b =>
                {
                    b.HasOne("Evento.Domain.Entity.Eventos", "Eventos")
                        .WithMany("InscricaoEvento")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Evento.Domain.Entity.Inscricao", "Inscricao")
                        .WithMany("InscricoesEventos")
                        .HasForeignKey("IncricaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
