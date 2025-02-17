using System;

namespace MyNewBank.Repositories;

    public class BalanceRepository
    {
        private AppDbContext context;

        public BalanceRepository()
        {
            context = new AppDbContext();
        }
        public decimal GetBalance(Guid accountId)
        {
            //Usando o contexto para localizar uma linha no banco de dados e armazendo na variavel balance
            // o Find busca apenas por chaves primarias e trás todo o conteudo.
            var balance = context.AccountBank.Find(accountId);
            // Retorno para quem chamou o metodo o objeto.Propiedade. 
            return balance.Balance;
        }
    }
