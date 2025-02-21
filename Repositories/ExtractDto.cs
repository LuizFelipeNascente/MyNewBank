using System;

namespace MyNewBank.Repositories;

public class ExtractDto
{
    public string TransactionType { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
}
