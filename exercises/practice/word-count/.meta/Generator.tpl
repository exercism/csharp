using System.Collections.Generic;
using Xunit;

public class WordCountTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        var actual = WordCount.CountWords({{testCase.input.sentence | string.literal}});
        var expected = new Dictionary<string, int>
        {
            {{for key in testCase.expected | object.keys}}
            [{{key | string.literal}}] = {{testCase.expected[key]}}{{if !for.last}},{{end}}
            {{end}}
        };
        Assert.Equal(expected, actual);
    }
    {{end}}
}
