namespace Evento.Domain.Entity
{
    public class InscricaoCliente
    {
        public InscricaoCliente()
        {
        }

        public int Id { get; set; }
        public int CriancaId { get; set; }
        public Dependente Dependente { get; set; }
        public int InscricaoId { get; set; }
        public Inscricao Inscricao { get; set; }

    }
}
