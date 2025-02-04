using System;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        Assert.Equal({{if test.expected.error}}-1{{else}}{{test.expected}}{{end}}, {{testedClass}}.{{test.testedMethod}}({{test.input.array}}, {{test.input.value}}));
    }
    {{end}}
}
