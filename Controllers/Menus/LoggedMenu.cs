using System;

namespace MyNewBank.Controllers.Menus;

public class LoggedMenu
{
    public LoggedMenu(string userName, int userAccountNumber, Guid userAccountId)
    {
        Console.WriteLine($"Olá {userName} Você está logado na conta {userAccountNumber} e seu guid é {userAccountId}");
    }
}
