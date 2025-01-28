using Xunit;

public class IsogramTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.{{expected}}(Isogram.IsIsogram({{lit input.phrase}}));
    }
    {{/test_cases}}
}
