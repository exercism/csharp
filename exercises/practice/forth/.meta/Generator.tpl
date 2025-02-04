using System;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        {{if test.expected.error}}
            Assert.Throws<InvalidOperationException>(() => {{testedClass}}.{{test.testedMethod}}({{test.input.instructions}}));
        {{else}}
            Assert.Equal("{{test.expected | array.join " "}}", {{testedClass}}.{{test.testedMethod}}({{test.input.instructions}}));
        {{end}}
    }
    {{end}}
}
