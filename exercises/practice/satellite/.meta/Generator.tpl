{{ func to_tree
    if $0.empty?
        ret "null"
    end

    ret $"new Tree('{$0.v}', {to_tree $0.l}, {to_tree $0.r})"
end }}

{{ func to_arg
    if $0.empty?
        ret "[]"
    end

    ret "['" + (array.join $0 "', '") + "']"
end }}

using System;
using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error }}
            Assert.Throws<ArgumentException>(() => {{ testedClass }}.{{ test.testedMethod }}({{ test.input.preorder | to_arg }}, {{ test.input.inorder | to_arg }}));
        {{- else if test.expected.empty? }}
            Assert.Null({{ testedClass }}.{{ test.testedMethod }}({{ test.input.preorder | to_arg }}, {{ test.input.inorder | to_arg }}));
        {{ else }}
            var expected = {{ test.expected | to_tree }};
            Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.preorder | to_arg }}, {{ test.input.inorder | to_arg }}));
        {{ end -}}
    }
    {{ end -}}
}
