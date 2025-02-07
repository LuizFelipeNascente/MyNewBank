using System;

namespace MyNewBank.Repositories;

public class CheckAccountNumberRepository
{
    public bool Check(int bankAccountNumber)
    {
        // conexão com o banco
        var context = new AppDbContext();
        
        return context.AccountBank.Any(a => a.AccountNumber == bankAccountNumber);
         
    }
}
