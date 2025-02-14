using System;

namespace MyNewBank.Repositories;

public class CheckAccountNumberRepository
{
    private AppDbContext context;
    public bool Check(int bankAccountNumber)
    {
        context = new AppDbContext();
        // conexão com o banco
        //var context = new AppDbContext();
        // conecta no banco com a função Any, pois ele retorna true ou false caso econtre 
        // ou não o parametro passado
        return context.AccountBank.Any(a => a.AccountNumber == bankAccountNumber);
         
    }
}
