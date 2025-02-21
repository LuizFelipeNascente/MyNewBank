using System;
using System.Globalization;
using MyNewBank.Enums;
using MyNewBank.Models;
using MyNewBank.Services;
using Spectre.Console;

namespace MyNewBank.Controllers.Menus;

public class ExtractMenu
{
    DateTime startDate;
    DateTime endDate;
     public ExtractMenu(AccountBankModel accountBank)
    {   
        // Limpa o console
        Console.Clear();
        // Isntanciando o metodo de painel para o cabeçalho
        var header = new Panel("Selecione a opção desejada");
        // Duplica a borda do painel
        header.Border = BoxBorder.Double;
        // Escreve o cabeçalho em tela
        AnsiConsole.Write(header);
        // Replace no enum para mostrar as palavar sem _
        var optEnums = Enum.GetValues<ExtractEnum>()
                         .Select(e => e.ToString().Replace("_", " "))
                         .ToList();

        //Instanciando o enum no prompt do spectre
        var options = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(optEnums));


        switch(options)
        {
            case "Extrato dos Ultimos 30 dias": new ExtractService().ExtractServiceThirtyDay(accountBank);
            break;

            case "Extrato Personalizado": CustomExtractMenu(accountBank);
            break;
        }
    }

    public void CustomExtractMenu(AccountBankModel accountBank)
    {
        
        Console.Clear();
        var header = new Panel("Informe data inicio e data fim da busca");
        header.Border = BoxBorder.Double;
        AnsiConsole.Write(header);

        Console.Write("Digite a data de início (dd/MM/yyyy): ");
        startDate = ReadDate();

        Console.Write("Digite a data de fim (dd/MM/yyyy): ");
        endDate = ReadDate();
        
        new ExtractService().CustomExtract(accountBank, startDate, endDate);

    }

    static DateTime ReadDate()
    {
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            Console.Write("Formato inválido! Digite novamente (dd/MM/yyyy): ");
        }
        return date;
    }
}
