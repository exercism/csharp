using System;
using Xunit;

public class VariableLengthQuantityTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.testMethodName}}()
    {
        uint[] integers = [
            {{for integer in testCase.input.integers}}
            {{integer}}{{if !for.last}},{{end}}
            {{end}}
            ];
        {{if testCase.expected.error}}
        Assert.Throws<InvalidOperationException>(() => VariableLengthQuantity.{{testCase.property | string.capitalize}}(integers));
        {{else}}
        uint[] expected = [
            {{for expected in testCase.expected}}
            {{expected}}{{if !for.last}},{{end}}
            {{end}}
        ];
        Assert.Equal(expected, VariableLengthQuantity.{{testCase.property | string.capitalize}}(integers));
        {{end}}
    }
    {{end}}
}
