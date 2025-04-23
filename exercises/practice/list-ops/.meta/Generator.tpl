{{ func list_type 
    case ($["depth"] ?? 1)
        when 1
            ret "List<int>"
        when 2
            ret "List<List<int>>"
        when 3
            ret "List<List<List<int>>>"
        when 4
            ret "List<List<List<List<int>>>>"
        end
end }}

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.property == "append" }}
            List<int> list1 = {{ test.input.list1 }};
            List<int> list2 = {{ test.input.list2 }};
            {{- if test.expected.empty? }}
                Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(list1, list2));
            {{- else }}
                List<int> expected = {{ test.expected }};
                Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list1, list2));
            {{ end -}}
        {{- else if test.property == "concat" }}
            {{- if test.description == "list of nested lists" -}}
                List<List<List<int>>> lists = {{ test.input.lists }};
            {{- else -}}
                List<List<int>> lists = {{ test.input.lists }};
            {{- end -}}
            {{- if test.expected.empty? }}
                Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(lists));
            {{- else }}
                {{- if test.description == "list of nested lists" }}
                    List<List<int>> expected = {{ test.expected }};
                {{ else }}
                    List<int> expected = {{ test.expected }};
                {{ end -}}
                Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(lists));
            {{ end -}}
        {{- else if test.property == "filter" }}
            List<int> list = {{ test.input.list }};
            Func<int, bool> function = {{ test.input.function | string.replace "->" "=>" | string.replace "modulo" "%" }};
            {{- if test.expected.empty? }}
                Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(list, function));
            {{- else }}
                List<int> expected = {{ test.expected }};
                Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list, function));
            {{ end -}}
        {{- else if test.property == "map" }}
            List<int> list = {{ test.input.list }};
            Func<int, int> function = {{ test.input.function | string.replace "->" "=>" | string.replace "modulo" "%" }};
            {{- if test.expected.empty? }}
                Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(list, function));
            {{- else }}
                List<int> expected = {{ test.expected }};
                Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list, function));
            {{ end -}}
        {{- else if test.property == "length" }}
            List<int> list = {{ test.input.list }};
            Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}(list));
        {{- else if test.property == "foldl" || test.property == "foldr" }}
            List<int> list = {{ test.input.list }};
            int initial = {{ test.input.initial }};
            Func<int, int, int> function = {{ test.input.function | string.replace "->" "=>" | string.replace "modulo" "%" }};
            Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}(list, initial, function));
        {{- else if test.property == "reverse" }}
            {{- if test.expected.empty? }}
                List<int> list = {{ test.input.list }};
                Assert.Empty({{ testedClass }}.{{ test.testedMethod }}(list));
            {{- else if test.description == "list of lists is not flattened" }}
                List<List<int>> list = {{ test.input.list }};
                List<List<int>> expected = {{ test.expected }};
                Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list));
            {{ else }}
                List<int> list = {{ test.input.list }};
                List<int> expected = {{ test.expected }};
                Assert.Equal(expected, {{ testedClass }}.{{ test.testedMethod }}(list));
            {{ end -}}
        {{ end -}}
    }
    {{ end -}}
}
