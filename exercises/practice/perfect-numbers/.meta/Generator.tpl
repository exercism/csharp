using System;
using Xunit;

public class PerfectNumbersTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.shortMethodName}}()
    {
        {{if testCase.expected.error}}
        Assert.Throws<ArgumentOutOfRangeException>(() => PerfectNumbers.Classify({{testCase.input.number}}));
        {{else}}
        Assert.Equal({{testCase.expected | enum "Classification"}}, PerfectNumbers.Classify({{testCase.input.number}}));
        {{end}}
    }
    {{end}}
}
