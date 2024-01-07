using System.Collections.Generic;

namespace SistemaOrcamentario.Models
{
    public class ViewModel
    {
        public PessoaModel Pessoa { get; set; }
        public List<OrcamentoModel> Orcamento { get; set; }
        
        public CategoriaModel Categoria { get; set; }
        
        public List<ProdutoModel> Produtos { get; set; }
    }

}
