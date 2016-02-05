using System;
using System.Collections.Generic;

public class SpaceAge
{
    private enum Planet
    {
        Earth, Mercury, Venus, Mars, Jupiter, Saturn, Uranus, Neptune
    }

    public long Seconds { get; private set; }

    private readonly Dictionary<Planet, decimal> earthYearToPlanetPeriod = new Dictionary<Planet, decimal>
        {
            { Planet.Earth, 1 },
            { Planet.Mercury, 0.2408467m },
            { Planet.Venus, 0.61519726m },
            { Planet.Mars, 1.8808158m },
            { Planet.Jupiter, 11.862615m },
            { Planet.Saturn, 29.447498m },
            { Planet.Uranus, 84.016846m },
            { Planet.Neptune, 164.79132m },
        };

    public SpaceAge(long seconds)
    {
        Seconds = seconds;
    }

    private decimal CalculateAge(decimal periodInEarthYears)
    {
        const decimal EARTH_ORBIT_IN_SECONDS = 31557600;
        return Math.Round(Seconds / (EARTH_ORBIT_IN_SECONDS * periodInEarthYears), 2);
    }

    public decimal OnEarth()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Earth]);
    }

    public decimal OnMercury()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Mercury]);
    }

    public decimal OnVenus()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Venus]);
    }

    public decimal OnMars()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Mars]);
    }

    public decimal OnJupiter()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Jupiter]);
    }

    public decimal OnSaturn()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Saturn]);
    }

    public decimal OnUranus()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Uranus]);
    }

    public decimal OnNeptune()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Neptune]);
    }
}