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
        accountData.AccountNumber = BankAccountCodeGenerator();
        accountData.Balance = 0;
        accountData.AddOn = DateTime.Now;

        new AccountBankRepository(accountData);
    }

    public int BankAccountCodeGenerator()
    {
        int bankAccountNumber = new Random().Next(100000, 999999);
        if(new CheckAccountNumberRepository().Check(bankAccountNumber) == false)
        {
            return bankAccountNumber;
        }
        return BankAccountCodeGenerator();
    }
}
