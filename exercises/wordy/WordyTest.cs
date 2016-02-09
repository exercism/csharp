using NUnit.Framework;

[TestFixture]
public class WordProblemTest
{
    [Test]
    public void Can_parse_and_solve_addition_problems()
    {
        Assert.That(WordProblem.Solve("What is 1 plus 1?"), Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_double_digit_numbers()
    {
        Assert.That(WordProblem.Solve("What is 53 plus 2?"), Is.EqualTo(55));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_negative_numbers()
    {
        Assert.That(WordProblem.Solve("What is -1 plus -10?"), Is.EqualTo(-11));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_large_numbers()
    {
        Assert.That(WordProblem.Solve("What is 123 plus 45678?"), Is.EqualTo(45801));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_parse_and_solve_subtraction_problems()
    {
        Assert.That(WordProblem.Solve("What is 4 minus -12"), Is.EqualTo(16));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_parse_and_solve_multiplication_problems()
    {
        Assert.That(WordProblem.Solve("What is -3 multiplied by 25?"), Is.EqualTo(-75));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_parse_and_solve_division_problems()
    {
        Assert.That(WordProblem.Solve("What is 33 divided by -3?"), Is.EqualTo(-11));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_twice()
    {
        Assert.That(WordProblem.Solve("What is 1 plus 1 plus 1?"), Is.EqualTo(3));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_then_subtract()
    {
        Assert.That(WordProblem.Solve("What is 1 plus 5 minus -2?"), Is.EqualTo(8));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_subtract_twice()
    {
        Assert.That(WordProblem.Solve("What is 20 minus 4 minus 13?"), Is.EqualTo(3));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_subtract_then_add()
    {
        Assert.That(WordProblem.Solve("What is 17 minus 6 plus 3?"), Is.EqualTo(14));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_multiply_twice()
    {
        Assert.That(WordProblem.Solve("What is 2 multiplied by -2 multiplied by 3?"), Is.EqualTo(-12));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_add_then_multiply()
    {
        Assert.That(WordProblem.Solve("What is -3 plus 7 multiplied by -2?"), Is.EqualTo(-8));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_divide_twice()
    {
        Assert.That(WordProblem.Solve("What is -12 divided by 2 divided by -3?"), Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cubed_is_too_advanced()
    {
        Assert.That(() => WordProblem.Solve("What is 53 cubed?"), Throws.ArgumentException);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Irrelevent_problems_are_not_valid()
    {
        Assert.That(() => WordProblem.Solve("Who is the president of the United States?"), Throws.ArgumentException);
    }
}