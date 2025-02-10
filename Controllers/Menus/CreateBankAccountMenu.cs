using System;
using MyNewBank.Models;
using MyNewBank.Services;
using Spectre.Console;

namespace MyNewBank.Controllers.Menus;

public class CreateBankAccountMenu
{
    private string Name { get; set;}
    private string Phone { get; set;}
    private string Email { get; set;}
    private string Password { get; set;}
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
        Name = Console.ReadLine();

        Console.Write("Informe seu telefone: ");
        Phone = Console.ReadLine();

        Console.Write("Informe seu email: ");
        Email = Console.ReadLine();

        Console.Write("Defina sua senha: ");
        Password = Console.ReadLine();

        AccountBankModel accountData = new AccountBankModel
        {
            Name = Name,
            Phone = Phone,
            Email = Email,
            Password = Password
        };

        //var sendoModelBankAccount = new AccountBankModel();
        //sendoModelBankAccount.CreateAccountBank(accountData);

        new CreateBankAccountService().CreateBankAccount(accountData);
        
    }
}

/*

    private string Name { get; set;}
    private string Phone { get; set;}
    private string Email { get; set;}
    private string Password { get; set;}

    public CreateBankAccountMenu()
    {
        Menu();
    }

    public AccountBankModel ToModel()
    {
        //validade 
        
        return new AccountBankModel
        {
            Name = Name,
            Phone = Phone,
            Email = Email,
            Password = Password
        };

       
    }

    public void SendToService()
    {
        new CreateAccountBankService(ToModel());
    }

*/