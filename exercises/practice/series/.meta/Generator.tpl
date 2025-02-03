using System;
using Xunit;

public class SeriesTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        {{if testCase.expected.error}}
        Assert.Throws<ArgumentException>(() => Series.Slices({{testCase.input.series | string.literal}}, {{testCase.input.sliceLength}}));
        {{else}}
        string[] expected = {{testCase.expected}};
        Assert.Equal(expected, Series.Slices({{testCase.input.series | string.literal}}, {{testCase.input.sliceLength}}));
        {{end}}
    }
    {{end}}
}
