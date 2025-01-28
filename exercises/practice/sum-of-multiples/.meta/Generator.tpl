using Xunit;

public class SumOfMultiplesTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.Equal({{expected}}, SumOfMultiples.Sum([{{input.factors}}], {{input.limit}}));
    }
    {{/test_cases}}
}
