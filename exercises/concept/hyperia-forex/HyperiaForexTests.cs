using System;
using Xunit;
using FsCheck.Xunit;
using FsCheck;
using Exercism.Tests;

public class HyperiaForexTests
{
    [Property]
    [Task(1)]
    public void Equality_with_same_currency(decimal value)
    {
        var amount1 = new CurrencyAmount(value, "HD");
        var amount2 = new CurrencyAmount(value, "HD");

        Assert.True(amount1 == amount2);
    }

    [Property]
    [Task(1)]
    public void Equality_with_different_currency(decimal value)
    {
        var amount1 = new CurrencyAmount(value, "HD");
        var amount2 = new CurrencyAmount(value, "USD");

        Assert.Throws<ArgumentException>(() => amount1 == amount2);
    }

    [Property]
    [Task(1)]
    public Property Inequality_with_same_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "HD");

        return Prop.When(value1 != value2, () => Assert.True(amount1 != amount2));
    }

    [Property]
    [Task(1)]
    public void Inequality_with_different_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "USD");

        Assert.Throws<ArgumentException>(() => amount1 != amount2);
    }

    [Property]
    [Task(2)]
    public Property LessThan_with_same_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "HD");

        return Prop.When(value1 < value2, () => Assert.True(amount1 < amount2));
    }

    [Property]
    [Task(2)]
    public void LessThan_with_different_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "USD");

        Assert.Throws<ArgumentException>(() => amount1 < amount2);
    }

    [Property]
    [Task(2)]
    public Property GreaterThan_with_same_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "HD");

        return Prop.When(value1 > value2, () => Assert.True(amount1 > amount2));
    }

    [Property]
    [Task(2)]
    public void GreaterThan_with_different_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "USD");

        Assert.Throws<ArgumentException>(() => amount1 > amount2);
    }

    [Property]
    [Task(3)]
    public void Addition_with_same_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "HD");
        var expected = new CurrencyAmount(value1 + value2, "HD");

        Assert.Equal(expected, amount1 + amount2);
    }

    [Property]
    [Task(3)]
    public void Addition_is_commutative(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "HD");

        Assert.Equal(amount1 + amount2, amount2 + amount1);
    }

    [Property]
    [Task(3)]
    public void Addition_with_different_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "USD");

        Assert.Throws<ArgumentException>(() => amount1 + amount2);
    }

    [Property]
    [Task(3)]
    public void Subtraction_with_same_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "HD");
        var expected = new CurrencyAmount(value1 - value2, "HD");

        Assert.Equal(expected, amount1 - amount2);
    }

    [Property]
    [Task(3)]
    public void Subtraction_with_different_currency(decimal value1, decimal value2)
    {
        var amount1 = new CurrencyAmount(value1, "HD");
        var amount2 = new CurrencyAmount(value2, "USD");

        Assert.Throws<ArgumentException>(() => amount1 - amount2);
    }

    [Property]
    [Task(4)]
    public void Multiplication(decimal value, decimal factor)
    {
        Assert.Equal(new CurrencyAmount(factor * value, "HD"),
                     factor * new CurrencyAmount(value, "HD"));
    }

    [Property]
    [Task(4)]
    public void Multiplication_is_commutative(decimal value, decimal factor)
    {
        var amount = new CurrencyAmount(value, "HD");

        Assert.Equal(amount * factor, factor * amount);
    }

    [Property]
    [Task(4)]
    public Property Division(decimal value, decimal divisor)
    {
        return Prop.When(
            divisor != 0,
            () => Assert.True(new CurrencyAmount(value, "HD") / divisor ==
                              new CurrencyAmount(value / divisor, "HD")));
    }

    [Property]
    [Task(5)]
    public void Cast_to_double(decimal value)
    {
        Assert.Equal(Convert.ToDouble(value), (double)new CurrencyAmount(value, "HD"));
    }

    [Property]
    [Task(6)]
    public void Cast_to_decimal(decimal value)
    {
        decimal actual = new CurrencyAmount(value, "HD");
        Assert.Equal(value, actual);
    }
}
