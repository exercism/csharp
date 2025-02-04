using System;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        {{if test.expected.error}}
            Assert.Throws<ArgumentOutOfRangeException>(() => {{testedClass}}.{{test.testedMethod}}({{test.input.number}}));
        {{else}}
            Assert.Equal({{test.expected}}, {{testedClass}}.{{test.testedMethod}}({{test.input.number}}));
        {{end}}
    }
    {{end}}
}
