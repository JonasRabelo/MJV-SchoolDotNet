
namespace Models
{
    public class JogoModel
    {
        public int Id { get; set; }
        public string NomeDoJogo { get; set; }
        public string? Game { get; set; }
        public double ValorDoJogo { get; set; }

        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}
