using System.Collections.Generic;

namespace SistemaOrcamentario.Models
{
    public class ViewModel
    {
        public PessoaModel Pessoa { get; set; }
        public List<OrcamentoModel> Orcamento { get; set; }
        public List<OrcamentoModel> Orcamentos { get; internal set; }
    }

}
