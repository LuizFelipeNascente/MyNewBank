using System;
using MyNewBank.Enums;

namespace MyNewBank.Models.Interfaces;

public class AccountBankModel : AccountModel
{
    public Guid AccountId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set ;}
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountStatusEnum AccounStatus {get; private set;} = AccountStatusEnum.Active;

}
