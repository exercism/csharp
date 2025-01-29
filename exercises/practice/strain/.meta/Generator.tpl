using System.Collections.Generic;
using System.Linq;
using Xunit;

public class StrainTests
{
    {{#test_cases_by_property.keep}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        {{#equals description "keeps lists"}}
        int[][] expected = [{{../expected}}];
        int[][] input = [{{#../input.list}}[{{.}}]{{#unless @last}}, {{/unless}}{{/../input.list}}];
        Assert.Equal(expected, input.Keep(x => x.Contains(5)).ToArray());
        {{else}}
        {{#equals ../description "keeps strings"}}
        string[] expected = [{{#../../expected}}{{lit .}}{{#unless @last}}, {{/unless}}{{/../../expected}}];
        string[] input = [{{#../../input.list}}{{lit .}}{{#unless @last}}, {{/unless}}{{/../../input.list}}];
        Assert.Equal(expected, input.Keep(x => x.StartsWith('z')).ToArray());
        {{else}}
        int[] expected = [{{../../expected}}];
        int[] input = [{{../../input.list}}];
        Assert.Equal(expected, input.Keep(x => {{replace ../../input.predicate "fn(x) -> " ""}}).ToArray());
        {{/equals}}
        {{/equals}}
    }
    {{/test_cases_by_property.keep}}

    {{#test_cases_by_property.discard}}
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void {{test_method_name}}()
    {
        {{#equals description "discards lists"}}
        int[][] expected = [{{../expected}}];
        int[][] input = [{{#../input.list}}[{{.}}]{{#unless @last}}, {{/unless}}{{/../input.list}}];
        Assert.Equal(expected, input.Discard(x => x.Contains(5)).ToArray());
        {{else}}
        {{#equals ../description "discards strings"}}
        string[] expected = [{{#../../expected}}{{lit .}}{{#unless @last}}, {{/unless}}{{/../../expected}}];
        string[] input = [{{#../../input.list}}{{lit .}}{{#unless @last}}, {{/unless}}{{/../../input.list}}];
        Assert.Equal(expected, input.Discard(x => x.StartsWith('z')).ToArray());
        {{else}}        
        int[] expected = [{{../../expected}}];
        int[] input = [{{../../input.list}}];
        Assert.Equal(expected, input.Discard(x => {{replace ../../input.predicate "fn(x) -> " ""}}).ToArray());
        {{/equals}}  
        {{/equals}}        
    }
    {{/test_cases_by_property.discard}}
}
