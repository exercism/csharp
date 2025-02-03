using Xunit;

public class DifferenceOfSquaresTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.shortMethodName}}()
    {
        Assert.Equal({{test.expected}}, DifferenceOfSquares.Calculate{{test.property | string.capitalize}}({{test.input.number}}));
    }
    {{end}}
}
