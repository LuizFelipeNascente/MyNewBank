using System;

namespace MyNewBank.Services;

public class ValidatorService
{
    public ValidatorService()
    {
        
    }

    public bool TransactionValueValidator(string valueDeposit)
    {
       return !decimal.TryParse(valueDeposit, out decimal value) || value < 0;
    }
}
