using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MyNewBank.Repositories;
using OfficeOpenXml;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;


namespace MyNewBank.Services;

public class ExportService
{
    public void ExportToPdf(List<ExtractDto> transactions)
    {
        // Criar diretório se não existir
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios");
        Directory.CreateDirectory(directoryPath);

        // Criar nome do arquivo com timestamp para evitar sobrescrita
        string fileName = $"Extrato_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        string filePath = Path.Combine(directoryPath, fileName);
        


        using var writer = new PdfWriter(filePath, new WriterProperties().SetCompressionLevel(CompressionConstants.NO_COMPRESSION));
        using var pdf = new PdfDocument(writer);
        using var document = new Document(pdf);

        // Criar fontes para normal e negrito
        PdfFont normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
        PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

        // Adicionar título
        var title = new Paragraph("Extrato de Transações")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(20)
            .SetFont(boldFont);
        document.Add(title);
        document.Add(new Paragraph("\n")); // Espaço após título

        // Criar tabela
        var table = new Table(3).UseAllAvailableWidth();

        // Cor do cabeçalho
        DeviceRgb headerColor = new DeviceRgb(211, 211, 211);

        // Adicionar cabeçalhos
        table.AddHeaderCell(new Cell()
            .SetBackgroundColor(headerColor)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFont(boldFont)
            .Add(new Paragraph("Tipo")));

        table.AddHeaderCell(new Cell()
            .SetBackgroundColor(headerColor)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFont(boldFont)
            .Add(new Paragraph("Valor")));

        table.AddHeaderCell(new Cell()
            .SetBackgroundColor(headerColor)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFont(boldFont)
            .Add(new Paragraph("Data")));

        // Adicionar dados
        decimal total = 0;
        foreach (var transaction in transactions)
        {
            table.AddCell(new Cell().SetTextAlignment(TextAlignment.LEFT)
                .SetFont(normalFont)
                .Add(new Paragraph(transaction.TransactionType)));

            table.AddCell(new Cell().SetTextAlignment(TextAlignment.RIGHT)
                .SetFont(normalFont)
                .Add(new Paragraph($"R$ {transaction.Amount:N2}")));

            table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER)
                .SetFont(normalFont)
                .Add(new Paragraph(transaction.TransactionDate.ToString("dd/MM/yyyy HH:mm"))));

            total += transaction.Amount;
        }

        // Adicionar a tabela ao documento
        document.Add(table);

        // Adicionar rodapé com data de geração
        document.Add(new Paragraph("\n"));
        document.Add(new Paragraph($"Relatório gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
            .SetTextAlignment(TextAlignment.RIGHT)
            .SetFontSize(8)
            .SetFont(normalFont));
    }


    public void ExportToExcel(List<ExtractDto> transactions)
    {
        // Criar diretório se não existir
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios");
        Directory.CreateDirectory(directoryPath);

        // Criar nome do arquivo com timestamp para evitar sobrescrita
        string fileName = $"Extrato_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        string filePath = Path.Combine(directoryPath, fileName);

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Extrato");

        // Adicionar cabeçalhos
        worksheet.Cells[1, 1].Value = "Tipo";
        worksheet.Cells[1, 2].Value = "Valor";
        worksheet.Cells[1, 3].Value = "Data";

        // Estilizar cabeçalhos
        var headerRange = worksheet.Cells[1, 1, 1, 3];
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

        // Adicionar dados
        int row = 2;
        foreach (var transaction in transactions)
        {
            worksheet.Cells[row, 1].Value = transaction.TransactionType;
            worksheet.Cells[row, 2].Value = transaction.Amount;
            worksheet.Cells[row, 2].Style.Numberformat.Format = "R$ #,##0.00";
            worksheet.Cells[row, 3].Value = transaction.TransactionDate;
            worksheet.Cells[row, 3].Style.Numberformat.Format = "dd/MM/yyyy HH:mm";
            row++;
        }

        
        // Autoajustar colunas
        worksheet.Cells.AutoFitColumns();

        // Adicionar bordas
        var dataRange = worksheet.Cells[1, 1, row, 3];
        dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

        // Salvar arquivo
        package.SaveAs(new FileInfo(filePath));
    }
}
