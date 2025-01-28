using Xunit;

public class AcronymTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal({{lit expected}}, Acronym.Abbreviate({{lit input.phrase}}));
    }
    {{/test_cases}}
}
