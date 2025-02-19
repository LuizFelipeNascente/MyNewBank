using System;
using MyNewBank.Models;
using MyNewBank.Repositories;

namespace MyNewBank.Services;

public class TransactionService
{
    TransactionRepository transactionRepository;
    public TransactionService()
    {
        transactionRepository = new TransactionRepository();
    }

    public void Transaction(AccountModel accountModel, TransactionModel transactionModel)
    {
        
    }
}
