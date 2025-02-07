using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class AccountBankRepository
{   
    
    public AccountBankRepository(AccountBankModel accountData)
    {
        var context = new AppDbContext();

        // Adiciona a nova conta ao banco
        context.AccountBank.Add(accountData);
        // Salva as alterações feitas
        context.SaveChanges();
    }
}
