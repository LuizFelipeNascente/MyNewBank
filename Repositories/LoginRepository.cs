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

    public bool CheckedPassword(string email, string password, out string name, out int accountNumber, out Guid accountId)
    {
        // declarando os parametros que serão passados por referencia 
        name = string.Empty;
        accountNumber = 0;
        accountId = Guid.Empty;
        // Iniciado o contexto de conexão com o banco de dados
        var context = new AppDbContext();
        // Procurando no banco se a senha passada na chamada, está correta        
        var accountBank = context.AccountBank.First(a => a.Email == email);
        

        if(accountBank.Password == password)
        {
            name = accountBank.Name;
            accountNumber = accountBank.AccountNumber;
            accountId = accountBank.AccountId;
            return true;
        }
        
        return false;
    }
}
