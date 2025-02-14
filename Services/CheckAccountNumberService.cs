using System;
using MyNewBank.Repositories;

namespace MyNewBank.Services;

public class CheckAccountNumberService
{   
    CheckAccountNumberRepository checkAccountNumberRepository;
    public CheckAccountNumberService()
    {
        // construtor para injeção de dependencia
        checkAccountNumberRepository = new CheckAccountNumberRepository();
    }
    
    //Metodo que enviar o codigo da conta para o repositorio verificar
    // se o numero já existe ou não e retorna verdadeira ou falso
    public bool Check(int bankAccountNumber)
    {
        // o retorno já é a chamda no check pois ele ttbm é bool e já retorna 
        // true or false
        return checkAccountNumberRepository.Check(bankAccountNumber);
       
    }
}
