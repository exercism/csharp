using System;
using Xunit;

public class WordyTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        {{#if expected.error}}
        Assert.Throws<ArgumentException>(() => Wordy.Answer({{lit input.question}}));
        {{else}}
        Assert.Equal({{expected}}, Wordy.Answer({{lit input.question}}));
        {{/if}}
    }
    {{/test_cases}}
}
