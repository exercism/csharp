using Xunit;

public class DartsTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal({{testCase.expected}}, Darts.Score({{testCase.input.x}}, {{testCase.input.y}}));
    }
    {{end}}
}
