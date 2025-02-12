using System;
using MyNewBank.Enums;
using MyNewBank.Models;
using Spectre.Console;

namespace MyNewBank.Controllers.Menus;

public class LoggedMenu
{
    public LoggedMenu(AccountBankModel accountBank)
    {
        Console.Clear();
        // Isntanciando o metodo de painel para o cabeçalho
        var header = new Panel($"Seja Bem Vindo ao NewBank {accountBank.Name}! Cc: {accountBank.AccountNumber} \nSelecione a opção desejada");
        header.Border = BoxBorder.Double;
        // Escreve o cabeçalho em tela
        AnsiConsole.Write(header);
        // Replace no enum para mostrar as palavar sem _
        var optEnums = Enum.GetValues<LoggedMenuEnum>()
                         .Select(e => e.ToString().Replace("_", " "))
                         .ToList();

        //Instanciando o enum no prompt do spectre
        var options = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(optEnums));


        switch(options)
        {
            case "Ver meu saldo" : Console.WriteLine("Mostrando saldo ...");
            break;

            case "Fazer um deposito" : Console.WriteLine("Depositando ...");
            break;

            case "Fazer um saque" : Console.WriteLine("Sacando ...");
            break;

            case "Fazer uma transferecia" : Console.WriteLine("Transferindo ...");
            break;

            case "Ver meu extrato" : Console.WriteLine("Mostrando extrando ...");
            break;

            case "Sair da conta":
            Console.Clear(); 
            Console.WriteLine("Saindo do sistema");
            Thread.Sleep(500);
            Console.Clear(); 
            Console.WriteLine("Saindo do sistema.");
            Thread.Sleep(500);
            Console.Clear(); 
            Console.WriteLine("Saindo do sistema..");
            Thread.Sleep(500);
            Console.Clear(); 
            Console.WriteLine("Saindo do sistema...");
            Thread.Sleep(500);
            Console.Clear(); 
            return;
        }                 

    }
}
