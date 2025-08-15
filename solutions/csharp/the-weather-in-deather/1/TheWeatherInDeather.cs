using System;
using System.Collections.Generic;
using System.Linq;

public class WeatherStation
{
    private Reading reading;
    private List<DateTime> recordDates = new List<DateTime>();
    private List<decimal> temperatures = new List<decimal>();

    public void AcceptReading(Reading reading)
    {
        this.reading = reading;
        recordDates.Add(DateTime.Now);
        temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        reading = new Reading();
        recordDates.Clear();
        temperatures.Clear();
    }

    // Propriedades get-only refatoradas com corpos de expressão.
    public decimal LatestTemperature => reading.Temperature;

    public decimal LatestPressure => reading.Pressure;

    public decimal LatestRainfall => reading.Rainfall;

    // Propriedade booleana refatorada para uma única expressão.
    public bool HasHistory => recordDates.Count > 1;

    // Propriedade refatorada com a ORDEM CORRIGIDA na switch expression.
    public Outlook ShortTermOutlook => reading switch
    {
        // 1. PRIMEIRO, verificamos a condição de erro.
        // Se a leitura for a padrão/vazia, lança a exceção.
        var r when r.Equals(new Reading()) => throw new ArgumentException(),

        // 2. AGORA, com a certeza de que a leitura é válida, verificamos as outras condições.
        var r when r.Pressure < 10m && r.Temperature < 30m => Outlook.Cool,
        var r when r.Temperature > 50m => Outlook.Good,
        
        // 3. O caso padrão agora lida com todas as outras leituras válidas.
        _ => Outlook.Warm
    };

    // Propriedade refatorada com switch expression para maior clareza.
    public Outlook LongTermOutlook => reading.WindDirection switch
    {
        WindDirection.Southerly => Outlook.Good,
        WindDirection.Easterly when reading.Temperature > 20 => Outlook.Good,
        WindDirection.Easterly => Outlook.Warm, // Se o 'when' anterior falhou, a temp é <= 20.
        WindDirection.Northerly => Outlook.Cool,
        WindDirection.Westerly => Outlook.Rainy,
        // O caso padrão captura WindDirection.Unknown ou qualquer outro caso inesperado.
        _ => throw new ArgumentException()
    };

    // Método refatorado com o operador ternário.
    public State RunSelfTest() => reading.Equals(new Reading()) ? State.Bad : State.Good;
}

/*** Por favor, não modifique esta struct ***/
public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

/*** Por favor, não modifique este enum ***/
public enum State
{
    Good,
    Bad
}

/*** Por favor, não modifique este enum ***/
public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}

/*** Por favor, não modifique este enum ***/
public enum WindDirection
{
    Unknown, // default
    Northerly,
    Easterly,
    Southerly,
    Westerly
}
