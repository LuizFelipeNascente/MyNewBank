using System;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class ExtractService
{
    ExtractRepository extractRepository;
    public ExtractService()
    {
        extractRepository = new ExtractRepository();
    }

    public List<ExtractDto> ExtractServiceThirtyDay(AccountBankModel accountBank)
    {
       var transactions  = extractRepository.ThirtyDayExtract(accountBank);
       new ExtractView(transactions, accountBank);
       return transactions;
    }
}
