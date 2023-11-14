//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace SistemaOrcamentario.Models
//{
//    public class CategoriaModel
//    {
//        public CategoriaModel() =>
//            CatIncEm = DateTime.Now;

//        public CategoriaModel(int catId, string catNome, int catIncPor, DateTime catIncEm, int? catAltPor, DateTime? catAltEm, List<ProdutoModel> categoriaProdutos) : this()
//        {
//            CatId = catId;
//            CatNome = catNome;
//            CatIncPor = catIncPor;
//            CatIncEm = catIncEm;
//            CatAltPor = catAltPor;
//            CatAltEm = catAltEm;
//            CategoriaProdutos = categoriaProdutos;
//        }

//        [Key]
//        public int CatId { get; set; }

//        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
//        public string CatNome { get; set; }
        
//        public int CatIncPor {  get; set; }

//        public DateTime CatIncEm { get; set; } = DateTime.Now;

//        public int? CatAltPor { get; set; }

//        public DateTime? CatAltEm { get; set; }

//        public List<ProdutoModel> CategoriaProdutos { get; set; }
//    }
//}
