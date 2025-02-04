using System;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        {{if test.expected.error}}
            Assert.Throws<ArgumentOutOfRangeException>(() => {{testedClass}}.InEnglish({{test.input.number}}L));
        {{else}}
            Assert.Equal({{test.expected | string.literal}}, {{testedClass}}.InEnglish({{test.input.number}}L));
        {{end}}
    }
    {{end}}
}
