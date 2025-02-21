using System;
using MyNewBank.Models;
using MyNewBank.Repositories;
using MyNewBank.Views;

namespace MyNewBank.Services;

public class TransferService
{
    TransferRepository transferRepository;
    BalanceService balanceService;
    LoginRepository loginRepository;
    TransferView transferView;
    TransactionService transactionService;
    AccountBankModel DestinationAccountId;
    ValidatorService validatorService;
    
    decimal PayerBalance;
    decimal ReceiverBalance;
    public TransferService()
    {
        balanceService = new BalanceService();     
        transferRepository = new TransferRepository();  
        loginRepository = new LoginRepository();
        transferView = new TransferView();
        transactionService = new TransactionService();
        validatorService = new ValidatorService();
    }
    public void Transfer(AccountBankModel accountBank, int destinationAccountNumber, string valueTransfer)
    {   
        if (destinationAccountNumber == 0)
            {
                transferView.TransferImpossible(accountBank);
                return;
            }

        if (!validatorService.TransactionValueValidator(valueTransfer))
            {
                transferView.InvalidValue(accountBank);
                return;
            }    
        // Atribuindo o saldo atual do pagador, usando metodo de verificar saldo! Mandando o accountid
        // para em seguida fazer a diminuição desse valor
        PayerBalance = balanceService.CheckBalance(accountBank.AccountId);
        // Pegando accountid de destino, atraves do metodo que verifica a existenci da conta bancarai
        // atraves de numero de conta da conta
        DestinationAccountId = loginRepository.VerifyAccount(destinationAccountNumber);
        
        //Verifica se a conta existe
        if(DestinationAccountId == null)
        {
            //Se não existir, manda para a view infomar
            transferView.TransferInvalid(accountBank, destinationAccountNumber);
            return;
        }
        // Se existir
        //Atribui o saldo da conta destino à propriedade que será usada para somar
        ReceiverBalance = balanceService.CheckBalance(DestinationAccountId.AccountId);

        // Verifica se o pagador tem saldo para realizar a transferencia
        if(PayerBalance < decimal.Parse(valueTransfer))
        {
            //Se não tiver, manda para view passar a infomação
            transferView.TransferNotSuccessfully(accountBank, PayerBalance);
            return;
        }
        
        //Atribui os novos saldos de destino e origem após a transferencia
        var newPayerBalance = PayerBalance - decimal.Parse(valueTransfer);
        var newReceiverBalance = ReceiverBalance + decimal.Parse(valueTransfer);
        // Envia para o serviço de transferenia as informações para gerar o dado na base
        transferRepository.MakeTransfer(accountBank, newPayerBalance, DestinationAccountId, newReceiverBalance);
        //Se a gravação dos novos saldos em banco for bem sucessido, envia para a view de sucesso
        if(transactionService.TransactionTransfer(accountBank, DestinationAccountId, decimal.Parse(valueTransfer)))
            transferView.TransferSuccessfully(accountBank, newPayerBalance, decimal.Parse(valueTransfer), DestinationAccountId);

    }
}
