using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class DepositRepository
{
    private AppDbContext context;
    public DepositRepository()
    {   
        // conexão com o banco de dados
        context = new AppDbContext();
    }

    public decimal MakeDeposit(decimal newBalance, AccountBankModel accountBank)
    {
        // a conta do usuário é obtida atraves do objeto enviado na chamada do metodo
        var accountBalance = context.AccountBank.Find(accountBank.AccountId);
        // na conta, o novo valor de saldo é atrivuido ao campo de saldo
        accountBalance.Balance = newBalance;
        // as alterações realizadas na conta são salvas
        context.SaveChanges();
        // o novo valor do saldo após update é retornado para quem chamou o metodo
        return accountBalance.Balance;
    }
    
}
