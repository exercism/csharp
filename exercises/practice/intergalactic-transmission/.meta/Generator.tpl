public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        {{- message = string.replace test.input.message "\"" "" }}
        {{- if test.property == "transmitSequence" }}
        Assert.Equal({{ string.replace test.expected "\"" "" }}, IntergalacticTransmission.GetTransmitSequence({{ message }}));
        {{- else if test.property == "decodeMessage" }}
        {{- if test.expected.error }}
        Assert.Throws<ArgumentException>(() => IntergalacticTransmission.DecodeSequence({{ message }}));        
        {{- else }}
        Assert.Equal({{ string.replace test.expected "\"" "" }}, IntergalacticTransmission.DecodeSequence({{ message }}));
        {{ end -}}
        {{ end -}}
    }
    {{ end -}}
}
