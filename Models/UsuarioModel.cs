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

        public UsuarioModel(int usuId, string usuNome, string usuLogin, string usuSenha, string usuEmail, PerfilEnum usuPerfil, DateTime usuIncEm, DateTime? usuAltEm) : this()
        {
            UsuId = usuId;
            UsuNome = usuNome;
            UsuLogin = usuLogin;
            UsuSenha = usuSenha;
            UsuEmail = usuEmail;
            UsuPerfil = usuPerfil;
            UsuIncEm = usuIncEm;
            UsuAltEm = usuAltEm;
        }

        [Key]
        public int UsuId { get; set; }
        public string UsuNome { get; set; }
        public string UsuLogin { get;set; }
        public string UsuSenha { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string UsuEmail { get; set; }
        public PerfilEnum UsuPerfil { get; set; }
        public DateTime UsuIncEm { get; set; } 
        public DateTime? UsuAltEm { get; set; } = DateTime.Now;

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
