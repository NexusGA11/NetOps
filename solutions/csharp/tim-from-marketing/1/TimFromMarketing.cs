using System;
using System.Collections.Generic;

public static class Badge
{
    public static string Print(int? id, string name, string? department)
    {

        // Usa o operador de coalescência nula (??) para substituir 'null' por "OWNER".
        // Em seguida, converte o resultado para maiúsculas.
        string departmentLabel = (department ?? "OWNER").ToUpper();


        // Se o ID não for nulo, formata a string com o prefixo.
        // Se for nulo, a string fica vazia.
        string idLabel = id.HasValue ? $"[{id}] - " : "";


        // Concatena a parte do ID (que pode estar vazia), o nome e a parte do departamento.
        return $"{idLabel}{name} - {departmentLabel}";
    }
}
