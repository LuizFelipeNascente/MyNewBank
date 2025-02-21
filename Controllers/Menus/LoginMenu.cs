using System;
using MyNewBank.Models;
using MyNewBank.Services;
using Spectre.Console;

namespace MyNewBank.Controllers.Menus;

public class LoginMenu
{
    public string Email { get; set; }
    public string Password { get; set; }
    LoginService loginService;

    public LoginMenu()
    {
        loginService = new LoginService();
        // Limpa o console
        Console.Clear();
        // Isntanciando o metodo de painel para o cabeçalho
        var header = new Panel("Faça login com seu E-mail e Senha!");
        // Duplica a borda do painel
        header.Border = BoxBorder.Double;
        // Escreve o cabeçalho em tela
        AnsiConsole.Write(header);

        Console.Write("Digite seu e-mail: ");
        Email = Console.ReadLine()?.Trim().ToLower();

        Console.Write("Digite sua senha: ");
        Password = loginService.ReadPassword();

        LoginModel login = new LoginModel
        {
            Email = Email,
            Password = Password
        };

        new LoginService().Login(login);
    }
}
