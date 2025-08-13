using System;
using System.Collections.Generic;
using System.Linq; // Necessário para o método FindLongestCountryName

public static class DialingCodes
{
    // Tarefa 1: Retorna um dicionário vazio.
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    // Tarefa 2: Retorna um dicionário pré-populado.
    public static Dictionary<int, string> GetExistingDictionary()
    {
        return new Dictionary<int, string>
        {
            { 1, "United States of America" },
            { 55, "Brazil" },
            { 91, "India" }
        };
    }

    // Tarefa 3: Adiciona um país a um dicionário novo e vazio.
    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var newDictionary = new Dictionary<int, string>();
        newDictionary.Add(countryCode, countryName);
        return newDictionary;
    }

    // Tarefa 4: Adiciona um país a um dicionário existente.
    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    // Tarefa 5: Obtém o nome de um país a partir do seu código.
    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        // TryGetValue é a forma mais segura de tentar obter um valor.
        if (existingDictionary.TryGetValue(countryCode, out string countryName))
        {
            return countryName;
        }
        
        // Se a chave não foi encontrada, retorna uma string vazia.
        return string.Empty;
    }

    // Tarefa 6: Verifica se um código existe no dicionário.
    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        // ContainsKey é o método mais eficiente para verificar a existência de uma chave.
        return existingDictionary.ContainsKey(countryCode);
    }

    // Tarefa 7: Atualiza o nome de um país no dicionário.
    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        // Primeiro, verifica se a chave já existe.
        if (existingDictionary.ContainsKey(countryCode))
        {
            // A sintaxe de indexador é usada para atualizar um valor existente.
            existingDictionary[countryCode] = countryName;
        }
        // Se a chave não existir, o dicionário permanece inalterado.
        return existingDictionary;
    }

    // Tarefa 8: Remove um país do dicionário.
    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        // O método Remove exclui o par chave-valor.
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    // Tarefa 9: Encontra o nome de país mais longo no dicionário.
    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        // Se o dicionário estiver vazio, retorna uma string vazia.
        if (existingDictionary.Count == 0)
        {
            return string.Empty;
        }

        // Usa LINQ para encontrar o nome mais longo.
        return existingDictionary.Values.OrderByDescending(name => name.Length).First();
    }
}
