using System;
using MyNewBank.Repositories;

namespace MyNewBank.Services;

public class BalanceService
{
    private BalanceRepository balanceRepository;
    public BalanceService()
    {
        balanceRepository = new BalanceRepository();
    }

    public decimal CheckBalance(Guid accountId)
    {
        return balanceRepository.GetBalance(accountId);
    }
    
}
