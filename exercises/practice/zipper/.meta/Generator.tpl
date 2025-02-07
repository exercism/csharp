{{ func to_tree
    if $0
        ret $"new BinTree({$0.value}, {to_tree $0.left}, {to_tree $0.right})"
    end

    ret "null"
end }}

{{ func to_expected 
    case $0.type
        when "tree" 
            to_tree $0.value
        when "int"
            $0.value
        when "zipper"
            $"Zipper.FromTree({to_tree $0.initialTree})"
        else
            $0
        end
end }}

{{ func to_call 
    calls = []

    for op in $0
        calls = array.add calls (op.operation | pascalize | string.append $"({op.item})" )
    end

    array.join calls "."
end }}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var tree = {{ test.input.initialTree | to_tree }};
        var sut = Zipper.FromTree(tree);
        var actual = sut.{{ test.input.operations | to_call }};
        {{- if test.expected.value == null }}
        Assert.Null(actual);
        {{- else }}
        var expected = {{ test.expected | to_expected }};
        Assert.Equal(expected, actual);
        {{ end -}}
    }
    {{ end -}}
}
