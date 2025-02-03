using System.Collections.Generic;
using Xunit;

public class WordCountTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        var actual = WordCount.CountWords({{test.input.sentence | string.literal}});
        var expected = new Dictionary<string, int>
        {
            {{for key in test.expected | object.keys}}
            [{{key | string.literal}}] = {{test.expected[key]}}{{if !for.last}},{{end}}
            {{end}}
        };
        Assert.Equal(expected, actual);
    }
    {{end}}
}
