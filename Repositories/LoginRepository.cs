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
        // Procurando o primeiro registro no banco do email já validado
        var accountBank = context.AccountBank.First(a => a.Email == email);
        // Vaerificando se a senha do email localizado é igual a senha digitada
        if(accountBank.Password == password)
        {   
            // Se a senha for igual, atribui dados da referencia e retorna true 
            name = accountBank.Name;
            accountNumber = accountBank.AccountNumber;
            accountId = accountBank.AccountId;
            return true;
        }
        // Se a senha for diferente retorna false
        return false;
    }
}
