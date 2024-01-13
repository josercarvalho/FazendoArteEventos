using Evento.Domain.Entity;
using Evento.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.MVC.Models
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public Dependente Dependente { get; set; }
        public List<Dependente> Dependentes { get; set; }

    }
}
