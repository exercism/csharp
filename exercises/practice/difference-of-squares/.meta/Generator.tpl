using Xunit;

public class DifferenceOfSquaresTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.shortTestMethodName}}()
    {
        Assert.Equal({{testCase.expected}}, DifferenceOfSquares.Calculate{{testCase.property | string.capitalize}}({{testCase.input.number}}));
    }
    {{end}}
}
