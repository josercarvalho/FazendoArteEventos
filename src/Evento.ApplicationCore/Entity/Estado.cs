using System.Collections.Generic;

namespace Evento.Domain.Entity
{
    public class Estado
    {
        public Estado()
        {
            Cidades = new List<Cidade>();
            //Clientes = new List<Cliente>();
        }

        public int EstadoId { get; set; }
        public int PaisId { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
        //public ICollection<Cliente> Clientes { get; set; }

    }
}
