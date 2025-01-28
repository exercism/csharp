using Xunit;

public class DifferenceOfSquaresTests
{
    {{#test_cases_by_property.squareOfSum}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{short_test_method_name}}()
    {
        Assert.Equal({{expected}}, DifferenceOfSquares.CalculateSquareOfSum({{input.number}}));
    }
    {{/test_cases_by_property.squareOfSum}}

    {{#test_cases_by_property.sumOfSquares}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{short_test_method_name}}()
    {
        Assert.Equal({{expected}}, DifferenceOfSquares.CalculateSumOfSquares({{input.number}}));
    }
    {{/test_cases_by_property.sumOfSquares}}

    {{#test_cases_by_property.differenceOfSquares}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{short_test_method_name}}()
    {
        Assert.Equal({{expected}}, DifferenceOfSquares.CalculateDifferenceOfSquares({{input.number}}));
    }
    {{/test_cases_by_property.differenceOfSquares}}
}
