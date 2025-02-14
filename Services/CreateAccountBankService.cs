using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Enums;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class CreateBankAccountService
{
    CheckAccountNumberService checkAccountNumberService;
    CreateBankAccountView createBankAccountView;
    public CreateBankAccountService()
    {
        // contrutor
        createBankAccountView = new CreateBankAccountView();
        checkAccountNumberService = new CheckAccountNumberService();
    }
    public void CreateBankAccount(AccountBankModel accountData)
    {
        // verifica se accountData tem algum dado vazio
        if(accountData.Name == string.Empty || accountData.Email == string.Empty || accountData.Phone == string.Empty || accountData.Password == string.Empty)
        {   
            //caso tenha algo vazio, retorna, manda para um view de erro
            createBankAccountView.CreateBankAccountFaillView();
            return;
        }

        //adiciona dados que accountData ainda não tem
        accountData.AccountId = new Guid();
        accountData.AccounStatus = AccountStatusEnum.Active;
        accountData.AccountNumber = BankAccountCodeGenerator(); // chama um metodo para gerar e verificar um novo numero de conta
        accountData.Balance = 0;
        accountData.AddOn = DateTime.Now;

        // instacia a classe de repositorio e manda o accountData com todos os dados para serem salvos
        new CreateBankAccountRepository(accountData);
        // instanacia a view que mostra o resultado de sucesso na criação de uma nova conta
        createBankAccountView.CreateBankAccountSuccessView(accountData.Name, accountData.AccountNumber);
         
    }

    public int BankAccountCodeGenerator()
    {
        //Gerar um numero aleatorio para definciar como numero da conta corrente
        int bankAccountNumber = new Random().Next(100000, 999999);
        // instancia a classe que verifica se esse numero já existe no banco
        if(checkAccountNumberService.Check(bankAccountNumber))
        {   
             //Caso exista, chama o metodo novamente para criar um novo numero   
             return BankAccountCodeGenerator();
        }
        // caso não exista, retorna o nuéro gerado para salvar no banco
        return bankAccountNumber;
       
    }
}
