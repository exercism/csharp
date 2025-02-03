using Xunit;

public class SquareRootTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected}}, SquareRoot.Root({{test.input.radicand}}));
    }
    {{end}}
}
