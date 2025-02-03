using Xunit;

public class SpaceAgeTests
{
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        var sut = new SpaceAge({{testCase.input.seconds}});
        Assert.Equal({{testCase.expected}}, sut.On{{testCase.input.planet}}(), precision: 2);
    }
    {{end}}
}
