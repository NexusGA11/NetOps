using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    // 1. Retorna uma nova lista vazia de strings.
    public static List<string> NewList()
    {
        return new List<string>();
    }

    // 2. Retorna uma lista pré-populada com três linguagens.
    public static List<string> GetExistingLanguages()
    {
        return new List<string> { "C#", "Clojure", "Elm" };
    }

    // 3. Adiciona uma nova linguagem ao final da lista.
    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    // 4. Retorna o número de elementos na lista.
    public static int CountLanguages(List<string> languages)
    {
        // A propriedade 'Count' é a forma mais eficiente de obter o tamanho.
        return languages.Count;
    }

    // 5. Verifica se a lista contém uma linguagem específica.
    public static bool HasLanguage(List<string> languages, string language)
    {
        // O método 'Contains' é otimizado para esta verificação.
        return languages.Contains(language);
    }

    // 6. Inverte a ordem dos elementos na lista.
    public static List<string> ReverseList(List<string> languages)
    {
        // O método 'Reverse' modifica a lista original (in-place).
        languages.Reverse();
        return languages;
    }

    // 7. Verifica se a lista atende aos critérios de "empolgante".
    public static bool IsExciting(List<string> languages)
    {
        // Verifica a primeira condição: C# é o primeiro item.
        if (languages.Count > 0 && languages[0] == "C#")
        {
            return true;
        }

        // Verifica a segunda condição: C# é o segundo e a lista tem 2 ou 3 itens.
        if (languages.Count >= 2 && languages.Count <= 3 && languages[1] == "C#")
        {
            return true;
        }

        // Se nenhuma condição for atendida.
        return false;
    }

    // 8. Remove uma linguagem específica da lista.
    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    // 9. Verifica se todos os elementos na lista são únicos.
    public static bool IsUnique(List<string> languages)
    {
        // Uma forma eficiente de verificar a unicidade é comparar a contagem
        // total com a contagem de elementos distintos.
        // O método 'Distinct()' do LINQ cria uma nova sequência sem duplicatas.
        return languages.Count == languages.Distinct().Count();
    }
}
