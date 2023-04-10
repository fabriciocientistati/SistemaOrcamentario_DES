using System;

namespace SistemaOrcamentario.Models
{
    public class UsuarioModel
    {
        public UsuarioModel() =>
            DataInclusao = DateTime.Now;

        public UsuarioModel(int iD, string nome, string email, string senha, int perfilID, DateTime dataInclusao) : this()
        {
            ID = iD;
            Nome = nome;
            Email = email;
            Senha = senha;
            PerfilID = perfilID;
            DataInclusao = dataInclusao;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int PerfilID { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public PerfilModel Perfil { get; set; }
    }
}
