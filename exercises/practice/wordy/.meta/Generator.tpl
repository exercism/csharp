public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- if test.expected.error }}
        Assert.Throws<ArgumentException>(() => Wordy.Answer({{ test.input.question | string.literal }}));
        {{ else }}
        Assert.Equal({{ test.expected }}, {{ testedClass }}.{{ test.testedMethod }}({{ test.input.question | string.literal }}));
        {{ end -}}
    }
    {{ end -}}
}
