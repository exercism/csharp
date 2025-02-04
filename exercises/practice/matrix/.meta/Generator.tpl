using Xunit;

public class {{testClass}}
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.testMethod}}()
    {
        var sut = new Matrix({{test.input.string | string.literal}});
        int[] expected = {{test.expected}};
        Assert.Equal(expected, sut.{{test.testedMethod}}({{test.input.index}}));
    }
    {{end}}
}
