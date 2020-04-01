public class Lasagna
{
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int actualMinutesInOven) =>
        ExpectedMinutesInOven() - actualMinutesInOven;

    public int PreparationTimeInMinutes(int numberOfLayers) =>
        numberOfLayers * 2;

    public int TotalTimeInMinutes(int numberOfLayers, int actualMinutesInOven) =>
        PreparationTimeInMinutes(numberOfLayers) + actualMinutesInOven;
}