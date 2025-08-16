using System;

public static class AssemblyLine
{
    private const int BaseProductionRate = 221;

    public static double SuccessRate(int speed)
    {
        if (speed == 0)
        {
            return 0.0;
        }
        else if (speed >= 1 && speed <= 4)
        {
            return 1.0;
        }
        else if (speed >= 5 && speed <= 8)
        {
            return 0.9;
        }
        else if (speed == 9)
        {
            return 0.8;
        }
        else if (speed == 10)
        {
            return 0.77;
        }
        

        return 0.0;
    }
    

    public static double ProductionRatePerHour(int speed)
    {

        double successRate = SuccessRate(speed);
        double theoreticalProduction = speed * BaseProductionRate;
        
        return theoreticalProduction * successRate;
    }


    public static int WorkingItemsPerMinute(int speed)
    {

        double productionPerHour = ProductionRatePerHour(speed);
        double itemsPerMinute = productionPerHour / 60.0;
        
        return (int)itemsPerMinute;
    }
}
