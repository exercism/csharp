using Xunit;

public class IsogramTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.{{expected}}(Isogram.IsIsogram({{literal input.phrase}}));
    }
    {{/test_cases}}
}
