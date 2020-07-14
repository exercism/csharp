public class RemoteControlCar
{
    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }

    public interface ITelemetry
    {
        void Calibrate();
        bool SelfTest();
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string units);
    }

    private class TelemetryImpl : ITelemetry
    {
        private RemoteControlCar thisCar;
        public TelemetryImpl(RemoteControlCar car)
        {
            thisCar = car;
        }
        public void Calibrate()
        {
        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            thisCar.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }
            thisCar.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public ITelemetry Telemetry { get; }
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public RemoteControlCar()
    {
        Telemetry = new TelemetryImpl(this);
    }

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}
