// As definições das classes e do enum permanecem as mesmas.
public class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

public class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

public enum TravelMethod
{
    Walking,
    Horseback
}

public static class GameMaster
{
    // Os outros métodos não precisam de alteração.
    public static string Describe(Character character)
    {
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    // --- CORREÇÃO APLICADA AQUI ---
    // Descreve um método de viagem.
    public static string Describe(TravelMethod travelMethod)
    {
        // A lógica agora gera a frase completa e correta para cada caso.
        string travelDescription = travelMethod switch
        {
            // Adicionada a preposição "by" para o caso 'Walking'.
            TravelMethod.Walking => "by walking", 
            TravelMethod.Horseback => "on horseback",
            _ => "by unknown means"
        };
        return $"You're traveling to your destination {travelDescription}.";
    }

    // Este método agora funcionará corretamente, pois depende da correção acima.
    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
        return $"{Describe(character)} {Describe(travelMethod)} {Describe(destination)}";
    }

    // Este método também funcionará, pois chama a versão corrigida.
    public static string Describe(Character character, Destination destination)
    {
        return Describe(character, destination, TravelMethod.Walking);
    }
}
