namespace AulaMVC.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public List<Habilidades> habilidades = new List<Habilidades>();

        public Usuario() {
            Nome = "Jonas";
            SobreNome = " da Silva Rabelo";
            Email = "jonas@gmail.com";
            habilidades.Add(new Habilidades("Html"));
            habilidades.Add(new Habilidades("JavaScript"));
            habilidades.Add(new Habilidades("CSS"));
            habilidades.Add(new Habilidades("Python"));
            habilidades.Add(new Habilidades("Git / GitHub"));
        }       
    }
}
