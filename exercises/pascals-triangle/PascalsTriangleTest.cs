﻿using System.Linq;
using Xunit;

public class PascalsTriangleTest
{
    [Fact]
    public void One_row()
    {
        var actual = PascalsTriangle.Calculate(1);
        Assert.Equal(new[] { new[] { 1 } }, actual);
    }
    
    [Fact(Skip="Remove to run test")]
    public void Two_rows()
    {
        var actual = PascalsTriangle.Calculate(2);
        Assert.Equal(new[] { new[] { 1 }, new[] { 1, 1 } }, actual);
    }

    [Fact(Skip="Remove to run test")]
    public void Three_rows()
    {
        var actual = PascalsTriangle.Calculate(3);
        Assert.Equal(new[] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 } }, actual);
    }

    [Fact(Skip="Remove to run test")]
    public void Four_rows()
    {
        var actual = PascalsTriangle.Calculate(4);
        Assert.Equal(new[] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 } }, actual);
    }

    [Fact(Skip="Remove to run test")]
    public void Five_rows()
    {
        var actual = PascalsTriangle.Calculate(5);
        Assert.Equal(new[] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 }, new [] { 1, 4, 6, 4, 1 } }, actual);
    }

    [Fact(Skip="Remove to run test")]
    public void Twenty_rows()
    {
        var actual = PascalsTriangle.Calculate(20).Last();
        Assert.Equal(new[] { 1, 19, 171, 969, 3876, 11628, 27132, 50388, 75582, 92378, 92378, 75582, 50388, 27132, 11628, 3876, 969, 171, 19, 1 }, actual);
    }
}