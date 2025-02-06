using System;
using MyNewBank.Models.Interfaces;
using MyNewBank.Services;
using Spectre.Console;

namespace MyNewBank.Controllers.Menus;

public class CreateBankAccountMenu
{
    public CreateBankAccountMenu()
    {
        // Limpa o console
        Console.Clear();
        // Isntanciando o metodo de painel para o cabeçalho
        var header = new Panel("Preencha todos os dados solicitados \n  para abrir sua conta no NewBank");
        // Duplica a borda do painel
        header.Border = BoxBorder.Double;
        // Escreve o cabeçalho em tela
        AnsiConsole.Write(header);

        //nome, telefone, email, senha
        Console.Write("Informe seu nome: ");
        var name = Console.ReadLine();

        Console.Write("Informe seu telefone: ");
        var phone = Console.ReadLine();

        Console.Write("Informe seu email: ");
        var email = Console.ReadLine();

        Console.Write("Defina sua senha: ");
        var password = Console.ReadLine();

        var accountData = new
        {
            Name = name,
            Phone = phone,
            Email = email,
            Password = password
        };

        new CreateAccountBankService(accountData);    

    }
}
