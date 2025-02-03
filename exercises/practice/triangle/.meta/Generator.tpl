using Xunit;

public class TriangleTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        Assert.{{test.expected ? "True" : "False"}}(Triangle.Is{{test.property | string.capitalize}}({{test.input.sides | array.join ", "}}));
    }
    {{end}}
}
