using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class CreateBankAccountRepository
{   
    private AppDbContext context;

    public CreateBankAccountRepository()
    {
        context = new AppDbContext();
    }
    public void CreateBankAccount(AccountBankModel accountData)
    {
        //var context = new AppDbContext();
        context = new AppDbContext();
        // Adiciona a nova conta ao banco
        context.AccountBank.Add(accountData);
        // Salva as alterações feitas
        context.SaveChanges();
    }
}
