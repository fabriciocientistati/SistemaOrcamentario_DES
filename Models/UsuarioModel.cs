using SistemaOrcamentario.Enums;
using SistemaOrcamentario.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class UsuarioModel
    {
        public UsuarioModel() =>
            UsuIncEm = DateTime.Now;

        public UsuarioModel(int usuId, string usuNome, string usuLogin, string usuSenha, string usuEmail, PerfilEnum usuPerfil, int usuIncPor, DateTime usuIncEm, int? usuAltPor, DateTime? usuAltEm) : this()
        {
            UsuId = usuId;
            UsuNome = usuNome;
            UsuLogin = usuLogin;
            UsuSenha = usuSenha;
            UsuEmail = usuEmail;
            UsuPerfil = usuPerfil;
            UsuIncPor = usuIncPor;
            UsuIncEm = usuIncEm;
            UsuAltPor = usuAltPor;
            UsuAltEm = usuAltEm;
        }

        [Key]
        public int UsuId { get; set; }

        [Required(ErrorMessage = "Preenchao campo Nome")]
        public string UsuNome { get; set; }

        [Required(ErrorMessage = "Preenchao campo Login")]
        public string UsuLogin { get;set; }

        [Required(ErrorMessage = "Preenchao campo Senha")]
        public string UsuSenha { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [Required(ErrorMessage = "Preenchao campo Email")]
        public string UsuEmail { get; set; }

        [Required(ErrorMessage = "Selecione o Perfil")]
        public PerfilEnum UsuPerfil { get; set; }

        public int UsuIncPor {  get; set; }

        public DateTime UsuIncEm { get; set; }  = DateTime.Now;

        public int? UsuAltPor { get; set; }

        public DateTime? UsuAltEm { get; set; } 

        public void SetSenhaHas()
        {
            UsuSenha = UsuSenha.GerarHash();
        }

        public bool SenhaValida(string senhaAtual)
        {
            return UsuSenha == senhaAtual.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            UsuSenha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            UsuSenha = novaSenha.GerarHash();
            return novaSenha;
        }

    }
}
