using System;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

    public class DepositService
    {   
        private DepositView depositView;
        private DepositRepository depositRepository;
        public DepositService()
        {
            depositView = new DepositView();
            depositRepository = new DepositRepository();
        }

        public bool Deposit(string valueDeposit, AccountBankModel accountBank)
        {
            if (!decimal.TryParse(valueDeposit, out decimal value) || value < 0)
            {
                depositView.InvalidValue(accountBank);
                return false;
            }

            
            return true;
        }



    }
