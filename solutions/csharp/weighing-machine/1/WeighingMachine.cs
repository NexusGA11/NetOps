using System;

public class WeighingMachine
{
    private double _weight;

    public int Precision { get; }

    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative.");
            }
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight
    {
        get
        {
            double displayValue = Weight - TareAdjustment;
            string format = $"F{Precision}";
            return $"{displayValue.ToString(format)} kg";
        }
    }

    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }
}
