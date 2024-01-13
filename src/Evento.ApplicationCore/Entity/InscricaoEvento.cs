namespace Evento.Domain.Entity
{
    public class InscricaoEvento
    {
        public InscricaoEvento()
        {
        }

        public int Id { get; set; }
        public int EventoId { get; set; }
        public Eventos Eventos { get; set; }
        public int IncricaoId { get; set; }
        public Inscricao Inscricao { get; set; }

    }
}
