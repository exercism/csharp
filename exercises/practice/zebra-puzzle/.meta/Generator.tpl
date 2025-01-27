using Xunit;

public class ZebraPuzzleTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        Assert.Equal(Nationality.{{raw expected}}, ZebraPuzzle.{{String.capitalize property}}());
    }
    {{/test_cases}}
}
