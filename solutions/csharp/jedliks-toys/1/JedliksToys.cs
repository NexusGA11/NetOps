using System;

public class RemoteControlCar
{
    // Campos privados para armazenar o estado do carro.
    private int _batteryPercentage;
    private int _distanceDriven;

    // Construtor PÚBLICO.
    // Os testes do Exercism precisam de acesso direto para criar instâncias.
    // O carro ainda começa com a bateria cheia e distância zero por padrão.
    public RemoteControlCar()
    {
        _batteryPercentage = 100;
        _distanceDriven = 0;
    }

    // Tarefa 1: Método de fábrica estático.
    // Embora os testes não o usem sempre, ele ainda é parte do requisito.
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    // Tarefa 2: Exibição da distância.
    public string DistanceDisplay()
    {
        return $"Driven {_distanceDriven} meters";
    }

    // Tarefa 3: Exibição da bateria.
    public string BatteryDisplay()
    {
        if (_batteryPercentage == 0)
        {
            return "Battery empty";
        }
        
        return $"Battery at {_batteryPercentage}%";
    }

    // Tarefa 4, 5 e 6: Lógica de dirigir.
    public void Drive()
    {
        // Se a bateria estiver vazia, não faz nada.
        if (_batteryPercentage > 0)
        {
            _distanceDriven += 20;
            _batteryPercentage -= 1;
        }
    }
}
