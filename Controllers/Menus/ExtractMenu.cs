using System;
using MyNewBank.Enums;
using MyNewBank.Models;
using Spectre.Console;

namespace MyNewBank.Controllers.Menus;

public class ExtractMenu
{
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
            case "Extrado dos ultimos 30 dias": Console.WriteLine("30 dias ...");
            break;

            case "Extrato Personalizado": Console.WriteLine("Personalizado ...");
            break;
        }
    }
}
