using System;
using System.ComponentModel.DataAnnotations;
using MyNewBank.Enums;

namespace MyNewBank.Models;

public class AccountBankModel : AccountModel
{
    [Key]
    public Guid AccountId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set ;}
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountStatusEnum AccounStatus {get; set;}
    
}
