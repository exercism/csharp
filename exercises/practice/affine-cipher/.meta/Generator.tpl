using System;
using Xunit;

public class AffineCipherTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.shortMethodName}}()
    {
        {{if test.expected.error}}
        Assert.Throws<ArgumentException>(() => AffineCipher.{{test.property | string.capitalize}}({{test.input.phrase | string.literal}}, {{test.input.key.a}}, {{test.input.key.b}}));
        {{else}}
        Assert.Equal({{test.expected | string.literal}}, AffineCipher.{{test.property | string.capitalize}}({{test.input.phrase | string.literal}}, {{test.input.key.a}}, {{test.input.key.b}}));
        {{end}}
    }
    {{end}}
}
