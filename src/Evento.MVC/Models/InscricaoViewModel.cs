using Evento.Domain.Entity;
using Evento.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.MVC.Models
{
    public class InscricaoViewModel
    {
        public InscricaoViewModel()
        {
            InscricoesClientes = new List<InscricaoCliente>();
            InscricoesEventos = new List<InscricaoEvento>();
        }

        [Key]
        [Required]
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
        
        public int ClienteId { get; set; }
        public Cliente Clientes { get; set; }

        public ICollection<InscricaoCliente> InscricoesClientes { get; set; }
        public ICollection<InscricaoEvento> InscricoesEventos { get; set; }
    }
}
