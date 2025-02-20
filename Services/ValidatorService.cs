using System;

namespace MyNewBank.Services;

public class ValidatorService
{
    public ValidatorService()
    {
        
    }

    public bool TransactionValueValidator(string valueDeposit)
    {  
       // verifica se o o valor digitado é aceita como um valor de transação
       // AINDA PRECISA DE APRIMORAMENTO, POIS ACEITA VIRGULAS ** Virgulas tratada no input
       return !decimal.TryParse(valueDeposit, out decimal value) || value <= 0;
    }

    // Defasado após o uso do TreyParse no input do numero da conta em TransferMenu  
    public bool AccountNumberValidator(string destinationAccountNumber)
    {  
       // verifica se o o valor digitado é aceita como um valor de transação
       // AINDA PRECISA DE APRIMORAMENTO, POIS ACEITA VIRGULAS ** Virgulas tratada no input
       return !int.TryParse(destinationAccountNumber, out int value) || value == 0;
    }
}
