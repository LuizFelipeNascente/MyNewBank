using System;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class WithdrawalService
{
    private decimal currentBalance;
    private decimal newBalance;
    private WithdrawalView withdrawalView;
    private WithdrawalRepository withdrawalRepository;
    private ValidatorService validatorService;
    private BalanceService balanceService;
    private TransactionService transactionService;
    public WithdrawalService()
    {
        withdrawalView = new WithdrawalView();
        withdrawalRepository = new WithdrawalRepository();
        validatorService = new ValidatorService();
        balanceService = new BalanceService();
        currentBalance = 0;
        transactionService = new TransactionService();
    }
    public void Withdrawal(string valueWithdrawal, AccountBankModel accountBank)
    {
        //enviando o valor digitado para o metodo que verifica se é valido 
        if (!validatorService.TransactionValueValidator(valueWithdrawal))
            {
                withdrawalView.InvalidValue(accountBank);
                return;
            }
        // criando variavel para armazenar o saldo atual da conta
        currentBalance = balanceService.CheckBalance(accountBank.AccountId);
        // verificando se o salfo atual da conta é menor que o valor sacado
        if(currentBalance < decimal.Parse(valueWithdrawal))
        {
            //se for menor, levar para a view passar a informação necessária
            withdrawalView.WithdrawalNotSuccessfully(accountBank, currentBalance);
            return;
        }
        // o novo saldo e atribuido diminuindo o saldo atual do valor sacado
        newBalance = currentBalance - decimal.Parse(valueWithdrawal);
        // O novo saldo após a diminuição é enviado para a classe de conexão com o banco de dados
        withdrawalRepository.MakeWithdrawal(newBalance, accountBank);
        // COMEÇAR A IMPLEMENTAÇÃO DE TRANSAÇÕES
        if(transactionService.TransactionWithdrawal(accountBank.AccountId, decimal.Parse(valueWithdrawal)))
        // após o novo valor ser enviado para ser salvo em banco, o usuário é redirecionado para para o view de sucesso
        //se o salvamento em banco der certo
            withdrawalView.WithdrawalSuccessfully(accountBank, newBalance, decimal.Parse(valueWithdrawal));
    }   
}
