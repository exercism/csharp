using Xunit;

{{func decode_arg}}
    {{if $0.input.ciphertext == "cipher.encode"}}
        sut.Encode({{$0.input.plaintext | string.literal}})
    {{else if $0.input.ciphertext == "cipher.key.substring(0, expected.length)"}}
        sut.Key.Substring(0, 10)
    {{else}}
        {{$0.input.ciphertext | string.literal}}
    {{end}}
{{end}}

{{func expected_value}}
    {{if $0 == "cipher.key.substring(0, plaintext.length)"}}
        sut.Key.Substring(0, 10)
    {{else}}
        {{ $0 | string.literal }}
    {{end}}
{{end}}

public class SimpleCipherTests
{
    {{for test in tests}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{test.methodName}}()
    {
        var sut = new SimpleCipher({{if test.input.key}}{{test.input.key | string.literal}}{{end}});
        {{if test.property == "encode"}}        
        Assert.Equal({{test.expected | expected_value}}, sut.Encode({{test.input.plaintext | string.literal}}));
        {{else if test.property == "decode"}}
        Assert.Equal({{test.expected | string.literal}}, sut.Decode({{test | decode_arg}}));
        {{else if test.property == "key"}}
        Assert.Matches({{test.expected.match | string.literal}}, sut.Key);
        {{end}}
    }
    {{end}}
}
