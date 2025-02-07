using System;
using MyNewBank.Enums;
using MyNewBank.Models;
using MyNewBank.Repositories;

namespace MyNewBank.Services;

public class CreateAccountBankService
{
    public CreateAccountBankService(AccountBankModel accountData)
    {
        accountData.AccountId = new Guid();
        accountData.AccounStatus = AccountStatusEnum.Active;
        accountData.AccountNumber = CheckAccountNumber();
        accountData.Balance = 0;
        accountData.AddOn = DateTime.Now;

        new AccountBankRepository(accountData);


    }

    public int CheckAccountNumber()
    {
        return 1;
    }
}
