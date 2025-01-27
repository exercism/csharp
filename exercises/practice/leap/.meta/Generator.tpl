using Xunit;

public class LeapTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.{{expected}}(Leap.IsLeapYear({{input.year}}));
    }
    {{/test_cases}}
}
