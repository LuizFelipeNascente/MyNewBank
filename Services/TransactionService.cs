using System;
using MyNewBank.Models;
using MyNewBank.Repositories;

namespace MyNewBank.Services;

public class TransactionService
{
    TransactionRepository transactionRepository;
    TransactionModel transactionModel;
    public TransactionService()
    {
        transactionRepository = new TransactionRepository();
        transactionModel = new TransactionModel();
    }

    public bool TransactionDeposit(Guid accountBankId, decimal value)
    {   
        transactionModel.TransactionId = new Guid();
        transactionModel.Amount = value;
        transactionModel.TransactionType = Enums.TransactionTypeEnum.Deposito;
        transactionModel.SourceAccountId = accountBankId;
        transactionModel.DestinationAccountId = null;
        transactionModel.TransactionDate = DateTime.Now;

        return transactionRepository.Transaction(transactionModel);
        
    }

    public bool TransactionWithdrawal(Guid accountBankId, decimal value)
    {   
        transactionModel.TransactionId = new Guid();
        transactionModel.Amount = value * -1;
        transactionModel.TransactionType = Enums.TransactionTypeEnum.Saque;
        transactionModel.SourceAccountId = accountBankId;
        transactionModel.DestinationAccountId = null;
        transactionModel.TransactionDate = DateTime.Now;

        return transactionRepository.Transaction(transactionModel);
        
    }
}
