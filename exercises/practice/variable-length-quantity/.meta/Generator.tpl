using System;
using Xunit;

public class VariableLengthQuantityTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        uint[] integers = [
            {{for integer in test.input.integers}}
            {{integer}}{{if !for.last}},{{end}}
            {{end}}
            ];
        {{if test.expected.error}}
        Assert.Throws<InvalidOperationException>(() => VariableLengthQuantity.{{test.property | string.capitalize}}(integers));
        {{else}}
        uint[] expected = [
            {{for expected in test.expected}}
            {{expected}}{{if !for.last}},{{end}}
            {{end}}
        ];
        Assert.Equal(expected, VariableLengthQuantity.{{test.property | string.capitalize}}(integers));
        {{end}}
    }
    {{end}}
}
