using Xunit;

public class AcronymTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.Equal({{literal expected}}, Acronym.Abbreviate({{literal input.phrase}}));
    }
    {{/test_cases}}
}
