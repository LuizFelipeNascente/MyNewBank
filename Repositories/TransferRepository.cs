using System;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class TransferRepository
{
    AccountBankModel PayerAccountBank; 
    AccountBankModel ReceiverAccountBank;
    private AppDbContext context;
    public TransferRepository()
    {   
        // conexão com o banco de dados
        context = new AppDbContext();
    }

    public void MakeTransfer(AccountBankModel payerAccountBank, decimal newPayerBalance, AccountBankModel receiverAccountBank, decimal newReceiverBalance)
    {
        // atribui as propriedades os novos valores de saldo
        PayerAccountBank = payerAccountBank;
        ReceiverAccountBank = receiverAccountBank;
        // grava nas variaves as duas contas envolvidas na transferencia
        var sourceAccount = context.AccountBank.Find(PayerAccountBank.AccountId);
        var destinationAccount = context.AccountBank.Find(ReceiverAccountBank.AccountId);
        
        // atrbui os novos salvos para suas respectivas contas
        sourceAccount.Balance = newPayerBalance;
        destinationAccount.Balance = newReceiverBalance;
        
        context.SaveChanges();
    }
}
