using Evento.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.MVC.Models
{
    public class DependentesViewModel
    {
        public DependentesViewModel()
        {
            //InscricaoClientes = new List<InscricaoViewModel>();
        }

        //[Key]
        public int DependenteId { get; set; }

        [Required]
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
        //public ClienteViewModel Cliente { get; set; }

        public int InscricaoId { get; set; }
        //public ICollection<InscricaoViewModel> InscricaoClientes { get; set; }
    }
}
