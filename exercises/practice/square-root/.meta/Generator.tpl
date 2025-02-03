using Xunit;

public class SquareRootTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal({{testCase.expected}}, SquareRoot.Root({{testCase.input.radicand}}));
    }
    {{end}}
}
