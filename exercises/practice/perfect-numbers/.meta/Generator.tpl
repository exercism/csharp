using System;
using Xunit;

public class PerfectNumbersTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.shortMethodName}}()
    {
        {{if test.expected.error}}
        Assert.Throws<ArgumentOutOfRangeException>(() => PerfectNumbers.Classify({{test.input.number}}));
        {{else}}
        Assert.Equal({{test.expected | enum "Classification"}}, PerfectNumbers.Classify({{test.input.number}}));
        {{end}}
    }
    {{end}}
}
