using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;

namespace MyNewBank.Views;

public class WithdrawalView
{
    public void InvalidValue(AccountBankModel accountBank)
    {
        Console.WriteLine("\nO valor informado é invalido! Pressiona qualquer tecla para informar um novo valor ou ESC para voltar ao menu");
            // instaancia a classe que armazena o tipo de entrada que o usuário usou no teclado
            // e armazendo na variavel input 
            ConsoleKeyInfo input = Console.ReadKey();
            // Verificando se o que o usuário digito é ESC e se sim
            // encerra o programa e se não, manda de volta para o login
            if(input.Key == ConsoleKey.Escape)
                new LoggedMenu(accountBank);
            new WithdrawalMenu(accountBank);
    }

    public void WithdrawalNotSuccessfully(AccountBankModel accountBank, decimal currentBalance)
    {
         Console.WriteLine($"\nSaldo insulficiente para este Saque! \nSeu Saldo atual é de R$ {currentBalance} \nPression qualquer tecla para continuar!");
            Console.ReadKey();
        new LoggedMenu(accountBank);
    }
    public void WithdrawalSuccessfully(AccountBankModel accountBank, decimal newBalance, decimal valueWithdrawal)
    {
        Console.WriteLine($"\nO valor de R$ {valueWithdrawal} Foi SACADO! \nSeu Saldo atual é de R$ {newBalance} \nPression qualquer tecla para continuar!");
            Console.ReadKey();
        new LoggedMenu(accountBank);
    }
}
