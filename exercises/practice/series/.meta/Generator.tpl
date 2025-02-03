using System;
using Xunit;

public class SeriesTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        {{if test.expected.error}}
        Assert.Throws<ArgumentException>(() => Series.Slices({{test.input.series | string.literal}}, {{test.input.sliceLength}}));
        {{else}}
        string[] expected = {{test.expected}};
        Assert.Equal(expected, Series.Slices({{test.input.series | string.literal}}, {{test.input.sliceLength}}));
        {{end}}
    }
    {{end}}
}
