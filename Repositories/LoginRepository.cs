using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class LoginRepository
{
    public LoginRepository()
    {

    }

    public bool CheckedEmail(string email)
    {
        var context = new AppDbContext();
        // conecta no banco com a função Any, pois ele retorna true ou false caso econtre 
        // ou não o parametro passado
        return context.AccountBank.Any(e => e.Email == email);
    }

    public bool CheckedPassword(string password, out string name, out int accountNumber, out Guid accountId)
    {
        name = string.Empty;
        accountNumber = 0;
        accountId = Guid.Empty;
        var context = new AppDbContext();
        // conecta no banco com a função Any, pois ele retorna true ou false caso econtre 
        // ou não o parametro passado
        
        var accountBank = context.AccountBank.FirstOrDefault(e => e.Password == password);
        

        if(accountBank?.Password == password)
        {
            name = accountBank.Name;
            accountNumber = accountBank.AccountNumber;
            accountId = accountBank.AccountId;
            return true;
        }
        
        return false;
    }
}
