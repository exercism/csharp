using Xunit;

public class TriangleTests
{
    {{#test_cases_by_property.equilateral}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.{{expected}}(Triangle.IsEquilateral({{input.sides.0}}, {{input.sides.1}}, {{input.sides.2}}));
    }
    {{/test_cases_by_property.equilateral}}

    {{#test_cases_by_property.isosceles}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{test_method_name}}()
    {
        Assert.{{expected}}(Triangle.IsIsosceles({{input.sides.0}}, {{input.sides.1}}, {{input.sides.2}}));
    }
    {{/test_cases_by_property.isosceles}}

    {{#test_cases_by_property.scalene}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{test_method_name}}()
    {
        Assert.{{expected}}(Triangle.IsScalene({{input.sides.0}}, {{input.sides.1}}, {{input.sides.2}}));
    }
    {{/test_cases_by_property.scalene}}
}
