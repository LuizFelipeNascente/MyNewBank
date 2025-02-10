using System;
using System.IO.Compression;
using MyNewBank.Controllers.Menus;
using Spectre.Console;

namespace MyNewBank.Views;

public class CreateBankAccountView
{
    public void CreateBankAccountSuccessView(string name, int accountNumber)
    {   
        Console.Clear();

        var welcome = new Panel($"{name} Seja bem vindo ao NewBank! \nO nuúmero da sua conta é {accountNumber} e para iniciar, pressione qulaquier tecla \ne faça login com seu email e senha");
        // Duplica a borda do painel
        welcome.Border = BoxBorder.Double;
        // Escreve o cabeçalho em tela
        AnsiConsole.Write(welcome);
        // Espara apenas um clique qualquer para em seguida levar para o menu inicial
        Console.ReadKey();
        new MainMenu();
    }

    public void CreateBankAccountFaillView()
    {   

        Console.WriteLine("Todos os dados são obrigatorios. Presisona qualquer tecla para continuar");
        Console.ReadKey();
        new MainMenu();
    }
}
