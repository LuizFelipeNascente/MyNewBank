using System;

namespace MyNewBank.Services;

public class TransferService
{
    CheckAccountNumberService checkAccountNumberService;
    public TransferService()
    {
        checkAccountNumberService = new CheckAccountNumberService();       
    }
    public void Transfer(Guid sourceAccountId, int destinationAccountId, string valueTransfer)
    {
        
    }
}
