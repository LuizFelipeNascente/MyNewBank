using System;
using MyNewBank.Controllers.Menus;

namespace MyNewBank.Views;

public class LoginView
{
    public void EmptyData()
    {
        Console.WriteLine("\nEmail ou Senha inválidos! Pressiona qualquer tecla para voltar ao login ou ESC para voltar ao menu principal");
        // instaancia a classe que armazena o tipo de entrada que o usuário usou no teclado
        // e armazendo na variavel input 
        ConsoleKeyInfo input = Console.ReadKey();
        // Verificando se o que o usuário digito é ESC e se sim
        // encerra o programa e se não, manda de volta para o login
        if(input.Key == ConsoleKey.Escape)
            new MainMenu();
        new LoginMenu();
    }

    public void EmailNotFound()
    {
        Console.WriteLine("\nEmail não encontrado! Pressiona qualquer tecla para voltar ao login ou ESC para voltar ao menu principal");
        // instaancia a classe que armazena o tipo de entrada que o usuário usou no teclado
        // e armazendo na variavel input 
        ConsoleKeyInfo input = Console.ReadKey();
        // Verificando se o que o usuário digito é ESC e se sim
        // encerra o programa e se não, manda de volta para o login
        if(input.Key == ConsoleKey.Escape)
        new MainMenu();
        new LoginMenu();
    }

    public void IncorrectPassword()
    {
        // informa que a senha está errada
        Console.WriteLine("\nSenha incorreta! Tente novamente");
        // para a thred por dois segundos e meio
        Thread.Sleep(2500);
        // Leva de volta ao menu de fazer login
        new LoginMenu();
    }
}
