using System;

class RemoteControlCar
{
    // Campos privados para armazenar as características e o estado do carro.
    private int _speed;
    private int _batteryDrain;
    private int _distanceDriven;
    private int _batteryPercentage;

    // Tarefa 1: Definir o construtor para a classe 'RemoteControlCar'.
    // Ele inicializa um carro com velocidade e consumo de bateria específicos.
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
        
        // Todos os carros começam com a bateria cheia e sem ter andado.
        _batteryPercentage = 100;
        _distanceDriven = 0;
    }

    // Tarefa 4: Implementar o método BatteryDrained().
    // Retorna true se a bateria for menor que o necessário para a próxima "Drive".
    public bool BatteryDrained()
    {
        return _batteryPercentage < _batteryDrain;
    }

    // Tarefa 3: Implementar o método DistanceDriven().
    // Retorna a distância total que o carro já percorreu.
    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    // Tarefa 3 e 4: Implementar o método Drive().
    // Atualiza a distância e a bateria, se houver carga suficiente.
    public void Drive()
    {
        // A condição de guarda impede que o carro ande se a bateria não for suficiente.
        if (!BatteryDrained())
        {
            _distanceDriven += _speed;
            _batteryPercentage -= _batteryDrain;
        }
    }

    // Tarefa 5: Implementar o método de fábrica estático Nitro().
    // Retorna uma instância de RemoteControlCar com características pré-definidas.
    public static RemoteControlCar Nitro()
    {
        // Cria um novo carro com velocidade 50 e consumo 4.
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    // Campo privado para armazenar a distância da pista.
    private int _distance;

    // Tarefa 2: Definir o construtor para a classe 'RaceTrack'.
    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    // Tarefa 6: Implementar o método TryFinishTrack().
    // Simula uma corrida e verifica se o carro consegue completar a distância da pista.
    public bool TryFinishTrack(RemoteControlCar car)
    {
        // Continua dirigindo o carro enquanto ele não tiver esgotado a bateria.
        while (!car.BatteryDrained())
        {
            car.Drive();
        }

        // Após a simulação (quando a bateria se esgota),
        // verifica se a distância percorrida pelo carro é maior ou igual à da pista.
        return car.DistanceDriven() >= _distance;
    }
}
