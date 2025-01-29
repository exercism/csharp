using System;
using Xunit;

public class HammingTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        {{#if expected.error}}
        Assert.Throws<ArgumentException>(() => Hamming.Distance({{lit input.strand1}}, {{lit input.strand2}}));
        {{else}}
        Assert.Equal({{expected}}, Hamming.Distance({{lit input.strand1}}, {{lit input.strand2}}));
        {{/if}}
    }
    {{/test_cases}}
}
