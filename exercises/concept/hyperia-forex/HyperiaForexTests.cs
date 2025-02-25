using FsCheck;

using Exercism.Tests;

using FsCheck.Fluent;

public class HyperiaForexTests
{
    [Fact]
    [Task(1)]
    public void Equality_with_same_currency()
    {
        Prop.ForAll<decimal>(value =>
        {
            var amount1 = new CurrencyAmount(value, "HD");
            var amount2 = new CurrencyAmount(value, "HD");

            Assert.True(amount1 == amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(1)]
    public void Equality_with_different_currency()
    {
        Prop.ForAll<decimal>(value =>
        {
            var amount1 = new CurrencyAmount(value, "HD");
            var amount2 = new CurrencyAmount(value, "USD");

            Assert.Throws<ArgumentException>(() => amount1 == amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(1)]
    public void Inequality_with_same_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "HD");

            return Prop.When(values.Item1 != values.Item2, () => Assert.True(amount1 != amount2));
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(1)]
    public void Inequality_with_different_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "USD");

            Assert.Throws<ArgumentException>(() => amount1 != amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(2)]
    public void LessThan_with_same_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "HD");

            return Prop.When(values.Item1 < values.Item2, () => Assert.True(amount1 < amount2));
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(2)]
    public void LessThan_with_different_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "USD");

            Assert.Throws<ArgumentException>(() => amount1 < amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(2)]
    public void GreaterThan_with_same_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "HD");

            return Prop.When(values.Item1 > values.Item2, () => Assert.True(amount1 > amount2));
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(2)]
    public void GreaterThan_with_different_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "USD");

            Assert.Throws<ArgumentException>(() => amount1 > amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(3)]
    public void Addition_with_same_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "HD");
            var expected = new CurrencyAmount(values.Item1 + values.Item2, "HD");

            Assert.Equal(expected, amount1 + amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(3)]
    public void Addition_is_commutative()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "HD");

            Assert.Equal(amount1 + amount2, amount2 + amount1);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(3)]
    public void Addition_with_different_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "USD");

            Assert.Throws<ArgumentException>(() => amount1 + amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(3)]
    public void Subtraction_with_same_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "HD");
            var expected = new CurrencyAmount(values.Item1 - values.Item2, "HD");

            Assert.Equal(expected, amount1 - amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(3)]
    public void Subtraction_with_different_currency()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var amount1 = new CurrencyAmount(values.Item1, "HD");
            var amount2 = new CurrencyAmount(values.Item2, "USD");

            Assert.Throws<ArgumentException>(() => amount1 - amount2);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(4)]
    public void Multiplication()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var (value, factor) = values;
            Assert.Equal(new CurrencyAmount(factor * value, "HD"),
                factor * new CurrencyAmount(value, "HD"));
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(4)]
    public void Multiplication_is_commutative()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var (value, factor) = values;
            var amount = new CurrencyAmount(value, "HD");

            Assert.Equal(amount * factor, factor * amount);
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(4)]
    public void Division()
    {
        Prop.ForAll<(decimal, decimal)>(values =>
        {
            var (value, divisor) = values;
            return Prop.When(
                divisor != 0,
                () => Assert.True(new CurrencyAmount(value, "HD") / divisor ==
                                  new CurrencyAmount(value / divisor, "HD")));
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(5)]
    public void Cast_to_double()
    {
        Prop.ForAll<decimal>(value =>
        {
            Assert.Equal(Convert.ToDouble(value), (double)new CurrencyAmount(value, "HD"));
        }).QuickCheckThrowOnFailure();
    }

    [Fact]
    [Task(6)]
    public void Cast_to_decimal()
    {
        Prop.ForAll<decimal>(value =>
        {
            decimal actual = new CurrencyAmount(value, "HD");
            Assert.Equal(value, actual);
        }).QuickCheckThrowOnFailure();
    }
}