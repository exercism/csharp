using Xunit;

public class AllergiesTests
{
    {{#test_cases_by_property.allergicTo}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        var sut = new Allergies({{input.score}});
        Assert.{{expected}}(sut.IsAllergicTo(Allergen.{{Capitalize input.item}}));
    }
    {{/test_cases_by_property.allergicTo}}

    {{#test_cases_by_property.list}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{test_method_name}}()
    {
        var sut = new Allergies({{input.score}});
        {{#isempty expected}}
        Assert.Empty(sut.List());
        {{else}}
        Allergen[] expected = [{{#each ../expected}}Allergen.{{Capitalize .}}{{#unless @last}},{{/unless}}{{/each}}];
        Assert.Equal(expected, sut.List());
        {{/isempty}}
    }
    {{/test_cases_by_property.list}}
}
