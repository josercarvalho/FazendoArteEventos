using System.Collections.Generic;

namespace Evento.Domain.Entity
{
    public class Cidade : Notifica
    {
        public Cidade()
        {
            //Clientes = new List<Cliente>();
        }

        public int CidadeId { get; set; }
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }

        //public ICollection<Cliente> Clientes { get; set; }

    }
}