using System;
using System.Collections.Generic;

// 1. Definição da interface com os membros comuns a todos os carros.
public interface IRemoteControlCar
{
    // Propriedade para a distância percorrida.
    int DistanceTravelled { get; }

    // Método para dirigir.
    void Drive();
}

// 2. Implementação para o carro de produção.
// Esta classe implementa a interface do carro e a interface de comparação.
public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    // O carro de produção avança 10 unidades.
    public void Drive()
    {
        this.DistanceTravelled += 10;
    }

    // 3. Implementação do método de comparação para ordenação.
    // A ordenação é baseada no número de vitórias (ordem ascendente).
    public int CompareTo(ProductionRemoteControlCar other)
    {
        // Delega a comparação para o método CompareTo do tipo 'int'.
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

// Implementação para o carro experimental.
public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    // O carro experimental avança 20 unidades.
    public void Drive()
    {
        this.DistanceTravelled += 20;
    }
}

// Classe estática que representa a pista de testes.
public static class TestTrack
{
    // O método Race aceita qualquer objeto que implemente IRemoteControlCar.
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    // 4. Implementação do método de ranking.
    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1, ProductionRemoteControlCar prc2)
    {
        var cars = new List<ProductionRemoteControlCar> { prc1, prc2 };
        
        // O método Sort() usa a implementação de CompareTo da classe para ordenar a lista.
        cars.Sort();
        
        return cars;
    }
}
