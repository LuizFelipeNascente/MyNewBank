using System;
using System.ComponentModel.DataAnnotations;
using MyNewBank.Enums;

namespace MyNewBank.Models;

public class TransactionModel
{
    [Key]
    public Guid TransactionId { get; set; }
    public decimal Amount { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public Guid SourceAccountId { get; set; }
    public Guid? DestinationAccountId { get; set; }
    public DateTime TransactionDate { get; set; }
}
