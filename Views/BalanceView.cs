using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;

namespace MyNewBank.Views;

public class BalanceView
{
    public BalanceView(AccountBankModel accountBank, decimal currentBalance)
        {   
            Console.WriteLine($"\nO Seu Saldo atual é de R$ {currentBalance} \nPression qualquer tecla para continuar!");
            Console.ReadKey();
            new LoggedMenu(accountBank);
        }
}
