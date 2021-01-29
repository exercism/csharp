// This file was auto-generated based on version 1.5.0 of the canonical data.

using System;
using Xunit;

public class WordyTests
{
    [Fact]
    public void Just_a_number()
    {
        Assert.Equal(5, Wordy.Answer("What is 5?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition()
    {
        Assert.Equal(2, Wordy.Answer("What is 1 plus 1?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void More_addition()
    {
        Assert.Equal(55, Wordy.Answer("What is 53 plus 2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition_with_negative_numbers()
    {
        Assert.Equal(-11, Wordy.Answer("What is -1 plus -10?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Large_addition()
    {
        Assert.Equal(45801, Wordy.Answer("What is 123 plus 45678?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtraction()
    {
        Assert.Equal(16, Wordy.Answer("What is 4 minus -12?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiplication()
    {
        Assert.Equal(-75, Wordy.Answer("What is -3 multiplied by 25?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Division()
    {
        Assert.Equal(-11, Wordy.Answer("What is 33 divided by -3?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_additions()
    {
        Assert.Equal(3, Wordy.Answer("What is 1 plus 1 plus 1?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition_and_subtraction()
    {
        Assert.Equal(8, Wordy.Answer("What is 1 plus 5 minus -2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_subtraction()
    {
        Assert.Equal(3, Wordy.Answer("What is 20 minus 4 minus 13?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtraction_then_addition()
    {
        Assert.Equal(14, Wordy.Answer("What is 17 minus 6 plus 3?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_multiplication()
    {
        Assert.Equal(-12, Wordy.Answer("What is 2 multiplied by -2 multiplied by 3?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition_and_multiplication()
    {
        Assert.Equal(-8, Wordy.Answer("What is -3 plus 7 multiplied by -2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_division()
    {
        Assert.Equal(2, Wordy.Answer("What is -12 divided by 2 divided by -3?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unknown_operation()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 52 cubed?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Non_math_question()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("Who is the President of the United States?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reject_problem_missing_an_operand()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 plus?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reject_problem_with_no_operands_or_operators()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reject_two_operations_in_a_row()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 plus plus 2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reject_two_numbers_in_a_row()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 plus 2 1?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reject_postfix_notation()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 2 plus?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reject_prefix_notation()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is plus 1 2?"));
    }
}