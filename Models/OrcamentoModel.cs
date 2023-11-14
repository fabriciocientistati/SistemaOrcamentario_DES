using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class OrcamentoModel
    {
        public OrcamentoModel() =>
            OrcIncEm = DateTime.Now;

        public OrcamentoModel(int orcId, int pesId, string orcDesc, string orcObservacao, decimal orcPreco, string orcTipoPagamento, string orcTipoEntrega, DateTime orcIncEm, PessoaModel orcamentoPessoa) : this()
        {
            OrcId = orcId;
            PesId = pesId;
            OrcDesc = orcDesc;
            OrcObservacao = orcObservacao;
            OrcPreco = orcPreco;
            OrcTipoPagamento = orcTipoPagamento;
            OrcTipoEntrega = orcTipoEntrega;
            OrcIncEm = orcIncEm;
            OrcamentoPessoa = orcamentoPessoa;
        }

        [Key]
        public int OrcId { get; set; }
        public int PesId { get; set; }
        //public int CatId { get; set; }
        public string OrcDesc { get; set; }
        public string OrcObservacao { get; set; }
        public decimal OrcPreco { get; set; }
        public string OrcTipoPagamento { get; set; }
        public string OrcTipoEntrega { get; set; }
        public DateTime OrcIncEm { get; set; } = DateTime.Now;
        public PessoaModel OrcamentoPessoa { get; set; }
        //public List<ProdutoModel> OrcamentoProduto { get; set; }
    }
}
