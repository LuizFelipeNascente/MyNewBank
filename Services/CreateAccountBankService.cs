using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Enums;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class CreateBankAccountService
{
    public CreateBankAccountService(AccountBankModel accountData)
    {
        if(accountData.Name == string.Empty || accountData.Email == string.Empty || accountData.Phone == string.Empty || accountData.Password == string.Empty)
        {
            new CreateBankAccountView().CreateBankAccountFaillView();
            return;
        }

        accountData.AccountId = new Guid();
        accountData.AccounStatus = AccountStatusEnum.Active;
        accountData.AccountNumber = BankAccountCodeGenerator();
        accountData.Balance = 0;
        accountData.AddOn = DateTime.Now;

        new CreateBankAccountRepository(accountData);
        new CreateBankAccountView().CreateBankAccountSuccessView(accountData.Name, accountData.AccountNumber);
         
    }

    public int BankAccountCodeGenerator()
    {
        int bankAccountNumber = new Random().Next(100000, 999999);
        //var check = new CheckAccountNumberService(bankAccountNumber);
        if(new CheckAccountNumberService().Check(bankAccountNumber))
        {
             return BankAccountCodeGenerator();
        }
        
        return bankAccountNumber;
       
    }
}
