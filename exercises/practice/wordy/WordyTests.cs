using Xunit;

public class WordyTests
{
    [Fact]
    public void JustANumber()
    {
        Assert.Equal(5, Wordy.Answer("What is 5?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition()
    {
        Assert.Equal(2, Wordy.Answer("What is 1 plus 1?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MoreAddition()
    {
        Assert.Equal(55, Wordy.Answer("What is 53 plus 2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AdditionWithNegativeNumbers()
    {
        Assert.Equal(-11, Wordy.Answer("What is -1 plus -10?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void LargeAddition()
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
    public void MultipleAdditions()
    {
        Assert.Equal(3, Wordy.Answer("What is 1 plus 1 plus 1?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AdditionAndSubtraction()
    {
        Assert.Equal(8, Wordy.Answer("What is 1 plus 5 minus -2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MultipleSubtraction()
    {
        Assert.Equal(3, Wordy.Answer("What is 20 minus 4 minus 13?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SubtractionThenAddition()
    {
        Assert.Equal(14, Wordy.Answer("What is 17 minus 6 plus 3?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MultipleMultiplication()
    {
        Assert.Equal(-12, Wordy.Answer("What is 2 multiplied by -2 multiplied by 3?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void AdditionAndMultiplication()
    {
        Assert.Equal(-8, Wordy.Answer("What is -3 plus 7 multiplied by -2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void MultipleDivision()
    {
        Assert.Equal(2, Wordy.Answer("What is -12 divided by 2 divided by -3?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void UnknownOperation()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 52 cubed?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void NonMathQuestion()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("Who is the President of the United States?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RejectProblemMissingAnOperand()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 plus?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RejectProblemWithNoOperandsOrOperators()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RejectTwoOperationsInARow()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 plus plus 2?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RejectTwoNumbersInARow()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 plus 2 1?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RejectPostfixNotation()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is 1 2 plus?"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RejectPrefixNotation()
    {
        Assert.Throws<ArgumentException>(() => Wordy.Answer("What is plus 1 2?"));
    }
}
