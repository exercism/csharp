using Xunit;

public class TwoFerTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal({{lit expected}}, TwoFer.Speak({{#if input.name}}{{lit input.name}}{{/if}}));
    }
    {{/test_cases}}
}
