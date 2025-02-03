using Xunit;

public class AnagramTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        string[] candidates = {{test.input.candidates}};
        var sut = new Anagram({{test.input.subject | string.literal}});
        {{if test.expected.empty?}}
        Assert.Empty(sut.FindAnagrams(candidates));
        {{else}}
        string[] expected = {{test.expected}};
        Assert.Equal(expected, sut.FindAnagrams(candidates));
        {{end}}
    }
    {{end}}
}
