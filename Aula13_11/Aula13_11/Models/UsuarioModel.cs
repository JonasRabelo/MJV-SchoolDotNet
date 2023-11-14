using Aula13_11.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aula13_11.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF do usuário")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Selecione o gênero do usuário")]
        public Genero genero { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o telefone do usuário")]
        public string Telefone {  get; set; }
        
    }
}
