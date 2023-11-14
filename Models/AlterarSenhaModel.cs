using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class AlterarSenhaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        public string senhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha do usuário")]
        public string novaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha do usuário")]
        [Compare("novaSenha", ErrorMessage = "Senha não confere com a nova senha")]
        public string confirmarNovaSenha { get; set; }
    }
}
