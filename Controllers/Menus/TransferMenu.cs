using System;
using MyNewBank.Models;
using MyNewBank.Services;

namespace MyNewBank.Controllers.Menus;

public class TransferMenu
{
    private string ValueTransfer;
    private int AccountNumber;
        public TransferMenu(AccountBankModel accountBank)
        {
            Console.Write("Qual o número da conta de destino?: ");
            int.TryParse(Console.ReadLine(), out AccountNumber);

            Console.Write("Qual Valor você irá depositar?: ");
            ValueTransfer = Console.ReadLine()?.Replace(',', '.');
            
            new TransferService().Transfer(accountBank, AccountNumber, ValueTransfer);
        }
}
