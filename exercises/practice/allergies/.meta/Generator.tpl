using Xunit;

public class AllergiesTests
{
    {{for testCase in testCasesByProperty.allergicTo}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.testMethodName}}()
    {
        var sut = new Allergies({{testCase.input.score}});
        Assert.{{testCase.expected ? "True" : "False"}}(sut.IsAllergicTo({{testCase.input.item | enum "Allergen"}}));
    }
    {{end}}

    {{for testCase in testCasesByProperty.list}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{testCase.testMethodName}}()
    {
        var sut = new Allergies({{testCase.input.score}});
        {{if testCase.expected.empty?}}
        Assert.Empty(sut.List());
        {{else}}
        Allergen[] expected = [
            {{for expected in testCase.expected}}        
                {{expected | enum "Allergen"}}{{if !for.last}},{{end}}
            {{end}}
        ];
        Assert.Equal(expected, sut.List());
        {{end}}
    }
    {{end}}    
}
