using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MyNewBank.Repositories;
using System.Globalization;

namespace MyNewBank.Services;

public class ExportService
{
   


public void ExportToPdf(List<ExtractDto> transactions)
{
    // Caminho da pasta 'Relatorios' na raiz do projeto
    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios");

    // Verifique se a pasta existe, caso contrário, crie
    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }

    // Caminho completo do arquivo
    string filePath = Path.Combine(folderPath, "extrato_transacoes.pdf");

    using (var writer = new PdfWriter(filePath))
    {
        using (var pdf = new PdfDocument(writer))
        {
            var document = new Document(pdf);
            
            // Título
            document.Add(new Paragraph("Extrato de Transações"));

            // Tabela
            var table = new Table(3); // 3 colunas: Tipo, Amount, TransactionDate
            table.AddHeaderCell("Tipo");
            table.AddHeaderCell("Amount");
            table.AddHeaderCell("Data");

            foreach (var transaction in transactions)
            {
                table.AddCell(transaction.TransactionType);
                table.AddCell(transaction.Amount.ToString("C", CultureInfo.CurrentCulture));
                table.AddCell(transaction.TransactionDate.ToString("dd/MM/yyyy"));
            }

            document.Add(table);
        }
    }

    Console.WriteLine($"PDF gerado em: {filePath}");
}


}
