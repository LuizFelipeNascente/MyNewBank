using System;

namespace MyNewBank.Models;

public class AccountModel
{
    public decimal Balance { get; protected set; } = 0;
    public int AccountNumber { get; set; }
    public DateTime AddOn { get; protected set; } = DateTime.Now;

}
