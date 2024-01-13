using Evento.Domain.Enum;
using Evento.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evento.Domain.Entity
{
    [Table("Inscricao")]
    public class Inscricao : Notifica
    {
        public Inscricao()
        {
            InscricoesClientes = new List<InscricaoCliente>();
            InscricoesEventos = new List<InscricaoEvento>();
        }

        [Key]
        public int InscricaoId { get; set; }
        public string FicouSabendo { get; set; }
        public bool Socio { get; set; }
        public string Matricula { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public Periodo Periodo { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorPago { get; set; }
        public bool Status { get; set; } // 0 Inativo, 1 Ativo

        public int EventoId { get; set; }
        public Eventos Eventos { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        //public int CategoriaId { get; set; }
        //public Categoria Categorias { get; set; }

        public int ClienteId { get; set; }
        public Cliente Clientes { get; set; }

        public ICollection<InscricaoCliente> InscricoesClientes { get; set; }
        public ICollection<InscricaoEvento> InscricoesEventos { get; set; }

    }
}