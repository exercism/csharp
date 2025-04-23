{{ func to_tree
    if $0
        ret $"new BinTree({$0.value}, {to_tree $0.left}, {to_tree $0.right})"
    end

    ret "null"
end }}

{{ func to_arg 
    case (object.typeof $0)
        when "number"
            ret $0
        when "null"
            ret $0
        else
            ret (to_tree $0)
        end    
end }}

{{ func to_expected 
    case $0.type
        when "tree" 
            to_tree $0.value
        when "int"
            $0.value
        when "zipper"
            calls = $0.operations | to_calls
            $"Zipper.FromTree({to_tree $0.initialTree}){calls}"
        else
            $0
        end
end }}

{{ func to_call
    if object.has_key $0 "item"
        argument = to_arg $0.item
        ret $0.operation | pascalize | string.append $"({argument})"
    end

    ret $0.operation | pascalize | string.append "()"
end }}

{{ func to_calls 
    calls = ""

    for op in $0
        call = to_call op
        calls = string.append calls $"?.{call}"
    end

    ret calls
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var tree = {{ test.input.initialTree | to_tree }};
        var sut = Zipper.FromTree(tree);
        var actual = sut{{ test.input.operations | to_calls }};
        {{- if test.expected.type == "zipper" && !test.expected.initialTree }}
        Assert.Null(actual);
        {{- else }}
        var expected = {{ test.expected | to_expected }};
        Assert.Equal(expected, actual);
        {{ end -}}
    }
    {{ end -}}
}
