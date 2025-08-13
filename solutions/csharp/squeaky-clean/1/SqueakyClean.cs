using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        // Se a string de entrada for vazia, retorna uma string vazia.
        if (string.IsNullOrEmpty(identifier))
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        bool capitalizeNext = false;

        foreach (char c in identifier)
        {
            // Tarefa 1: Substituir espaços por underscores.
            if (c == ' ')
            {
                sb.Append('_');
                continue;
            }

            // Tarefa 2: Substituir caracteres de controle por "CTRL".
            if (char.IsControl(c))
            {
                sb.Append("CTRL");
                continue;
            }

            // Tarefa 3: Converter kebab-case para camelCase.
            if (c == '-')
            {
                capitalizeNext = true;
                continue;
            }

            // Tarefa 5: Omitir letras gregas minúsculas (α a ω).
            if (c >= 'α' && c <= 'ω')
            {
                continue;
            }

            // Tarefa 4: Incluir apenas caracteres que são letras.
            if (char.IsLetter(c))
            {
                if (capitalizeNext)
                {
                    sb.Append(char.ToUpper(c));
                    capitalizeNext = false;
                }
                else
                {
                    sb.Append(c);
                }
            }
            // Qualquer outro caractere (números, emojis, etc.) é ignorado.
        }

        return sb.ToString();
    }
}
