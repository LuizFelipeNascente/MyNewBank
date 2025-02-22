using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class LoginRepository
{
    private AppDbContext context;
    public LoginRepository()
    {
        context = new AppDbContext();
    }

    public bool CheckedEmail(string email)
    {
        //var context = new AppDbContext();
        // conecta no banco com a função Any, pois ele retorna true ou false caso econtre 
        // ou não o parametro passado
        return context.AccountBank.Any(e => e.Email == email);
    }

    public bool CheckedPassword(string email, string password, out AccountBankModel accountBank)
    {
        // declarando os parametros que serão passados por referencia 
        
        // Iniciado o contexto de conexão com o banco de dados
        //var context = new AppDbContext();
        // Procurando o primeiro registro no banco do email já validado
        accountBank = context.AccountBank.First(a => a.Email == email);
        // Vaerificando se a senha do email localizado é igual a senha digitada
        return accountBank.Password == password;
    }
    //Metodo que busca uma conta bancaraia atraves do seu numero de conta
    public AccountBankModel VerifyAccount(int accountNumber)
    {
        AccountBankModel destinationAccountNumber = context.AccountBank.FirstOrDefault(x => x.AccountNumber == accountNumber);
        return destinationAccountNumber;
    }
}
