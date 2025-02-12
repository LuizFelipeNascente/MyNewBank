using System;
using MyNewBank.Models;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class DepositService
{
    public DepositService()
    {
        
    }

    public bool Deposit(decimal value, AccountBankModel accountBank)
    {

        if(value < 0)
            new DepositView().InvalidValue(accountBank);
        return true;
    }


}
