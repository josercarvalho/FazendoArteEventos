using Evento.Domain.Enum;
using Evento.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evento.Domain.Entity
{
    public class Cliente : Notifica
    {
        public Cliente()
        {
            Dependentes = new List<Dependente>();
            Inscricoes = new List<Inscricao>();
        }

        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "Data Nasc.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        public Sexo Sexo { get; set; }

        public string Profissao { get; set; }

        [Required]
        public string Telefone { get; set; }

        public string Celular { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Escolaridade Escolaridade { get; set; }

        [Required]
        public int Filhos { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }


        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string CEP { get; set; }

        public string Complemento { get; set; }

        [Display(Name ="Referência")]
        public string Referencia { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        //public virtual Cidade Cidade { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        //public virtual Estado Estado { get; set; }

        public ICollection<Dependente> Dependentes { get; set; }
        public ICollection<Inscricao> Inscricoes { get; set; }

    }
}
