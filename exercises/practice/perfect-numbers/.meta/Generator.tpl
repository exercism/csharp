using Xunit;

public class PerfectNumbersTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        {{#if error}}
        Assert.Throws<ArgumentOutOfRangeException>(() => PerfectNumbers.Classify({{input.number}}));
        {{else}}
        Assert.Equal(Classification.{{Capitalize expected}}, PerfectNumbers.Classify({{input.number}}));
        {{/if}}
    }
    {{/test_cases}}
}
