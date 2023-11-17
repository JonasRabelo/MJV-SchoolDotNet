namespace Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }

        public virtual ICollection<JogoModel> Jogos { get; set; }
    }
}
