using System;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class ExtractService
{
    ExtractView extractView;
    ExtractRepository extractRepository;
    public ExtractService()
    {
        extractRepository = new ExtractRepository();
        extractView = new ExtractView();
    }

    public List<ExtractDto> ExtractServiceThirtyDay(AccountBankModel accountBank)
    {
       var transactions  = extractRepository.ThirtyDayExtract(accountBank);
       if (!transactions.Any())
       {
           extractView.ExtractViewEmpty(accountBank);
           return new List<ExtractDto>();
       }

       // Crie uma lista para armazenar as transações modificadas
       var modifiedTransactions = new List<ExtractDto>();

       foreach (var transaction in transactions)
       {
           if (transaction.TransactionType == "Transferência Realizada")
           {
               // Altera o valor de Amount
               transaction.Amount = -transaction.Amount;
           }
            // Adiciona a transação (modificada ou não) na lista
            modifiedTransactions.Add(transaction);
       }

        // Agora, passa a lista completa para o método de sucesso
        extractView.ExtractViewSuccess(modifiedTransactions, accountBank);

        return new List<ExtractDto>();
    }

    public List<ExtractDto> CustomExtract(AccountBankModel accountBank, DateTime startDate, DateTime endDate)
    {
       var transactions  = extractRepository.CustomExtract(accountBank, startDate, endDate);
       if (!transactions.Any())
       {
           extractView.ExtractViewEmpty(accountBank);
           return new List<ExtractDto>();
       }

       // Crie uma lista para armazenar as transações modificadas
       var modifiedTransactions = new List<ExtractDto>();

       foreach (var transaction in transactions)
       {
           if (transaction.TransactionType == "Transferência Realizada")
           {
               // Altera o valor de Amount
               transaction.Amount = -transaction.Amount;
           }
            // Adiciona a transação (modificada ou não) na lista
            modifiedTransactions.Add(transaction);
       }

        // Agora, passa a lista completa para o método de sucesso
        extractView.ExtractViewSuccess(modifiedTransactions, accountBank);

        return new List<ExtractDto>();
    }
}
