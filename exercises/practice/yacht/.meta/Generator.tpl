using System;
using Xunit;

public class YachtTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.Equal({{testCase.expected}}, YachtGame.Score({{testCase.input.dice}}, {{testCase.input.category | enum "YachtCategory"}}));
    }
    {{end}}
}
