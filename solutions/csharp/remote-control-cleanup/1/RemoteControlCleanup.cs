using System;

public class RemoteControlCar
{

    private Speed currentSpeed;
    private string currentSponsor = "Not-A-Sponsor";


    private enum SpeedUnits { Cps, Mps }
    private struct Speed
    {
        public decimal Amount;
        public SpeedUnits Units;
    }


    public TelemetryC Telemetry { get; }

    public RemoteControlCar()
    {

        this.Telemetry = new TelemetryC(this);
    }

    public string CurrentSponsor => this.currentSponsor;

    public string GetSpeed()
    {
        string unitsString = this.currentSpeed.Units switch
        {
            SpeedUnits.Cps => "centimeters per second",
            SpeedUnits.Mps => "meters per second",
            _ => "units per second"
        };
        return $"{this.currentSpeed.Amount} {unitsString}";
    }


    public class TelemetryC
    {
        private readonly RemoteControlCar car;

        internal TelemetryC(RemoteControlCar car)
        {
            this.car = car;
        }

        public void Calibrate() { }
        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName)
        {
            this.car.currentSponsor = sponsorName;
        }

        public void SetSpeed(decimal amount, string units)
        {
            SpeedUnits speedUnits = units.ToLower() == "cps" ? SpeedUnits.Cps : SpeedUnits.Mps;
            this.car.currentSpeed = new Speed { Amount = amount, Units = speedUnits };
        }
    }
}
