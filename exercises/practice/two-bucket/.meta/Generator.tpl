public class {{ testClass }}
{
    {{- for test in tests }}
    [Fact{{ if !for.first }}(Skip = "Remove this Skip property to run this test"){{ end }}]
    public void {{ test.testMethod }}()
    {
        var sut = new {{ testedClass }}({{ test.input.bucketOne }}, {{ test.input.bucketTwo }}, {{ test.input.startBucket | enum "Bucket" }});
        {{- if test.expected.error }}
            Assert.Throws<ArgumentException>(() => sut.Measure({{ test.input.goal }}));
        {{ else }}
            var actual = sut.Measure({{ test.input.goal }});
            Assert.Equal({{ test.expected.moves }}, actual.Moves);
            Assert.Equal({{ test.expected.otherBucket }}, actual.OtherBucket);
            Assert.Equal({{ test.expected.goalBucket | enum "Bucket" }}, actual.GoalBucket);
        {{ end -}}
    }
    {{ end -}}
}
