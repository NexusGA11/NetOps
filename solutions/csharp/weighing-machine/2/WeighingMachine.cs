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
            double rawDisplayValue = this.Weight - this.TareAdjustment;
            

            double roundedDisplayValue = Math.Round(rawDisplayValue, this.Precision);
            
            string format = $"F{this.Precision}";
            return $"{roundedDisplayValue.ToString(format)} kg";
        }
    }

    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }
}
