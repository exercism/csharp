using System;
using Xunit;

public class AffineCipherTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.shortMethodName}}()
    {
        {{if testCase.expected.error}}
        Assert.Throws<ArgumentException>(() => AffineCipher.{{testCase.property | string.capitalize}}({{testCase.input.phrase | string.literal}}, {{testCase.input.key.a}}, {{testCase.input.key.b}}));
        {{else}}
        Assert.Equal({{testCase.expected | string.literal}}, AffineCipher.{{testCase.property | string.capitalize}}({{testCase.input.phrase | string.literal}}, {{testCase.input.key.a}}, {{testCase.input.key.b}}));
        {{end}}
    }
    {{end}}
}
