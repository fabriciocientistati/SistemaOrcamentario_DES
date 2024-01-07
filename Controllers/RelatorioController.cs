//using iTextSharp.text.pdf;
//using iTextSharp.text;
//using Microsoft.AspNetCore.Mvc;
//using System.IO;
//using System.Threading.Tasks;
//using SistemaOrcamentario.Context;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using SistemaOrcamentario.Models;
//using System.Collections.Generic;

//namespace SistemaOrcamentario.Controllers
//{
//    public class RelatorioController : Controller
//    {
//        private readonly DataContext _dataContext;

//        public RelatorioController(DataContext dataContext)
//        {
//            _dataContext = dataContext;
//        }

//        public async Task<IActionResult> GerarPDF(int? id)
//        {
//            PessoaModel pessoa = await _dataContext.TBPESSOA.FirstOrDefaultAsync(x => x.PesId == id);
//            List<OrcamentoModel> orcamentos = await _dataContext.TBORCAMENTO.Where(x => x.PesId == id).ToListAsync();
//            var viewModel = new ViewModel { Pessoa = pessoa, Orcamentos = orcamentos };

//            if (viewModel == null)
//            {
//                return NotFound(); // Trate o caso em que não há registro com o ID informado, se necessário
//            }

//            // Crie o documento PDF
//            Document doc = new Document();
//            MemoryStream ms = new MemoryStream();
//            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
//            doc.Open();

//            // Adicione o cabeçalho com o nome do Pessoa
//            Paragraph pessoaParagraph = new Paragraph($"Pessoa: {viewModel.Pessoa.PesNome}\n\n");
//            pessoaParagraph.Alignment = Element.ALIGN_CENTER; // Centralize o texto
//            pessoaParagraph.SpacingAfter = 20f; // Adicione um espaçamento após o parágrafo
//            doc.Add(pessoaParagraph);

//            // Adicione os detalhes dos orçamentos em uma tabela
//            PdfPTable table = new PdfPTable(6); // Crie uma tabela com 4 colunas
//            table.WidthPercentage = 100; // Defina a largura da tabela como 100% do documento
//            table.SpacingAfter = 10f; // Adicione um espaçamento após a tabela

//            // Adicione os cabeçalhos das colunas
//            PdfPCell dataHeader = new PdfPCell(new Phrase("Data do Orçamento"));
//            dataHeader.HorizontalAlignment = Element.ALIGN_CENTER;
//            table.AddCell(dataHeader);

//            PdfPCell observacaoHeader = new PdfPCell(new Phrase("Observação"));
//            observacaoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
//            table.AddCell(observacaoHeader);

//            PdfPCell descricaoHeader = new PdfPCell(new Phrase("Descrição"));
//            descricaoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
//            table.AddCell(descricaoHeader);

//            PdfPCell TipoPagamentoHeader = new PdfPCell(new Phrase("Forma de Pagamento"));
//            descricaoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
//            table.AddCell(TipoPagamentoHeader);

//            PdfPCell valorHeader = new PdfPCell(new Phrase("Valor", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
//            valorHeader.HorizontalAlignment = Element.ALIGN_CENTER;
//            table.AddCell(valorHeader);

//            PdfPCell TipoEntregaHeader = new PdfPCell(new Phrase("Forma de Entrega", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
//            TipoEntregaHeader.HorizontalAlignment = Element.ALIGN_CENTER;
//            table.AddCell(TipoEntregaHeader);

//            // Adicione os detalhes de cada orçamento como células da tabela com estilo
//            foreach (var orcamento in viewModel.Orcamentos)
//            {
//                PdfPCell dataCell = new PdfPCell(new Phrase(orcamento.OrcIncEm.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
//                table.AddCell(dataCell);

//                PdfPCell observacaoCell = new PdfPCell(new Phrase(orcamento.OrcObservacao, new Font(Font.FontFamily.HELVETICA, 10)));
//                table.AddCell(observacaoCell);

//                PdfPCell descricaoCell = new PdfPCell(new Phrase(orcamento.OrcDesc, new Font(Font.FontFamily.HELVETICA, 10)));
//                table.AddCell(descricaoCell);

//                PdfPCell TipoPagamentoCell = new PdfPCell(new Phrase(orcamento.OrcTipoPagamento, new Font(Font.FontFamily.HELVETICA, 10)));
//                table.AddCell(TipoPagamentoCell);

//                PdfPCell valorCell = new PdfPCell(new Phrase(orcamento.OrcPreco.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
//                table.AddCell(valorCell);

//                PdfPCell TipoEntregaCell = new PdfPCell(new Phrase(orcamento.OrcTipoEntrega, new Font(Font.FontFamily.HELVETICA, 10)));
//                table.AddCell(TipoEntregaCell);
//            }

//            doc.Add(table); // Adicione a tabela ao documento

//            // Feche o documento PDF
//            doc.Close();
//            writer.Close();
//            ms.Close();

//            // Retorne o PDF como um arquivo para download
//            return File(ms.ToArray(), "application/pdf", "Relatorio.pdf");
//        }
//    }
//}

