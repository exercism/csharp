using System;
using Xunit;

public class WordyTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.testMethodName}}()
    {
        {{if testCase.expected.error}}
        Assert.Throws<ArgumentException>(() => Wordy.Answer({{testCase.input.question | string.literal}}));
        {{else}}
        Assert.Equal({{testCase.expected}}, Wordy.Answer({{testCase.input.question | string.literal}}));
        {{end}}
    }
    {{end}}
}
