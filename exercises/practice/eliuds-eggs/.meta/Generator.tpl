using Xunit;

public class EliudsEggsTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.Equal({{expected}}, EliudsEggs.EggCount({{input.number}}));
    }
    {{/test_cases}}
}
