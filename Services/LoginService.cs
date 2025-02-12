using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class LoginService
{
    private string Email { get; set; }
    private string Password { get; set; }
    
    string name;
    int accountNumber;
    Guid accountId;

    public LoginService()
    {
        // construtor
    }

    public void Login(LoginModel login)
    {
        //Atribui os valores capturadas no menu para os atributos da classe
        Email = login.Email;
        Password = login.Password;

        //verifica se algum dado enviado pelo usuario é vazio e caso seja leva para a view
        if(Email == string.Empty || Password == string.Empty)
        {
            //se for vazio leva para a view que passa as informações necessárias dados invalidos
            new LoginView().EmptyData();
            return;
        }
        // Envia o emial para passado para o metodo de queverifica se o email existe no banco
        if(CheckedEmail(Email))
        {
            // email existindo, é verificado se a senha bate
            if(CheckedPassword(Password))
            {
                // senha bateu, o usuário e direciado para a area logada 
                new LoggedMenu(name, accountNumber, accountId);
                return;
            } 
            // email não bateu é enviado para view que passa a informação necessária
            new LoginView().IncorrectPassword();
            return;
        }
        // se o email não existe no banco, é chamada a view que passa essa informação
        new LoginView().EmailNotFound();
    }
    //Metodo que verifica se o email existe no banco
    public bool CheckedEmail(string email)
    {
        // o emial passo no meuno de login, é enviado o repositorio que verifica se ele sexiste no banco
        return new LoginRepository().CheckedEmail(email);
    }
    //Metodo que verifica se a senha está correta
    public bool CheckedPassword(string password)
    {
        // senha passada no login é enviada para o reposistoio veriicar se ela está correta
        return new LoginRepository().CheckedPassword(password, out name, out accountNumber, out accountId);
    }
}
