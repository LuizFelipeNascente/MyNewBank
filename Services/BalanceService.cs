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
        // o metodo recebe um accountId e enviado a classe de conexão com o banco de dados
        // para oberter um retorno que é o saldo da conta
        return balanceRepository.GetBalance(accountId);
    }
    
}
