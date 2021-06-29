using System;
using Xunit;

public class CollatzConjectureTests
{
    [Fact]
    public void Zero_steps_for_one()
    {
        Assert.Equal(0, CollatzConjecture.Steps(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Divide_if_even()
    {
        Assert.Equal(4, CollatzConjecture.Steps(16));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Even_and_odd_steps()
    {
        Assert.Equal(9, CollatzConjecture.Steps(12));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Large_number_of_even_and_odd_steps()
    {
        Assert.Equal(152, CollatzConjecture.Steps(1000000));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Zero_is_an_error()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CollatzConjecture.Steps(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_value_is_an_error()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CollatzConjecture.Steps(-15));
    }
}