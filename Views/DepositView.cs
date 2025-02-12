using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;

namespace MyNewBank.Views;

public class DepositView
{
    public void InvalidValue(AccountBankModel accountBank)
    {
        Console.WriteLine("\nO valor informado é invalido! Pressiona qualquer tecla para informaar um novo valor ou ESC para voltar ao menu");
        // instaancia a classe que armazena o tipo de entrada que o usuário usou no teclado
        // e armazendo na variavel input 
        ConsoleKeyInfo input = Console.ReadKey();
        // Verificando se o que o usuário digito é ESC e se sim
        // encerra o programa e se não, manda de volta para o login
        if(input.Key == ConsoleKey.Escape)
            new LoggedMenu(accountBank);
        new DepositMenu(accountBank);
    }
}
