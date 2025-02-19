using System;
using System.Transactions;
using MyNewBank.Models;

namespace MyNewBank.Repositories;

public class TransactionRepository
{
    private AppDbContext context;
    public TransactionRepository()
    {
        context = new AppDbContext();
    }

    public bool Transaction(TransactionModel transactionModel)
    {
        // recebendo os dados da transação atraves de transactionModel
        context.Transactions.Add(transactionModel);
        // Salva as alterações feitas
        context.SaveChanges();
        // retorna true se o processo for bem sucedido
        return true;
    }
}
