using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaOrcamentario.Models
{
    public class OrcamentoModel
    {
        public OrcamentoModel() =>
            DataInclusao = DateTime.Now;

        public OrcamentoModel(int iD, int pessoaID, string descricao, string observacoes, decimal preco, string tipoPagamento, string tipoEntrega, DateTime dataInclusao) : this()
        {
            ID = iD;
            PessoaID = pessoaID;
            Descricao = descricao;
            Observacoes = observacoes;
            Preco = preco;
            TipoPagamento = tipoPagamento;
            TipoEntrega = tipoEntrega;
            DataInclusao = dataInclusao;
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PessoaID { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public decimal Preco { get; set; }
        public string TipoPagamento { get; set; }
        public string TipoEntrega { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;
        public PessoaModel Pessoa { get; set; }
    }
}
