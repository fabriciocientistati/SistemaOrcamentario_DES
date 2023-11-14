
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo Login é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
