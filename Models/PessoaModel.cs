using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class PessoaModel
    {
        public PessoaModel() =>
            Orcamentos = new List<OrcamentoModel>();

        public PessoaModel(int iD, string nome, string cpf, string cnpj, string numberCellPhone, string numberFixPhone, string email, string cep, string rua, string numero, string bairro, string cidade, string estado, DateTime dataInclusao) : this()
        {
            ID = iD;
            Nome = nome;
            Cpf = cpf;
            Cnpj = cnpj;
            NumberCellPhone = numberCellPhone;
            NumberFixPhone = numberFixPhone;
            Email = email;
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            DataInclusao = dataInclusao;
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        [Required(ErrorMessage = "Digite ao menos 1 telefone")]
        [Phone(ErrorMessage = "O número informado não é valido")]
        public string NumberCellPhone { get; set; }
        public string? NumberFixPhone { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Digite o CEP para consulta")]
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public virtual ICollection<OrcamentoModel> Orcamentos { get; set; }
    }
}
