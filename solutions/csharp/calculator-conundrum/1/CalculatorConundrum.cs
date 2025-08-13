using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        // Tarefa 2: Validar a entrada da operação.
        // Primeiro, verificamos se a operação é nula.
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }
        // Em seguida, verificamos se está vazia.
        if (operation == string.Empty)
        {
            throw new ArgumentException("Operation cannot be an empty string.", nameof(operation));
        }

        // Tarefa 1: Implementar as operações e o tratamento de exceções.
        try
        {
            int result;
            // Usamos uma switch expression para determinar a operação e calcular o resultado.
            result = operation switch
            {
                "+" => operand1 + operand2,
                "*" => operand1 * operand2,
                "/" => operand1 / operand2,
                // Tarefa 2: Lançar exceção para operações inválidas.
                _ => throw new ArgumentOutOfRangeException(nameof(operation), "The operation is not supported.")
            };
            
            // Se o cálculo for bem-sucedido, formata a string de saída.
            return $"{operand1} {operation} {operand2} = {result}";
        }
        // Tarefa 3: Capturar a exceção específica de divisão por zero.
        catch (DivideByZeroException)
        {
            // Retorna a mensagem de erro personalizada.
            return "Division by zero is not allowed.";
        }
        // Nota: Outras exceções, como ArgumentOutOfRangeException, não são capturadas aqui.
        // Elas serão "lançadas para cima", saindo do método, como esperado pelo exercício.
    }
}
