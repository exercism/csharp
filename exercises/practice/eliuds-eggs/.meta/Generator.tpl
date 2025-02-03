using Xunit;

public class EliudsEggsTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal({{testCase.expected}}, EliudsEggs.EggCount({{testCase.input.number}}));
    }
    {{end}}
}
