using Evento.Domain.Enum;
using Evento.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evento.Domain.Entity
{
    public class Dependente : Notifica
    {
        public Dependente()
        {
            InscricaoClientes = new List<InscricaoCliente>();
        }

        public int DependenteId { get; set; }
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data Nasc.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        public Parente Parente { get; set; }
        public int Idade { get; set; }
        public string Escola { get; set; }
        public string PlanoSaude { get; set; }
        public string GrupoSanguineo { get; set; }
        public string EmergenciaHospital { get; set; }
        public string Medico { get; set; }
        public string FoneMedico { get; set; }
        public bool RestricaoMedicamento { get; set; }
        public string QualMedicamento { get; set; }
        public bool RestricaoAlimentar { get; set; }
        public string QualAlimento { get; set; }
        public bool PiscinaRestricao { get; set; }
        public bool AutorizaPasseio { get; set; }
        public string Observacao { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        //public int InscricaoId { get; set; }
        public ICollection<InscricaoCliente> InscricaoClientes { get; set; }

        public static int CalculaIdade(DateTime dtNascimento)
        {
            int idade = DateTime.Now.Year - dtNascimento.Year;
            if (DateTime.Now.Month < dtNascimento.Month || (DateTime.Now.Month == dtNascimento.Month && DateTime.Now.Day < dtNascimento.Day))
                idade--;

            return idade;
        }
    }

    
}