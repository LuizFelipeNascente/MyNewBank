using System;
using MyNewBank.Controllers.Menus;
using MyNewBank.Models;

namespace MyNewBank.Views;

    public class DepositView
    {
        public void InvalidValue(AccountBankModel accountBank)
        {
            Console.WriteLine("\nO valor informado é invalido! Pressiona qualquer tecla para informar um novo valor ou ESC para voltar ao menu");
            // instaancia a classe que armazena o tipo de entrada que o usuário usou no teclado
            // e armazendo na variavel input 
            ConsoleKeyInfo input = Console.ReadKey();
            // Verificando se o que o usuário digito é ESC e se sim
            // encerra o programa e se não, manda de volta para o login
            if(input.Key == ConsoleKey.Escape)
                new LoggedMenu(accountBank);
            new DepositMenu(accountBank);
        }

        public void DepositSuccessfully(AccountBankModel accountBank, decimal newBalance, decimal valueDeposit)
        {   
            Console.WriteLine($"\nO valor de R$ {valueDeposit} Foi depositado! \nSeu Saldo atual é de R$ {newBalance} \nPression qualquer tecla para continuar!");
            Console.ReadKey();
            new LoggedMenu(accountBank);
        }
    }
