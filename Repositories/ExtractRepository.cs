using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class ExtractRepository
{
    private AppDbContext context;
    public ExtractRepository()
    {
        // conexão com o banco de dados
        context = new AppDbContext();
    }

    public List<ExtractDto> ThirtyDayExtract(AccountBankModel accountBank)
    {
        var accountId = accountBank.AccountId;
        var limitDate = DateTime.Now.AddDays(-30);

        var transactions = context.Transactions
            .Where(t => (t.SourceAccountId == accountId || t.DestinationAccountId == accountId)
                && t.TransactionDate >= limitDate)
            .Select(t => new ExtractDto
            {
                TransactionType = t.TransactionType == Enums.TransactionTypeEnum.Deposito ? "Depósito" :
                    t.TransactionType == Enums.TransactionTypeEnum.Saque ? "Saque" :
                    (t.TransactionType == Enums.TransactionTypeEnum.Transferencia && t.SourceAccountId == accountId) ? "Transferência Realizada" :
                    (t.TransactionType == Enums.TransactionTypeEnum.Transferencia && t.DestinationAccountId == accountId) ? "Transferência Recebida" :
                    "Erro",
                Amount = t.Amount,
                TransactionDate = t.TransactionDate
            })
            .OrderByDescending(t => t.TransactionDate)
            .ToList();

        return transactions;    
    }

    public List<ExtractDto> CustomExtract(AccountBankModel accountBank, DateTime startDate, DateTime endDate)
    {
        var accountId = accountBank.AccountId;
        var start = startDate.Date; 
        var end = endDate.Date; 
        var transactions = context.Transactions
            .Where(t => (t.SourceAccountId == accountId || t.DestinationAccountId == accountId)
                && t.TransactionDate.Date >= start && t.TransactionDate.Date <= end)
            .Select(t => new ExtractDto
            {
                TransactionType = t.TransactionType == Enums.TransactionTypeEnum.Deposito ? "Depósito" :
                    t.TransactionType == Enums.TransactionTypeEnum.Saque ? "Saque" :
                    (t.TransactionType == Enums.TransactionTypeEnum.Transferencia && t.SourceAccountId == accountId) ? "Transferência Realizada" :
                    (t.TransactionType == Enums.TransactionTypeEnum.Transferencia && t.DestinationAccountId == accountId) ? "Transferência Recebida" :
                    "Erro",
                Amount = t.Amount,
                TransactionDate = t.TransactionDate
            })
            .OrderByDescending(t => t.TransactionDate)
            .ToList();
        
        return transactions;
    }
}