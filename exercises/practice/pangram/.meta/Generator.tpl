using Xunit;

public class PangramTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.{{expected}}(Pangram.IsPangram({{input.sentence}}));
    }
    {{/test_cases}}
}
