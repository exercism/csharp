using Xunit;

public class DartsTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected}}, Darts.Score({{test.input.x}}, {{test.input.y}}));
    }
    {{end}}
}
