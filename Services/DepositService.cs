using System;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

    public class DepositService
    {   
        private decimal currentBalance;
        private decimal newBalance;
        private DepositView depositView;
        private DepositRepository depositRepository;
        private ValidatorService validatorService;
        private BalanceService balanceService;
        public DepositService()
        {
            depositView = new DepositView();
            depositRepository = new DepositRepository();
            validatorService = new ValidatorService();
            balanceService = new BalanceService();
            currentBalance = 0;
        }

        public void Deposit(string valueDeposit, AccountBankModel accountBank)
        {
            if (validatorService.TransactionValueValidator(valueDeposit))
            {
                depositView.InvalidValue(accountBank);
            }
            
            currentBalance = balanceService.CheckBalance(accountBank.AccountId);
            newBalance = currentBalance + decimal.Parse(valueDeposit);
            depositRepository.MakeDeposit(newBalance, accountBank);
            depositView.DepositMadeSuccessfully(accountBank, newBalance);
        }
    }
