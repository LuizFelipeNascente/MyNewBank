using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Services;
using Spectre.Console;

namespace MyNewBank.Views;

public class ExtractView
{
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
        
        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu");
        //Console.ReadKey();
        //new LoggedMenu(accountBank);

        ConsoleKeyInfo input = Console.ReadKey();
        if(input.Key == ConsoleKey.P)
        new ExportService().ExportToPdf(transactions);
        new LoginMenu();
    }

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

     