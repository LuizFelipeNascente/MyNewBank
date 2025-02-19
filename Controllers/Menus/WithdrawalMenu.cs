using System;
using MyNewBank.Models;
using MyNewBank.Services;

namespace MyNewBank.Controllers.Menus;

public class WithdrawalMenu
{
    private string ValueWithdrawal;
        public WithdrawalMenu(AccountBankModel accountBank)
        {
            Console.Write("Qual Valor você irá Sacar?: ");
            ValueWithdrawal = Console.ReadLine()?.Replace(',', '.');
            
            new WithdrawalService().Withdrawal(ValueWithdrawal, accountBank);
        }
}
