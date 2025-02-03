using System;
using System.Collections.Generic;
using Xunit;

public class AlphameticsTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        {{if test.expected}}
        var actual = Alphametics.Solve({{test.input.puzzle | string.literal}});
        var expected = new Dictionary<char, int>
        {
            {{for key in test.expected | object.keys}}
            ['{{key}}'] = {{test.expected[key]}}{{if !for.last}},{{end}}
            {{end}}
        };
        Assert.Equal(expected, actual);        
        {{else}}
        Assert.Throws<ArgumentException>(() => Alphametics.Solve({{test.input.puzzle | string.literal}}));
        {{end}}
    }
    {{end}}
}
