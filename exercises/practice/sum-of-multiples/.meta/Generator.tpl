using Xunit;

public class SumOfMultiplesTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.testMethodName}}()
    {
        Assert.Equal({{testCase.expected}}, SumOfMultiples.Sum({{testCase.input.factors}}, {{testCase.input.limit}}));
    }
    {{end}}
}
