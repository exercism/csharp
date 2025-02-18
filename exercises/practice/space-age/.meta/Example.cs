using System;
using System.Collections.Generic;

public class SpaceAge
{
    private enum Planet
    {
        Earth, Mercury, Venus, Mars, Jupiter, Saturn, Uranus, Neptune
    }

    private readonly int seconds;

    private readonly Dictionary<Planet, double> earthYearToPlanetPeriod = new Dictionary<Planet, double>
        {
            { Planet.Earth, 1 },
            { Planet.Mercury, 0.2408467 },
            { Planet.Venus, 0.61519726 },
            { Planet.Mars, 1.8808158 },
            { Planet.Jupiter, 11.862615 },
            { Planet.Saturn, 29.447498 },
            { Planet.Uranus, 84.016846 },
            { Planet.Neptune, 164.79132 },
        };

    public SpaceAge(int seconds)
    {
        this.seconds = seconds;
    }

    private double CalculateAge(double periodInEarthYears)
    {
        const double EARTH_ORBIT_IN_SECONDS = 31557600;
        return Math.Round(seconds / (EARTH_ORBIT_IN_SECONDS * periodInEarthYears), 2);
    }

    public double OnEarth()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Earth]);
    }

    public double OnMercury()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Mercury]);
    }

    public double OnVenus()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Venus]);
    }

    public double OnMars()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Mars]);
    }

    public double OnJupiter()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Jupiter]);
    }

    public double OnSaturn()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Saturn]);
    }

    public double OnUranus()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Uranus]);
    }

    public double OnNeptune()
    {
        return CalculateAge(earthYearToPlanetPeriod[Planet.Neptune]);
    }
}