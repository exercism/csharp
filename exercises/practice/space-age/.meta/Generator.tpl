using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        var sut = new SpaceAge({{test.input.seconds}});
        Assert.Equal({{test.expected}}, sut.On{{test.input.planet}}(), precision: 2);
    }
    {{end}}
}
