using System;

static class SavingsAccount
{
    // Tarefa 1: Calcula a taxa de juros com base no saldo.
    public static float InterestRate(decimal balance)
    {
        // Usamos uma série de if-else if para determinar a taxa correta.
        // A ordem é importante para cobrir todos os intervalos.
        if (balance < 0)
        {
            return 3.213f;
        }
        else if (balance < 1000)
        {
            return 0.5f;
        }
        else if (balance < 5000)
        {
            return 1.621f;
        }
        else // balance >= 5000
        {
            return 2.475f;
        }
    }

    // Tarefa 2: Calcula o valor dos juros para um determinado saldo.
    public static decimal Interest(decimal balance)
    {
        // Primeiro, obtemos a taxa de juros chamando o método que já implementamos.
        float rate = InterestRate(balance);
        
        // Convertendo a taxa (float) para decimal para realizar o cálculo monetário.
        // A taxa é em porcentagem, então dividimos por 100.
        return balance * (decimal)rate / 100.0m;
    }

    // Tarefa 3: Calcula o saldo atualizado após um ano.
    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        // O novo saldo é o saldo original mais os juros ganhos.
        return balance + Interest(balance);
    }

    // Tarefa 4: Calcula o número de anos para atingir um saldo alvo.
    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        // Usamos um loop 'while' que continua enquanto o saldo atual for menor que o alvo.
        while (balance < targetBalance)
        {
            // A cada iteração, atualizamos o saldo para o do próximo ano (juros compostos).
            balance = AnnualBalanceUpdate(balance);
            // E incrementamos o contador de anos.
            years++;
        }
        return years;
    }
}
