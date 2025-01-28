using Xunit;

public class PangramTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.{{lit expected}}(Pangram.IsPangram({{lit input.sentence}}));
    }
    {{/test_cases}}
}
