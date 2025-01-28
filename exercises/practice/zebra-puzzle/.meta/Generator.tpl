using Xunit;

public class ZebraPuzzleTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal(Nationality.{{expected}}, ZebraPuzzle.{{Capitalize property}}());
    }
    {{/test_cases}}
}
