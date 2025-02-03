using System;
using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        uint[] integers = [
            {{for integer in test.input.integers}}
            {{integer}}{{if !for.last}},{{end}}
            {{end}}
            ];
        {{if test.expected.error}}
        Assert.Throws<InvalidOperationException>(() => VariableLengthQuantity.{{test.testedMethod}}(integers));
        {{else}}
        uint[] expected = [
            {{for expected in test.expected}}
            {{expected}}{{if !for.last}},{{end}}
            {{end}}
        ];
        Assert.Equal(expected, {{testedClass}}.{{test.testedMethod}}(integers));
        {{end}}
    }
    {{end}}
}
