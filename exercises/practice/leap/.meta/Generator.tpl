using Xunit;

public class LeapTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.{{expected}}(Leap.IsLeapYear({{input.year}}));
    }
    {{/test_cases}}
}
