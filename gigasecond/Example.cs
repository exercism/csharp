using System;

public class Gigasecond
{
    private readonly DateTime birthDate;

    public Gigasecond(DateTime birthDate)
    {
        this.birthDate = birthDate;
    }

    public DateTime Date()
    {
        return birthDate.AddSeconds(1000000000);
    }
}