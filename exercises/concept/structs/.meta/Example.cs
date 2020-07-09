using System;
using System.Collections.Generic;
using System.Reflection;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord topLeft, Coord topRight, Coord bottomLeft, Coord bottomRight)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
    }

    public Coord TopLeft { get; }
    public Coord TopRight { get; }
    public Coord BottomLeft { get; }
    public Coord BottomRight { get; }

    public ushort GetLongestSide()
    {
        return (ushort)Math.Max(
            TopRight.X - TopLeft.X,
            Math.Max(BottomRight.X - BottomLeft.X,
                Math.Max(BottomRight.Y - TopRight.Y
                    ,BottomLeft.Y - TopLeft.Y)));
    }
}

public class ClaimsHandler
{
    private ISet<Plot> plots = new HashSet<Plot>();
    private Plot lastClaim;

    public void StakeClaim(Plot plot)
    {
        lastClaim = plot;
        plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return plots.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return lastClaim.Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot longest = new Plot();
        foreach (Plot plot in plots)
        {
            if (plot.GetLongestSide() > longest.GetLongestSide())
            {
                longest = plot;
            }
        }

        return longest;
    }
}
