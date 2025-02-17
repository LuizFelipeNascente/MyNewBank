using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class DepositRepository
{
    private AppDbContext context;
    public DepositRepository()
    {
        context = new AppDbContext();
    }

    public decimal MakeDeposit(decimal newBalance, AccountBankModel accountBank)
    {
        var accountBalance = context.AccountBank.Find(accountBank.AccountId);
        accountBalance.Balance = newBalance;
        context.SaveChanges();
        return accountBalance.Balance;
    }
    
}
