using System;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.shortTestMethod}}()
    {
        {{if test.expected.error}}
        Assert.Throws<ArgumentException>(() => AffineCipher.{{test.testedMethod}}({{test.input.phrase | string.literal}}, {{test.input.key.a}}, {{test.input.key.b}}));
        {{else}}
        Assert.Equal({{test.expected | string.literal}}, {{testedClass}}.{{test.testedMethod}}({{test.input.phrase | string.literal}}, {{test.input.key.a}}, {{test.input.key.b}}));
        {{end}}
    }
    {{end}}
}
