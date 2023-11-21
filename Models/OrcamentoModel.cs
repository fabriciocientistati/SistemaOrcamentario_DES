using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class OrcamentoModel
    {
        public OrcamentoModel() =>
            OrcIncEm = DateTime.Now;

        public OrcamentoModel(int orcId, int pesId, string orcDesc, string orcObservacao, decimal orcPreco, string orcTipoPagamento, string orcTipoEntrega, int orcIncPor, DateTime orcIncEm, int? orcAltPor, DateTime? orcAltEm, PessoaModel orcamentoPessoa) : this()
        {
            OrcId = orcId;
            PesId = pesId;
            OrcDesc = orcDesc;
            OrcObservacao = orcObservacao;
            OrcPreco = orcPreco;
            OrcTipoPagamento = orcTipoPagamento;
            OrcTipoEntrega = orcTipoEntrega;
            OrcIncPor = orcIncPor;
            OrcIncEm = orcIncEm;
            OrcAltPor = orcAltPor;
            OrcAltEm = orcAltEm;
            OrcamentoPessoa = orcamentoPessoa;
        }

        [Key]
        public int OrcId { get; set; }
        public int PesId { get; set; }
        //public int CatId { get; set; }

        [Required(ErrorMessage = "Preenchao campo Descrição")]
        public string OrcDesc { get; set; }

        public string? OrcObservacao { get; set; }

        [Required(ErrorMessage = "Preenchao campo Valor")]
        public decimal OrcPreco { get; set; }

        [Required(ErrorMessage = "Preenchao o tipo de pagamento")]
        public string OrcTipoPagamento { get; set; }

        [Required(ErrorMessage = "Preenchao o tipo da entrega a ser feita")]
        public string OrcTipoEntrega { get; set; }

        public int OrcIncPor {  get; set; }

        public DateTime OrcIncEm { get; set; } = DateTime.Now;

        public int? OrcAltPor { get; set; }

        public DateTime? OrcAltEm { get; set; }

        public PessoaModel OrcamentoPessoa { get; set; }
        //public List<ProdutoModel> OrcamentoProduto { get; set; }
    }
}
