using Evento.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evento.Domain.Entity
{
    public class Eventos : Notifica
    {
        public Eventos()
        {
            Categorias = new List<Categoria>();
            InscricaoEvento = new List<InscricaoEvento>();
        }

        public int EventoId { get; set; }

        public string Nome { get; set; }

        public string Local { get; set; }

        public string Responsavel { get; set; }

        public string FoneResponsavel { get; set; }

        [Required]
        [Display(Name = "Data Inicio.")]
        public DateTime DataIni { get; set; }

        [Required]
        [Display(Name = "Data Final.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }

        public string Horarios { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorSocio { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorNaoSocio { get; set; }

        public string FaixaEtaria { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public ICollection<Categoria> Categorias { get; set; }
        public ICollection<InscricaoEvento> InscricaoEvento { get; set; }

    }
}
