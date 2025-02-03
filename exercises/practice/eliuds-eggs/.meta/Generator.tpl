using Xunit;

public class EliudsEggsTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected}}, EliudsEggs.EggCount({{test.input.number}}));
    }
    {{end}}
}
