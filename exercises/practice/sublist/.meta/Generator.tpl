using System.Collections.Generic;
using Xunit;

public class SublistTests
{
    {{#test_cases}}
    [Fact{{#unless @first}}(Skip = "Remove this Skip property to run this test"){{/unless}}]
    public void {{test_method_name}}()
    {
        Assert.Equal(SublistType.{{capitalize expected}}, Sublist.Classify(new List<int>{{#isempty input.listOne}}(){{else}} { {{../input.listOne}} }{{/isempty}}, new List<int>{{#isempty input.listTwo}}(){{else}} { {{../input.listTwo}} }{{/isempty}}));
    }
    {{/test_cases}}
}
