using Xunit;

public class TwoFerTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.Equal({{expected}}, TwoFer.Speak({{#if input.name}}{{input.name}}{{/if}}));
    }
    {{/test_cases}}
}
