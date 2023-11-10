using iTextSharp.text;
using Org.BouncyCastle.Math.EC.Multiplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class ProdutoModel
    {
        public ProdutoModel() =>
            ProdutoIncEm = DateTime.Now;

        public ProdutoModel(int produtoId, string nome, string descricao, decimal preco, int quantidadeEmEstoque, int produtoIncPor, DateTime produtoIncEm, int? produtoAltPor, DateTime? produtoAltEm, List<OrcamentoModel> produtoOrcamento) : this()
        {
            ProdutoId = produtoId;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            ProdutoIncPor = produtoIncPor;
            ProdutoIncEm = produtoIncEm;
            ProdutoAltPor = produtoAltPor;
            ProdutoAltEm = produtoAltEm;
            ProdutoOrcamento = produtoOrcamento;
        }

        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]

        public decimal Preco { get; set; }

        public string GetFormattedBasePrice() => Preco.ToString("0.00");

        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior que zero.")]
        public int QuantidadeEmEstoque {  get; set; }

        public string ImagemUrl { get; set; }

        public int ProdutoIncPor {  get; set; }

        public DateTime ProdutoIncEm {  get; set; } = DateTime.Now;

        public int? ProdutoAltPor { get; set; }

        public DateTime? ProdutoAltEm { get; set; }

        public List<OrcamentoModel> ProdutoOrcamento { get; set; }

    }
}
