using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;

namespace MyNewBank.Views;

public class TransferView
{
    public void TransferNotSuccessfully(AccountBankModel accountBank, decimal payerBalance)
    {
         Console.WriteLine($"\nSaldo insulficiente para esta Transferência! \nSeu Saldo atual é de R$ {payerBalance} \nPression qualquer tecla para continuar!");
            Console.ReadKey();
        new LoggedMenu(accountBank);
    }
    public void TransferSuccessfully(AccountBankModel accountBank, decimal newBalance, decimal valueTransfer)
    {
        Console.WriteLine($"\nO valor de R$ {valueTransfer} Foi Tranferido! \nSeu Saldo atual é de R$ {newBalance} \nPression qualquer tecla para continuar!");
            Console.ReadKey();
        new LoggedMenu(accountBank);
    }

    public void TransferImpossible(AccountBankModel accountBank, int accountDestination)
    {
        Console.WriteLine($"\nA transferência não poderá ser realizada! \nA conta {accountDestination} Não foi localizada! \nRevize o número da conta e tente novamente");
            Console.ReadKey();
        new LoggedMenu(accountBank);
    }
}
