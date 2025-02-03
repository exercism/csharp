using System;
using Xunit;

public class HammingTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        {{if testCase.expected.error}}
        Assert.Throws<ArgumentException>(() => Hamming.Distance({{testCase.input.strand1 | string.literal}}, {{testCase.input.strand2 | string.literal}}));
        {{else}}
        Assert.Equal({{testCase.expected}}, Hamming.Distance({{testCase.input.strand1 | string.literal}}, {{testCase.input.strand2 | string.literal}}));
        {{end}}
    }
    {{end}}
}
