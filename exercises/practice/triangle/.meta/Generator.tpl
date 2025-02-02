using Xunit;

public class TriangleTests
{
    {{for testCase in testCasesByProperty.equilateral}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.testMethodName}}()
    {
        Assert.{{testCase.expected ? "True" : "False"}}(Triangle.IsEquilateral({{testCase.input.sides | array.join ", "}}));
    }
    {{end}}

    {{for testCase in testCasesByProperty.isosceles}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{testCase.testMethodName}}()
    {
        Assert.{{testCase.expected ? "True" : "False"}}(Triangle.IsIsosceles({{testCase.input.sides | array.join ", "}}));
    }
    {{end}}

    {{for testCase in testCasesByProperty.scalene}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{testCase.testMethodName}}()
    {
        Assert.{{testCase.expected ? "True" : "False"}}(Triangle.IsScalene({{testCase.input.sides | array.join ", "}}));
    }
    {{end}}
}
