using Xunit;

public class SumOfMultiplesTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected}}, SumOfMultiples.Sum({{test.input.factors}}, {{test.input.limit}}));
    }
    {{end}}
}
