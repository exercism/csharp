{{ func assertions(node, path)
    checks = [$"Assert.Equal({string.to_int node.data}, tree.{path}Value);"]

    if node.left
        checks = array.add_range checks (assertions node.left (path + "Left."))
    end

    if node.right
        checks = array.add_range checks (assertions node.right (path + "Right."))
    end

    ret checks
end }}

using System.Linq;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.input.treeData | array.size == 1 }}
        var tree = new {{ testedClass }}({{ test.input.treeData[0] | @string.to_int }});
        {{- else -}}
        var tree = new {{ testedClass }}(new[] { {{ test.input.treeData | array.each @string.to_int | array.join "," }} });
        {{- end -}}
        {{- if test.property == "data" }}    
        {{ test.expected | assertions "" | array.join "\n" }}
        {{- else }}
        int[] expected = {{ test.expected | array.each @string.to_int }};
        Assert.Equal(expected, tree.AsEnumerable());
        {{ end -}}
    }
    {{ end -}}
}
