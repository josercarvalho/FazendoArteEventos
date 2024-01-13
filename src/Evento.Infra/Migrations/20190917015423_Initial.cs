using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Evento.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Profissao = table.Column<string>(maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    Celular = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Escolaridade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Filhos = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Referencia = table.Column<string>(type: "varchar(150)", nullable: true),
                    CidadeId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaisId = table.Column<int>(nullable: false),
                    Sigla = table.Column<string>(type: "varchar(150)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Local = table.Column<string>(type: "varchar(150)", nullable: false),
                    Responsavel = table.Column<string>(type: "varchar(150)", nullable: false),
                    FoneResponsavel = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataIni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horarios = table.Column<string>(type: "varchar(50)", nullable: false),
                    ValorSocio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorNaoSocio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FaixaEtaria = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sigla = table.Column<string>(type: "varchar(2)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    DependenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Parente = table.Column<int>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Escola = table.Column<string>(type: "varchar(50)", nullable: true),
                    PlanoSaude = table.Column<string>(type: "varchar(50)", nullable: true),
                    GrupoSanguineo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EmergenciaHospital = table.Column<string>(type: "varchar(250)", nullable: true),
                    Medico = table.Column<string>(type: "varchar(150)", nullable: true),
                    FoneMedico = table.Column<string>(type: "varchar(15)", nullable: true),
                    RestricaoMedicamento = table.Column<bool>(nullable: true),
                    QualMedicamento = table.Column<string>(type: "varchar(250)", nullable: true),
                    RestricaoAlimentar = table.Column<bool>(nullable: true),
                    QualAlimento = table.Column<string>(type: "varchar(150)", nullable: true),
                    PiscinaRestricao = table.Column<bool>(nullable: true),
                    AutorizaPasseio = table.Column<bool>(nullable: true),
                    Observacao = table.Column<string>(type: "varchar(350)", nullable: true),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.DependenteId);
                    table.ForeignKey(
                        name: "FK_Dependente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    CidadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstadoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.CidadeId);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 150, nullable: false),
                    IdadeIni = table.Column<int>(nullable: false),
                    IdadeFin = table.Column<int>(nullable: false),
                    EventosEventoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                    table.ForeignKey(
                        name: "FK_Categoria_Eventos_EventosEventoId",
                        column: x => x.EventosEventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inscricao",
                columns: table => new
                {
                    InscricaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FicouSabendo = table.Column<string>(nullable: true),
                    Socio = table.Column<bool>(nullable: false),
                    Matricula = table.Column<string>(maxLength: 50, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Periodo = table.Column<int>(maxLength: 50, nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    EventoId = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.InscricaoId);
                    table.ForeignKey(
                        name: "FK_Inscricao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscricao_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InscricaoClientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriancaId = table.Column<int>(nullable: false),
                    InscricaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscricaoClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InscricaoClientes_Dependente_CriancaId",
                        column: x => x.CriancaId,
                        principalTable: "Dependente",
                        principalColumn: "DependenteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscricaoClientes_Inscricao_InscricaoId",
                        column: x => x.InscricaoId,
                        principalTable: "Inscricao",
                        principalColumn: "InscricaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InscricaoEvento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventoId = table.Column<int>(nullable: false),
                    IncricaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscricaoEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InscricaoEvento_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscricaoEvento_Inscricao_IncricaoId",
                        column: x => x.IncricaoId,
                        principalTable: "Inscricao",
                        principalColumn: "InscricaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_EventosEventoId",
                table: "Categoria",
                column: "EventosEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_ClienteId",
                table: "Dependente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_ClienteId",
                table: "Inscricao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_EventoId",
                table: "Inscricao",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_InscricaoClientes_CriancaId",
                table: "InscricaoClientes",
                column: "CriancaId");

            migrationBuilder.CreateIndex(
                name: "IX_InscricaoClientes_InscricaoId",
                table: "InscricaoClientes",
                column: "InscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_InscricaoEvento_EventoId",
                table: "InscricaoEvento",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_InscricaoEvento_IncricaoId",
                table: "InscricaoEvento",
                column: "IncricaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "InscricaoClientes");

            migrationBuilder.DropTable(
                name: "InscricaoEvento");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Inscricao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
