using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class CreateBankAccountRepository
{   
    
    public CreateBankAccountRepository(AccountBankModel accountData)
    {
        var context = new AppDbContext();

        // Adiciona a nova conta ao banco
        context.AccountBank.Add(accountData);
        // Salva as alterações feitas
        context.SaveChanges();
    }
}
