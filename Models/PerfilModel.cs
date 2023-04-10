using System;

namespace SistemaOrcamentario.Models
{
    public class PerfilModel
    {
        public PerfilModel() =>
            DataInclusao = DateTime.Now;
        public PerfilModel(int iD, string nome, string descricao, DateTime dataInclusao) : this()
        {
            ID = iD;
            Nome = nome;
            Descricao = descricao;
            DataInclusao = dataInclusao;
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
