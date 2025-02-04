using System;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        {{if test.expected.error}}
            Assert.Throws<ArgumentException>(() => {{testedClass}}.Get{{test.testedMethod}}({{test.input.digits | string.literal}}, {{test.input.span}}));
        {{else}}
            Assert.Equal({{test.expected}}, {{testedClass}}.Get{{test.testedMethod}}({{test.input.digits | string.literal}}, {{test.input.span}}));
        {{end}}
    }
    {{end}}
}
