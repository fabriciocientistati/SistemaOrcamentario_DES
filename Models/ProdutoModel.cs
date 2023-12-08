using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class ProdutoModel
    {
        public ProdutoModel() =>
            ProIncEm = DateTime.Now;

        public ProdutoModel(int proId, string proNome, string proDesc, decimal proPreco, int proQuantidadeEmEstoque, string proImagemUrl, int catId, int proIncPor, int? proAltPor, DateTime? proAltEm, CategoriaModel categoria) : this()
        {
            ProId = proId;
            ProNome = proNome;
            ProDesc = proDesc;
            ProPreco = proPreco;
            ProQuantidadeEmEstoque = proQuantidadeEmEstoque;
            ProImagemUrl = proImagemUrl;
            CatId = catId;
            ProIncPor = proIncPor;
            ProAltPor = proAltPor;
            ProAltEm = proAltEm;
            Categoria = categoria;
        }

        [Key]
        public int ProId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string ProNome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string ProDesc { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]

        public decimal ProPreco { get; set; }

        public string GetFormattedBasePrice() => ProPreco.ToString("0.00");

        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade deve ser maior que zero.")]
        public int ProQuantidadeEmEstoque { get; set; }

        public string ProImagemUrl { get; set; }

        public int CatId { get; set; }

        public int ProIncPor { get; set; }

        public DateTime ProIncEm { get; set; } = DateTime.Now;

        public int? ProAltPor { get; set; }

        public DateTime? ProAltEm { get; set; }

        public CategoriaModel Categoria { get; set; }
    }
}
