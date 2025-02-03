using System;
using Xunit;

public class YachtTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.Equal({{test.expected}}, YachtGame.Score({{test.input.dice}}, {{test.input.category | enum "YachtCategory"}}));
    }
    {{end}}
}
