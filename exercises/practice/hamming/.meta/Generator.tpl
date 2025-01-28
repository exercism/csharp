using Xunit;

public class HammingTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        {{#if error}}
        Assert.Throws<ArgumentException>(() => Hamming.Distance({{input.strand1}}, {{input.strand2}}));
        {{else}}
        Assert.Equal({{expected}}, Hamming.Distance({{input.strand1}}, {{input.strand2}}));
        {{/if}}
    }
    {{/test_cases}}
}
