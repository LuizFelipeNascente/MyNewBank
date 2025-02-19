using System;
using MyNewBank.Repositories;

namespace MyNewBank.Services;

public class TransferService
{
    TransferRepository transferRepository;
    BalanceService balanceService;
    decimal PayerBalance;
    decimal ReceiverBalance;
    public TransferService()
    {
        balanceService = new BalanceService();     
        transferRepository = new TransferRepository();  
    }
    public void Transfer(Guid sourceAccountId, int destinationAccountId, string valueTransfer)
    {
        PayerBalance = balanceService.CheckBalance(sourceAccountId);
        //ReceiverBalance = balanceService.CheckBalance(destinationAccountId);
    }
}
