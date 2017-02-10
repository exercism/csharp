using System;
using Xunit;

public class WordProblemTest
{
    [Fact]
    public void Can_parse_and_solve_addition_problems()
    {
        Assert.Equal(2, WordProblem.Solve("What is 1 plus 1?"));
    }

    [Fact]
    public void Can_add_double_digit_numbers()
    {
        Assert.Equal(55, WordProblem.Solve("What is 53 plus 2?"));
    }

    [Fact]
    public void Can_add_negative_numbers()
    {
        Assert.Equal(-11, WordProblem.Solve("What is -1 plus -10?"));
    }

    [Fact]
    public void Can_add_large_numbers()
    {
        Assert.Equal(45801, WordProblem.Solve("What is 123 plus 45678?"));
    }

    [Fact]
    public void Can_parse_and_solve_subtraction_problems()
    {
        Assert.Equal(16, WordProblem.Solve("What is 4 minus -12"));
    }

    [Fact]
    public void Can_parse_and_solve_multiplication_problems()
    {
        Assert.Equal(-75, WordProblem.Solve("What is -3 multiplied by 25?"));
    }

    [Fact]
    public void Can_parse_and_solve_division_problems()
    {
        Assert.Equal(-11, WordProblem.Solve("What is 33 divided by -3?"));
    }

    [Fact]
    public void Can_add_twice()
    {
        Assert.Equal(3, WordProblem.Solve("What is 1 plus 1 plus 1?"));
    }

    [Fact]
    public void Can_add_then_subtract()
    {
        Assert.Equal(8, WordProblem.Solve("What is 1 plus 5 minus -2?"));
    }

    [Fact]
    public void Can_subtract_twice()
    {
        Assert.Equal(3, WordProblem.Solve("What is 20 minus 4 minus 13?"));
    }

    [Fact]
    public void Can_subtract_then_add()
    {
        Assert.Equal(14, WordProblem.Solve("What is 17 minus 6 plus 3?"));
    }

    [Fact]
    public void Can_multiply_twice()
    {
        Assert.Equal(-12, WordProblem.Solve("What is 2 multiplied by -2 multiplied by 3?"));
    }

    [Fact]
    public void Can_add_then_multiply()
    {
        Assert.Equal(-8, WordProblem.Solve("What is -3 plus 7 multiplied by -2?"));
    }

    [Fact]
    public void Can_divide_twice()
    {
        Assert.Equal(2, WordProblem.Solve("What is -12 divided by 2 divided by -3?"));
    }

    [Fact]
    public void Cubed_is_too_advanced()
    {
        Assert.Throws<ArgumentException>(() => WordProblem.Solve("What is 53 cubed?"));
    }

    [Fact]
    public void Irrelevant_problems_are_not_valid()
    {
        Assert.Throws<ArgumentException>(() => WordProblem.Solve("Who is the president of the United States?"));
    }
}
