using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;
using MyNewBank.Repositories;
using Spectre.Console;

namespace MyNewBank.Views;

public class ExtractView
{
    public ExtractView(List<ExtractDto> transactions, AccountBankModel accountBank)
    {   
        Console.Clear();
        var header = new Panel("              Extrato dos Últimos 30 Dias             ");
        header.Border = BoxBorder.Double;
        AnsiConsole.Write(header);
       

       var table = new Table();
       table.AddColumn("Tipo");
       table.AddColumn("Valor");
       table.AddColumn("Data");

       foreach (var transaction in transactions)
       {
           table.AddRow
           (
               transaction.TransactionType,
               $"R$ {transaction.Amount}",
               transaction.TransactionDate.ToString("dd/MM/yyyy HH:mm")
           );
       }
    
        AnsiConsole.Write(table);
        

        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu");
        Console.ReadKey();
        new LoggedMenu(accountBank);
    }
}

     