{{func decode_arg
    if $0.input.ciphertext == "cipher.encode"
        ret $"sut.Encode({string.literal $0.input.plaintext})"
    else if $0.input.ciphertext == "cipher.key.substring(0, expected.length)"
        ret "sut.Key.Substring(0, 10)"
    else
        ret string.literal $0.input.ciphertext
    end
end}}

{{func expected_value
    if $0 == "cipher.key.substring(0, plaintext.length)"
        ret "sut.Key.Substring(0, 10)"
    else
        ret string.literal $0
    end
end}}

using Xunit;

public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new SimpleCipher({{ if test.input.key }}{{ test.input.key | string.literal }}{{ end }});
        {{- if test.property == "encode" }}
        Assert.Equal({{- test.expected | expected_value }}, sut.Encode({{ test.input.plaintext | string.literal }}));
        {{- else if test.property == "decode" }}
        Assert.Equal({{- test.expected | string.literal }}, sut.Decode({{ test | decode_arg }}));
        {{- else if test.property == "key" }}
        Assert.Matches({{- test.expected.match | string.literal }}, sut.Key);
        {{ end -}}
    }
    {{ end -}}
}
