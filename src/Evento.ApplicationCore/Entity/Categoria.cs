namespace Evento.Domain.Entity
{

    public class Categoria : Notifica
    {
        public Categoria()
        {
        }

        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public int IdadeIni { get; set; }
        public int IdadeFin { get; set; }
    }
}
