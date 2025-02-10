using System;
using MyNewBank.Repositories;

namespace MyNewBank.Services;

public class CheckAccountNumberService
{   
    public CheckAccountNumberService()
    {
        
    }
    
    public bool Check(int bankAccountNumber)
    {
        return new CheckAccountNumberRepository().Check(bankAccountNumber);
       
    }
}
