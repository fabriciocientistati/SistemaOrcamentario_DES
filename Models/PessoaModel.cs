using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaOrcamentario.Models
{
    public class PessoaModel
    {
        public PessoaModel() =>
            PesIncEm = DateTime.Now;

        public PessoaModel(int pesId, string pesNome, string pesCpf, string pesCnpj, string pesNumCelular, string pesNumTelefone, string pesEmail, string pesCep, string pesRua, string pesNumero, string pesBairro, string pesCidade, string pesEstado, int pesIncPor, DateTime pesIncEm, int? pesAltPor, DateTime? pesAltEm, List<OrcamentoModel> orcamentos) : this()
        {
            PesId = pesId;
            PesNome = pesNome;
            PesCpf = pesCpf;
            PesCnpj = pesCnpj;
            PesNumCelular = pesNumCelular;
            PesNumTelefone = pesNumTelefone;
            PesEmail = pesEmail;
            PesCep = pesCep;
            PesRua = pesRua;
            PesNumero = pesNumero;
            PesBairro = pesBairro;
            PesCidade = pesCidade;
            PesEstado = pesEstado;
            PesIncPor = pesIncPor;
            PesIncEm = pesIncEm;
            PesAltPor = pesAltPor;
            PesAltEm = pesAltEm;
            Orcamentos = orcamentos;
        }

        [Key]
        public int PesId { get; set; }

        [Required(ErrorMessage = "Preenchao campo Nome")]
        public string PesNome { get; set; }

        public string? PesCpf { get; set; } = null;

        public string? PesCnpj { get; set; }

        [Required(ErrorMessage = "Preenchao campo Telefone")]
        [Phone(ErrorMessage = "O número informado não é valido")]
        public string PesNumCelular { get; set; }

        public string? PesNumTelefone { get; set; }

        public string? PesEmail { get; set; }

        [Required(ErrorMessage = "Preenchao campo CEP para consulta")]
        public string PesCep { get; set; }

        public string PesRua { get; set; }

        [Required(ErrorMessage = "Preenchao campo Número")]
        public string PesNumero { get; set; }

        public string PesBairro { get; set; }

        public string PesCidade { get; set; }

        public string PesEstado { get; set; }

        public int PesIncPor {  get; set; }

        public DateTime PesIncEm { get; set; } = DateTime.Now;

        public int? PesAltPor {  get; set; }

        public DateTime? PesAltEm { get; set; }

        public virtual List<OrcamentoModel> Orcamentos { get; set; }
    }
}
