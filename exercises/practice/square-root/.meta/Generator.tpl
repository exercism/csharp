using Xunit;

public class SquareRootTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal({{expected}}, SquareRoot.Root({{input.radicand}}));
    }
    {{/test_cases}}
}
