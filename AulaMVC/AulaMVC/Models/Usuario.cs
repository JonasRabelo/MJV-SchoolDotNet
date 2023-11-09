namespace AulaMVC.Models
{
    public class Usuario
    {
        public int Count = 0;
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public List<Habilidades> habilidades = new List<Habilidades>();

        public Usuario() {
            Nome = "Jonas";
            SobreNome = " da Silva Rabelo";
            Email = "jonas@gmail.com";
        }       
    }
}
