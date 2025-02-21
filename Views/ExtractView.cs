using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Services;
using Spectre.Console;

namespace MyNewBank.Views;

public class ExtractView
{
    //Quando há dados no extrato
    public void ExtractViewSuccess(List<ExtractDto> transactions, AccountBankModel accountBank)
    {

        Console.Clear();
        var header = new Panel("               Extrato dos Últimos 30 Dias               ");
        header.Border = BoxBorder.Rounded;
        header.BorderStyle = new Style(Color.Blue);
        AnsiConsole.Write(header);
        
 
        var table = new Table();
        table.AddColumn("Tipo");
        table.AddColumn("Valor");
        table.AddColumn("Data");

        table.Border = TableBorder.Rounded;
        table.BorderStyle = new Style(Color.Blue);
 
        foreach (var transaction in transactions)
        {
            var color = transaction.TransactionType switch
            {
                "Depósito" => Color.Green,
                "Saque" => Color.Red,
                "Transferência Realizada" => Color.Red,
                "Transferência Recebida" => Color.Green,
                _ => Color.White
            };
                        
            table.AddRow
            (
                new Markup($"[{color}]{transaction.TransactionType}[/]"),
                new Markup($"[{color}]R$ {transaction.Amount:N2}[/]"),
                new Markup($"[{color}]{transaction.TransactionDate:dd/MM/yyyy HH:mm}[/]")
            );
        }
    
        AnsiConsole.Write(table);
        
        Console.WriteLine("\nPressione P para exportar o extrato em PDF \nPressione E para exportar o extrato em Excel \nOu Pressione qualquer tecla para voltar ao Menu");
        //Verifica se a teclado digitada e P
        ConsoleKeyInfo input = Console.ReadKey();
        if(input.Key == ConsoleKey.P)
        {
            //Se for P, vai gerar o PDF e aguardar um clica para vcoltar ao menu
             new ExportService().ExportToPdf(transactions);
             Console.Write("O arquivo está disponivel na pasta Relatorios");
             Console.ReadKey();
             new LoggedMenu(accountBank);
             return;
        }
         //Verifica se a teclado digitada e E
        if(input.Key == ConsoleKey.E)
        {
             //Se for E, vai gerar o EXCEL e aguardar um clica para vcoltar ao menu
             new ExportService().ExportToExcel(transactions);
             Console.Write("O arquivo está disponivel na pasta Relatorios");
             Console.ReadKey();
             new LoggedMenu(accountBank);
             return;
        }   
    }
    //Quando NÃO há dados no extrato
    public void ExtractViewEmpty(AccountBankModel accountBank)
    {   
        Console.Clear();
        var header = new Panel("               Extrato dos Últimos 30 Dias               ");
        header.Border = BoxBorder.Rounded;
        header.BorderStyle = new Style(Color.Blue);
        AnsiConsole.Write(header);

        Console.WriteLine("\nSem movimentações para esse periodo!");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu");
        Console.ReadKey();
        new LoggedMenu(accountBank);
    }
    //Defasado 
    public void ExtractViewOld(List<ExtractDto> transactions, AccountBankModel accountBank)
    {   
        Console.WriteLine("\n=== Extrato dos Últimos 30 Dias ===\n");

        foreach (var transaction in transactions)
        {
            Console.WriteLine($"Tipo: {transaction.TransactionType}");
            Console.WriteLine($"Valor: {transaction.Amount:C}");
            Console.WriteLine($"Data: {transaction.TransactionDate:dd/MM/yyyy HH:mm}");
            Console.WriteLine("-----------------------------");
        }

        Console.ReadKey();
        new LoggedMenu(accountBank);
    }
}

     