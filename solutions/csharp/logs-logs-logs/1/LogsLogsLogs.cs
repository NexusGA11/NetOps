using System;

// Tarefa 1 e 3: Definir o enum 'LogLevel'.
// Adicionamos os valores explícitos para a tarefa de formatação do log curto.
public enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    // Tarefa 2: Implementar o método ParseLogLevel().
    public static LogLevel ParseLogLevel(string logLine)
    {
        // Extrai o código de 3 letras de dentro dos colchetes.
        // logLine.Substring(1, 3) começa no índice 1 (após o '[') e pega 3 caracteres.
        string levelCode = logLine.Substring(1, 3);

        // Usa uma 'switch expression' para mapear o código para o enum correspondente.
        // É uma forma moderna e concisa de fazer um 'switch-case'.
        return levelCode switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            // O caso padrão '_' captura qualquer outro valor.
            _ => LogLevel.Unknown,
        };
    }

    // Tarefa 4: Implementar o método OutputForShortLog().
    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        // Converte o valor do enum para seu número inteiro subjacente.
        // Como definimos os valores no enum, a conversão (int)logLevel
        // retornará o número correto (ex: (int)LogLevel.Error retorna 6).
        int encodedLevel = (int)logLevel;

        // Usa interpolação de string para formatar a saída.
        return $"{encodedLevel}:{message}";
    }
}
