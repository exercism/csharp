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
    {{for testCase in testCases}}
    [Fact{{if !for.first}}(Skip = "Remove this Skip property to run this test"){{end}}]
    public void {{testCase.methodName}}()
    {
        var sut = new SimpleCipher({{if testCase.input.key}}{{testCase.input.key | string.literal}}{{end}});
        {{if testCase.property == "encode"}}        
        Assert.Equal({{testCase.expected | expected_value}}, sut.Encode({{testCase.input.plaintext | string.literal}}));
        {{else if testCase.property == "decode"}}
        Assert.Equal({{testCase.expected | string.literal}}, sut.Decode({{testCase | decode_arg}}));
        {{else if testCase.property == "key"}}
        Assert.Matches({{testCase.expected.match | string.literal}}, sut.Key);
        {{end}}
    }
    {{end}}
}
