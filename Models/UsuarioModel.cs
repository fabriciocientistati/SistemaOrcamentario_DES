using SistemaOrcamentario.Enums;
using SistemaOrcamentario.Helper;
using System;

namespace SistemaOrcamentario.Models
{
    public class UsuarioModel
    {
        public UsuarioModel() =>
            DataInclusao = DateTime.Now;
        public UsuarioModel(int iD, string nome, string login, string senha, string email, PerfilEnum perfil, DateTime dataInclusao, DateTime dataAtualizacao) : this()
        {
            ID = iD;
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = email;
            Perfil = perfil;
            DataInclusao = dataInclusao;
            DataAtualizacao = dataAtualizacao;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Login { get;set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public PerfilEnum? Perfil { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; } = DateTime.Now;

        public void SetSenhaHas()
        {
            Senha = Senha.GerarHash();
        }
    }
}
