using Xunit;

public class DartsTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal({{expected}}, Darts.Score({{input.x}}, {{input.y}}));
    }
    {{/test_cases}}
}
