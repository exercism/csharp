using Xunit;

public class TwoFerTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal({{literal expected}}, TwoFer.Speak({{#if input.name}}{{literal input.name}}{{/if}}));
    }
    {{/test_cases}}
}
