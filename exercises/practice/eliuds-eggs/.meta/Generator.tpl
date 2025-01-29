using Xunit;

public class EliudsEggsTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal({{expected}}, EliudsEggs.EggCount({{input.number}}));
    }
    {{/test_cases}}
}
