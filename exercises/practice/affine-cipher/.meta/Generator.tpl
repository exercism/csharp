using System;
using Xunit;

public class AffineCipherTests
{
    {{#test_cases_by_property.encode}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{short_test_method_name}}()
    {
        {{#if expected.error}}
        Assert.Throws<ArgumentException>(() => AffineCipher.Encode({{lit input.phrase}}, {{input.key.a}}, {{input.key.b}}));
        {{else}}
        Assert.Equal({{lit expected}}, AffineCipher.Encode({{lit input.phrase}}, {{input.key.a}}, {{input.key.b}}));
        {{/if}}
    }
    {{/test_cases_by_property.encode}}

    {{#test_cases_by_property.decode}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{short_test_method_name}}()
    {
        {{#if expected.error}}
        Assert.Throws<ArgumentException>(() => AffineCipher.Decode({{lit input.phrase}}, {{input.key.a}}, {{input.key.b}}));
        {{else}}
        Assert.Equal({{lit expected}}, AffineCipher.Decode({{lit input.phrase}}, {{input.key.a}}, {{input.key.b}}));
        {{/if}}
    }
    {{/test_cases_by_property.decode}}
}
