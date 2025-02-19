using System;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

    public class DepositService
    {   
        // Declaração dos dados para instanciação
        private decimal currentBalance;
        private decimal newBalance;
        private DepositView depositView;
        private DepositRepository depositRepository;
        private ValidatorService validatorService;
        private BalanceService balanceService;
        private TransactionService transactionService;
        
        public DepositService()
        {
            // instanciando classes
            depositView = new DepositView();
            depositRepository = new DepositRepository();
            validatorService = new ValidatorService();
            balanceService = new BalanceService();
            currentBalance = 0;
            transactionService = new TransactionService();
            
        }

        public void Deposit(string valueDeposit, AccountBankModel accountBank)
        {
            //pega o valor digfitado e envia para o validador e caso seja invalido, manda para a view responsavel
            if (validatorService.TransactionValueValidator(valueDeposit))
            {
                depositView.InvalidValue(accountBank);
                return;
            }
            // caso o dado seja aceito
            // o saldo atual da conta é obito pelo checkbalance e atrobuido a uma variavel
            currentBalance = balanceService.CheckBalance(accountBank.AccountId);
            // o novo saldo e atribuido somando o saldo atual mais o que obito no banco de dados
            newBalance = currentBalance + decimal.Parse(valueDeposit);
            // O novo saldo após a soma é enviado para a classe de conexão com o banco de dados
            depositRepository.MakeDeposit(newBalance, accountBank);

            // COMEÇAR A IMPLEMENTAÇÃO DE TRANSAÇÕES
            if(transactionService.TransactionDeposit(accountBank.AccountId, decimal.Parse(valueDeposit)))
            // após o novo valor ser enviado para ser salvo em banco, o usuário é redirecionado para para o view de sucesso
            //se o salvamento em banco der certo
                depositView.DepositSuccessfully(accountBank, newBalance, decimal.Parse(valueDeposit));
        }
    }
