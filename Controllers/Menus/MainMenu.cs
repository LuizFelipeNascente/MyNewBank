using System;
using MyNewBank.Enums;
using Spectre.Console;

namespace MyNewBank.Controllers.Menus;

public class MainMenu
{
    public MainMenu()
    {   
        // Limpa o console
        Console.Clear();
        // Isntanciando o metodo de painel para o cabeçalho
        var header = new Panel("Seja Bem Vindo ao NewBank! \nSelecione a opção desejada");
        // Duplica a borda do painel
        header.Border = BoxBorder.Double;
        // Escreve o cabeçalho em tela
        AnsiConsole.Write(header);
        // Replace no enum para mostrar as palavar sem _
        var optEnums = Enum.GetValues<MainMenuEnum>()
                         .Select(e => e.ToString().Replace("_", " "))
                         .ToList();

        var options = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(optEnums));

        switch(options)
        {
            case "Entrar em sua conta": Console.WriteLine("Você escolheu entrar na conta!");
            break;

            case "Criar uma nova conta": Console.WriteLine("Você escolheu criar uma nova conta!");
            break;

            case "Sair":
            Console.Clear(); 
            Console.WriteLine("Saindo do sistema...");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            return;
        }

    }

    
}
