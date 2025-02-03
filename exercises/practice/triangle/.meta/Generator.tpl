using Xunit;

public class TriangleTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        Assert.{{testCase.expected ? "True" : "False"}}(Triangle.Is{{testCase.property | string.capitalize}}({{testCase.input.sides | array.join ", "}}));
    }
    {{end}}
}
