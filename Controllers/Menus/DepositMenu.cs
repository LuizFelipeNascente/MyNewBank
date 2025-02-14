using System;
using MyNewBank.Models;
using MyNewBank.Services;

namespace MyNewBank.Controllers.Menus;

    public class DepositMenu
    {
        private string ValueDeposit { get; set; }
        public DepositMenu(AccountBankModel accountBank)
        {
            Console.Write("Qual Valor você irá depositar?: ");
            ValueDeposit = Console.ReadLine();
            
            new DepositService().Deposit(ValueDeposit, accountBank);
        }
    }
