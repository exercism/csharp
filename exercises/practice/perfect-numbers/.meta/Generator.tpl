using Xunit;

public class PerfectNumbersTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        {{#if error}}
        Assert.Throws<ArgumentOutOfRangeException>(() => PerfectNumbers.Classify({{input.number}}));
        {{else}}
        Assert.Equal(Classification.{{Capitalize (raw expected)}}, PerfectNumbers.Classify({{input.number}}));
        {{/if}}
    }
    {{/test_cases}}
}
