using Xunit;

public class SpaceAgeTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{method_name path}}()
    {
        var sut = new SpaceAge({{input.seconds}});
        Assert.Equal({{expected}}, sut.On{{input.planet}}(), precision: 2);
    }
    {{/test_cases}}
}
